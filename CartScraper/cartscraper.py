import sys
import traceback
import time
import requests
from bs4 import BeautifulSoup
import json
import cartridgechipmodel as cartchip
import cartridgemodel as cart
import developermodel as dev
import gamemodel as gm
import publishermodel as pub
import regionmodel as rgn
import producermodel as pro

BASE_URL = 'http://bootgod.dyndns.org:7777'
URL = '/profile.php?id='

def main():
  global games, cartridges, cartridgechips, developers, publishers, regions, producers
  games = []
  cartridges = []
  cartridgechips = []
  developers = []
  publishers = []
  regions = []
  producers = []

  availabletokens = dict({
    "catalogentry": 0,
    "cartclass": 0,
    "region": 0,
    "cartclass": 0,
    "releasedate": 0,
    "publisher": 0,
    "developer": 0,
    "players": 0,
    "producer": 0,
    "color": 0,
    "formfactor": 0,
    "embossedtext": 0,
    "frontlabelentry": 0,
    "sealofquality": 0,
    "mfgstrpresent": 0,
    "backlabelid": 0,
    "backlabeldesc": 0,
    "twodigitcode": 0,
    "revision": 0,
    "pcb": 0,
    "cictype": 0,
    "hardware": 0,
    "wram": 0,
    "vram": 0,
    "partnumber": 0,
    "manufacturer": 0,
    "designation": 0,
    "type": 0,
    "package": 0
  })

  errorcount = 0
  unavailable = 0

  # loop through pages (5000)
  for i in range(1, 5000):
    # reset token dictionary values to 0
    availabletokens = dict.fromkeys(availabletokens, 0)

    try:
      page = requests.get(BASE_URL + URL + str(i))
      soup = BeautifulSoup(page.content, 'html.parser')

      # check if cart is disabled
      if soup.find(text=f"Could not find CartID {str(i)} or it is disabled.") is not None:
        unavailable += 1
        continue

      # gather data
      # catalogentry, cartclass, region, releasedate, publisher, developer, players
      primary_data_table = soup.find(text="Catalog ID").parent.parent.parent
      if primary_data_table.find(text="Catalog ID") is not None:
        availabletokens["catalogentry"] = 1
      if primary_data_table.find(text="Class") is not None:
        availabletokens["cartclass"] = 1
      if primary_data_table.find(text="Region") is not None:
        availabletokens["region"] = 1
      if primary_data_table.find(text="Release Date") is not None:
        availabletokens["releasedate"] = 1
      if primary_data_table.find(text="Publisher") is not None:
        availabletokens["publisher"] = 1
      if primary_data_table.find(text="Developer") is not None:
        availabletokens["developer"] = 1
      if primary_data_table.find(text="Players") is not None:
        availabletokens["players"] = 1

      # producer, color, formfactor, embossedtext, frontlabelentry, sealofquality, mfgstrpresent, backlabelentry, twodigitcode, revision
      cart_data_table = soup.find(text="Cart Properties").parent.parent.parent
      if cart_data_table.find(text="Cart Producer") is not None:
        availabletokens["producer"] = 1
      if cart_data_table.find(text="Color") is not None:
        availabletokens["color"] = 1
      if cart_data_table.find(text="Form Factor") is not None:
        availabletokens["formfactor"] = 1
      if cart_data_table.find(text="Embossed Text") is not None:
        availabletokens["embossedtext"] = 1
      if cart_data_table.find(text="Front Label ID") is not None:
        availabletokens["frontlabelentry"] = 1
      if cart_data_table.find(text="Seal of Quality") is not None:
        availabletokens["sealofquality"] = 1
      if cart_data_table.find(text="MfgString Present") is not None:
        availabletokens["mfgstrpresent"] = 1
      if cart_data_table.find(text="Back Label ID / Desc") is not None:
        availabletokens["backlabelid"] = 1
      if cart_data_table.find(text="Back Label Desc") is not None:
        availabletokens["backlabeldesc"] = 1
      if cart_data_table.find(text="2-digit Code") is not None:
        availabletokens["twodigitcode"] = 1
      if cart_data_table.find(text="Revision") is not None:
        availabletokens["revision"] = 1
      
      # pcb, cictype, hardware, wram, vram
      rom_data_table = soup.find(text="WRAM").parent.parent.parent
      availabletokens["pcb"] = 1
      if rom_data_table.find(text="CIC Type") is not None:
        availabletokens["cictype"] = 1
      if rom_data_table.find(text="Hardware") is not None:
        availabletokens["hardware"] = 1
      if rom_data_table.find(text="WRAM") is not None:
        availabletokens["wram"] = 1
      if rom_data_table.find(text="VRAM") is not None:
        availabletokens["vram"] = 1

      # partnumber, manufacturer, designation, type, package
      if soup.find(text="Designation") is not None:
        chip_info_table = soup.find(text="Designation").parent.parent.parent
        if chip_info_table.find(text="Designation") is not None:
          availabletokens["designation"] = 1
        if chip_info_table.find(text="Part #") is not None:
          availabletokens["partnumber"] = 1
        if chip_info_table.find(text="Maker") is not None:
          availabletokens["manufacturer"] = 1
        if chip_info_table.find(text="Type") is not None:
          availabletokens["type"] = 1
        if chip_info_table.find(text="Package") is not None:
          availabletokens["package"] = 1
      
      # get game info
      game = gm.Game()
      game.id = i
      game.name = str(soup.find("td", {"class": "headingmain"}).contents[0]).strip()
      if availabletokens["cartclass"] == 1:
        game.cartclass = str(primary_data_table.find(text="Class").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["catalogentry"] == 1:
        game.catalogentry = str(primary_data_table.find(text="Catalog ID").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["players"] == 1:
        game.players = str(primary_data_table.find(text="Players").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["releasedate"] == 1:
        game.releasedate = str(primary_data_table.find(text="Release Date").parent.parent.find_all("td")[0].contents[0]).strip()
      
      # get cartridge info
      cartridge = cart.Cartridge()
      cartridge.id = i
      if availabletokens["color"] == 1:
        cartridge.color = str(cart_data_table.find(text="Color").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["formfactor"] == 1:
        cartridge.formfactor = str(cart_data_table.find(text="Form Factor").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["embossedtext"] == 1:
        cartridge.embossedtext = str(cart_data_table.find(text="Embossed Text").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["frontlabelentry"] == 1:
        cartridge.frontlabelentry = str(cart_data_table.find(text="Front Label ID").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["sealofquality"] == 1:
        cartridge.sealofquality = str(cart_data_table.find(text="Seal of Quality").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["mfgstrpresent"] == 1:
        cartridge.mfgstrpresent = str(cart_data_table.find(text="MfgString Present").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["backlabelid"] == 1:
        cartridge.backlabelentry = str(cart_data_table.find(text="Back Label ID / Desc").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["backlabeldesc"] == 1:
        cartridge.backlabelentry = str(cart_data_table.find(text="Back Label Desc").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["twodigitcode"] == 1:
        cartridge.twodigitcode = str(cart_data_table.find(text="2-digit Code").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["revision"] == 1:
        cartridge.revision = str(cart_data_table.find(text="Revision").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["pcb"] == 1:
        cartridge.pcb = str(rom_data_table.find_all("tr")[0].find_all("td")[0].contents[0].get_text()).strip()
      if availabletokens["wram"] == 1:
        cartridge.wram = str(rom_data_table.find(text="WRAM").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["vram"] == 1:
        cartridge.vram = str(rom_data_table.find(text="VRAM").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["cictype"] == 1:
        cartridge.cictype = str(rom_data_table.find(text="CIC Type").parent.parent.find_all("td")[0].contents[0]).strip()
      if availabletokens["hardware"] == 1:
        cartridge.hardware = str(rom_data_table.find(text="Hardware").parent.parent.find_all("td")[0].contents[0]).strip()
      
      imagelinks = soup.find_all("a", {"class": "myimg"})
      for link in imagelinks:
        cartridge.images.append(BASE_URL + "/" + str(link['href']).strip())

      # get developer info
      developer = dev.Developer()
      developer.id = i
      if availabletokens["developer"] == 1:
        developer.name = str(primary_data_table.find(text="Developer").parent.parent.find_all("td")[0].contents[0].get_text()).strip()
      
      # get publisher info
      publisher = pub.Publisher()
      publisher.id = i
      if availabletokens["publisher"] == 1:
        publisher.name = str(primary_data_table.find(text="Publisher").parent.parent.find_all("td")[0].contents[0].get_text()).strip()

      # get region info
      region = rgn.Region()
      region.id = i
      if availabletokens["region"] == 1:
        region.name = str(primary_data_table.find(text="Region").parent.parent.find_all("td")[0].contents[0]["title"]).strip()

      # get producer info
      producer = pro.Producer()
      producer.id = i
      if availabletokens["producer"] == 1:
        if len(cart_data_table.find(text="Cart Producer").parent.parent.find_all("td")[0].find_all("img")) > 0:
          producer.name = str(cart_data_table.find(text="Cart Producer").parent.parent.find_all("td")[0].contents[0]["title"]).strip()
        else:
          producer.name = str(cart_data_table.find(text="Cart Producer").parent.parent.find_all("td")[0].contents[0]).strip()

      # get cartridge chip info
      for j in range(3, len(chip_info_table.find_all("tr")) - 1):
        cartridgechip = cartchip.CartridgeChip()
        cartridgechip.id = j - 2
        cartridgechip.cartid = i
        if availabletokens["designation"] == 1:
          cartridgechip.designation = str(chip_info_table.find_all("tr")[j].find_all("td")[0].contents[0]).strip()
        if availabletokens["manufacturer"] == 1:
          cartridgechip.manufacturer = str(chip_info_table.find_all("tr")[j].find_all("td")[1].contents[0]).strip()
        if availabletokens["partnumber"] == 1:
          cartridgechip.partnumber = str(chip_info_table.find_all("tr")[j].find_all("td")[2].contents[0]).strip()
        if availabletokens["type"] == 1:
          cartridgechip.type = str(chip_info_table.find_all("tr")[j].find_all("td")[3].contents[0]).strip()
        if availabletokens["package"] == 1:
          cartridgechip.package = str(chip_info_table.find_all("tr")[j].find_all("td")[4].contents[0]).strip()

        # add cartridge chip to list
        cartridgechips.append(cartridgechip)

      # add game to list
      games.append(game)
      # add cartridge to list
      cartridges.append(cartridge)
      # add developer to list
      developers.append(developer)
      # add publisher to list
      publishers.append(publisher)
      # add region to list
      regions.append(region)
      # add producer to list
      producers.append(producer)
    except:
      errorcount += 1
      print("ERROR WITH: " + BASE_URL + URL + str(i))
      print(sys.exc_info())
      traceback.print_tb(sys.exc_info()[2])
      print()
      pass
  
  # write game data to json
  jsonParse = [gObj.to_dict() for gObj in games]
  jsonStr = json.dumps({"games": jsonParse})
  game_file = open("output/games.json", "w")
  n = game_file.write(jsonStr)
  game_file.close()

  # write cartridge data to json
  jsonParse = [cObj.to_dict() for cObj in cartridges]
  jsonStr = json.dumps({"cartridges": jsonParse})
  cartridge_file = open("output/cartridges.json", "w")
  n = cartridge_file.write(jsonStr)
  cartridge_file.close()

  # write cartridge chip data to json
  jsonParse = [ccObj.to_dict() for ccObj in cartridgechips]
  jsonStr = json.dumps({"cartridgechips": jsonParse})
  cartridgechip_file = open("output/cartridgechips.json", "w")
  n = cartridgechip_file.write(jsonStr)
  cartridgechip_file.close()

  # write developer data to json
  jsonParse = [dObj.to_dict() for dObj in developers]
  jsonStr = json.dumps({"developers": jsonParse})
  developers_file = open("output/developers.json", "w")
  n = developers_file.write(jsonStr)
  developers_file.close()

  # write publisher data to json
  jsonParse = [pObj.to_dict() for pObj in publishers]
  jsonStr = json.dumps({"publishers": jsonParse})
  publisher_file = open("output/publishers.json", "w")
  n = publisher_file.write(jsonStr)
  publisher_file.close()

  # write region data to json
  jsonParse = [rObj.to_dict() for rObj in regions]
  jsonStr = json.dumps({"regions": jsonParse})
  region_file = open("output/regions.json", "w")
  n = region_file.write(jsonStr)
  region_file.close()

  # write producer data to json
  jsonParse = [prObj.to_dict() for prObj in producers]
  jsonStr = json.dumps({"producers": jsonParse})
  producer_file = open("output/producers.json", "w")
  n = producer_file.write(jsonStr)
  producer_file.close()

  print(f"Errors: {str(errorcount)}")
  print(f"Unavailable: {str(unavailable)}")

main()
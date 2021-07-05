import sys
import os
import re
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
import pcbmodel as pm

BASE_URL = "http://bootgod.dyndns.org:7777"
CART_URL = "/profile.php?id="
PCB_URL = "/pcb.php?PcbID="


def main(whichScraper):
    start = time.time()
    global games, cartridges, cartridgechips, developers, publishers, regions, producers, pcbs, errors
    games = []
    cartridges = []
    cartridgechips = []
    developers = []
    publishers = []
    regions = []
    producers = []
    pcbs = []
    errors = []

    scrapePCBData = False
    scrapeCartData = False

    if whichScraper == "pcb":
        scrapePCBData = True
    if whichScraper == "cartridge":
        scrapeCartData = True
    if whichScraper == "all":
        scrapePCBData = True
        scrapeCartData = True

    availablecarttokens = dict(
        {
            "catalogentry": 0,
            "cartclass": 0,
            "region": 0,
            "cartclass": 0,
            "releasedate": 0,
            "peripherals": 0,
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
            "package": 0,
        }
    )

    cart_scraped = 0
    cart_errorcount = 0
    cart_unavailable = 0

    pcb_scraped = 0
    pcb_errorcount = 0
    pcb_unavailable = 0

    # make sure the error list is empty
    errors.clear()

    # scrape the PCB data
    if (scrapePCBData == True):
        # loop through pages (650)
        for i in range(1, 650):
            # wait a few seconds so as not to overload the server
            time.sleep(5)

            # where are we in the scrape?
            if (i % 50 == 0):
                print(f"PCBs Scraped: {str(i)}")

            try:
                page = requests.get(BASE_URL + PCB_URL + str(i))
                soup = BeautifulSoup(page.content, "html.parser")
                
                # check if pcb is disabled
                if not soup(text=re.compile('PRG-ROM')):
                    pcb_unavailable += 1
                    print(f"{i} is unavailable")
                    continue

                results = soup.find(id="pcbview")
                rows = results.find_all("tr")

                pcb = pm.PCB()
                pcb.id = i

                manufacturer = rows[0].find("img")
                if manufacturer:
                    pcb.manufacturer = manufacturer.get("title")
                    pcb.manufacturerLogo = BASE_URL + manufacturer.get("src")
                pcb.pcbName = rows[0].find("a").contents[0]
                pcb.pcbNotes = rows[0].find_all("th")[1].contents[0]

                for img in rows[1].find_all("img"):
                    pcb.pcbImages.append(BASE_URL + "/" + img.get("src"))

                pcb.lifeSpan = rows[2].find("td").contents[0].replace("Life Span: ", "")
                pcb.pcbClass = rows[3].find("td").contents[0].replace("PCB Class: ", "")
                pcb.mapper = rows[4].find("td").contents[0]
                pcb.prgRom = rows[5].find("td").contents[0].replace("PRG-ROM: ", "")
                pcb.prgRam = rows[6].find("td").contents[0].replace("PRG-RAM: ", "")
                pcb.chrRom = rows[7].find("td").contents[0].replace("CHR-ROM: ", "")
                pcb.chrRam = rows[8].find("td").contents[0].replace("CHR-RAM: ", "")
                pcb.batteryPresent = rows[9].find("td").contents[0]
                pcb.mirroring = rows[10].find("td").contents[0]
                pcb.cic = rows[11].find("td").contents[0]
                pcb.otherChips = rows[12].find("td").text

                pcbs.append(pcb)
                pcb_scraped += 1
                
            except:
                pcb_errorcount += 1
                errors.append(BASE_URL + PCB_URL + str(i))
                print("ERROR WITH: " + BASE_URL + PCB_URL + str(i))
                print(sys.exc_info())
                traceback.print_tb(sys.exc_info()[2])
                print()
                pass
        
        # make output directory
        if not os.path.exists('output'):
            os.makedirs('output')

        # write errors to file
        pcb_error_file = open("output/ pcb-errors.txt", "w")
        for err in errors:
            pcb_error_file.write(err + "\n")
        pcb_error_file.close()

        # write pcb data to json
        jsonParse = [pObj.to_dict() for pObj in pcbs]
        jsonStr = json.dumps({"pcbs": jsonParse})
        pcb_file = open("output/pcbs.json", "w")
        n = pcb_file.write(jsonStr)
        pcb_file.close()

    # make sure the error list is empty
    errors.clear()
    
    # scrape the cartridge/game data
    if (scrapeCartData == True):
        # loop through pages (5000)
        for i in range(1, 5000):
            # wait a few seconds so as not to overload the server
            time.sleep(5)

            # where are we in the scrape?
            if (i % 50 == 0):
                print(f"Cartridges Scraped: {str(i)}")
            
            # reset token dictionary values to 0
            availablecarttokens = dict.fromkeys(availablecarttokens, 0)

            try:
                page = requests.get(BASE_URL + CART_URL + str(i))
                soup = BeautifulSoup(page.content, "html.parser")

                # check if cart is disabled
                if (
                    soup.find(text=f"Could not find CartID {str(i)} or it is disabled.")
                    is not None
                ):
                    cart_unavailable += 1
                    continue

                # gather data
                # catalogentry, cartclass, region, releasedate, publisher, developer, players
                primary_data_table = soup.find(text="Catalog ID").parent.parent.parent
                if primary_data_table.find(text="Catalog ID") is not None:
                    availablecarttokens["catalogentry"] = 1
                if primary_data_table.find(text="Class") is not None:
                    availablecarttokens["cartclass"] = 1
                if primary_data_table.find(text="Region") is not None:
                    availablecarttokens["region"] = 1
                if primary_data_table.find(text="Release Date") is not None:
                    availablecarttokens["releasedate"] = 1
                if primary_data_table.find(text="Publisher") is not None:
                    availablecarttokens["publisher"] = 1
                if primary_data_table.find(text="Developer") is not None:
                    availablecarttokens["developer"] = 1
                if primary_data_table.find(text="Players") is not None:
                    availablecarttokens["players"] = 1
                if primary_data_table.find(text="Peripherals") is not None:
                    availablecarttokens["peripherals"] = 1

                # producer, color, formfactor, embossedtext, frontlabelentry, sealofquality, mfgstrpresent, backlabelentry, twodigitcode, revision
                cart_data_table = soup.find(text="Cart Properties").parent.parent.parent
                if cart_data_table.find(text="Cart Producer") is not None:
                    availablecarttokens["producer"] = 1
                if cart_data_table.find(text="Color") is not None:
                    availablecarttokens["color"] = 1
                if cart_data_table.find(text="Form Factor") is not None:
                    availablecarttokens["formfactor"] = 1
                if cart_data_table.find(text="Embossed Text") is not None:
                    availablecarttokens["embossedtext"] = 1
                if cart_data_table.find(text="Front Label ID") is not None:
                    availablecarttokens["frontlabelentry"] = 1
                if cart_data_table.find(text="Seal of Quality") is not None:
                    availablecarttokens["sealofquality"] = 1
                if cart_data_table.find(text="MfgString Present") is not None:
                    availablecarttokens["mfgstrpresent"] = 1
                if cart_data_table.find(text="Back Label ID / Desc") is not None:
                    availablecarttokens["backlabelid"] = 1
                if cart_data_table.find(text="Back Label Desc") is not None:
                    availablecarttokens["backlabeldesc"] = 1
                if cart_data_table.find(text="2-digit Code") is not None:
                    availablecarttokens["twodigitcode"] = 1
                if cart_data_table.find(text="Revision") is not None:
                    availablecarttokens["revision"] = 1

                # pcb, cictype, hardware, wram, vram
                rom_data_table = soup.find(text="WRAM").parent.parent.parent
                availablecarttokens["pcb"] = 1
                if rom_data_table.find(text="CIC Type") is not None:
                    availablecarttokens["cictype"] = 1
                if rom_data_table.find(text="Hardware") is not None:
                    availablecarttokens["hardware"] = 1
                if rom_data_table.find(text="WRAM") is not None:
                    availablecarttokens["wram"] = 1
                if rom_data_table.find(text="VRAM") is not None:
                    availablecarttokens["vram"] = 1

                # partnumber, manufacturer, designation, type, package
                if soup.find(text="Designation") is not None:
                    chip_info_table = soup.find(text="Designation").parent.parent.parent
                    if chip_info_table.find(text="Designation") is not None:
                        availablecarttokens["designation"] = 1
                    if chip_info_table.find(text="Part #") is not None:
                        availablecarttokens["partnumber"] = 1
                    if chip_info_table.find(text="Maker") is not None:
                        availablecarttokens["manufacturer"] = 1
                    if chip_info_table.find(text="Type") is not None:
                        availablecarttokens["type"] = 1
                    if chip_info_table.find(text="Package") is not None:
                        availablecarttokens["package"] = 1

                # get game info
                game = gm.Game()
                game.id = i
                game.name = str(
                    soup.find("td", {"class": "headingmain"}).contents[0]
                ).strip()
                if availablecarttokens["cartclass"] == 1:
                    game.cartclass = str(
                        primary_data_table.find(text="Class")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["catalogentry"] == 1:
                    game.catalogentry = str(
                        primary_data_table.find(text="Catalog ID")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["players"] == 1:
                    game.players = str(
                        primary_data_table.find(text="Players")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["peripherals"] == 1:
                    if (
                        len(
                            primary_data_table.find(text="Peripherals")
                            .parent.parent.find_all("td")[0]
                            .find_all("img")
                        )
                        > 0
                    ):
                        game.peripherals = str(
                            primary_data_table.find(text="Peripherals")
                            .parent.parent.find_all("td")[0]
                            .find_all("img")[len(primary_data_table.find(text="Peripherals")
                            .parent.parent.find_all("td")[0]
                            .find_all("img")) - 1]["title"]
                        ).strip()
                        game.peripheralsImage = BASE_URL + str(
                            primary_data_table.find(text="Peripherals")
                            .parent.parent.find_all("td")[0]
                            .find_all("img")[len(primary_data_table.find(text="Peripherals")
                            .parent.parent.find_all("td")[0]
                            .find_all("img")) - 1]["src"]
                        ).strip()
                    else:
                        game.peripherals = str(
                            primary_data_table.find(text="Peripherals")
                            .parent.parent.find_all("td")[0]
                            .contents[0]
                        ).strip()
                    
                if availablecarttokens["releasedate"] == 1:
                    game.releasedate = str(
                        primary_data_table.find(text="Release Date")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()

                # get cartridge info
                cartridge = cart.Cartridge()
                cartridge.id = i
                if availablecarttokens["color"] == 1:
                    cartridge.color = str(
                        cart_data_table.find(text="Color")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["formfactor"] == 1:
                    cartridge.formfactor = str(
                        cart_data_table.find(text="Form Factor")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["embossedtext"] == 1:
                    cartridge.embossedtext = str(
                        cart_data_table.find(text="Embossed Text")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["frontlabelentry"] == 1:
                    cartridge.frontlabelentry = str(
                        cart_data_table.find(text="Front Label ID")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["sealofquality"] == 1:
                    cartridge.sealofquality = str(
                        cart_data_table.find(text="Seal of Quality")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["mfgstrpresent"] == 1:
                    cartridge.mfgstrpresent = str(
                        cart_data_table.find(text="MfgString Present")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["backlabelid"] == 1:
                    cartridge.backlabelentry = str(
                        cart_data_table.find(text="Back Label ID / Desc")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["backlabeldesc"] == 1:
                    cartridge.backlabelentry = str(
                        cart_data_table.find(text="Back Label Desc")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["twodigitcode"] == 1:
                    cartridge.twodigitcode = str(
                        cart_data_table.find(text="2-digit Code")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["revision"] == 1:
                    cartridge.revision = str(
                        cart_data_table.find(text="Revision")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["pcb"] == 1:
                    cartridge.pcb = str(
                        rom_data_table.find_all("tr")[0]
                        .find_all("td")[0]
                        .contents[0]
                        .get_text()
                    ).strip()
                if availablecarttokens["wram"] == 1:
                    cartridge.wram = str(
                        rom_data_table.find(text="WRAM")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["vram"] == 1:
                    cartridge.vram = str(
                        rom_data_table.find(text="VRAM")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["cictype"] == 1:
                    cartridge.cictype = str(
                        rom_data_table.find(text="CIC Type")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()
                if availablecarttokens["hardware"] == 1:
                    cartridge.hardware = str(
                        rom_data_table.find(text="Hardware")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                    ).strip()

                imagelinks = soup.find_all("a", {"class": "myimg"})
                for link in imagelinks:
                    full_url = (BASE_URL + "/" + str(link["href"]).strip()).replace("http://bootgod.dyndns.org:7777/image.php?ImageID=", "http://bootgod.dyndns.org:7777/imagegen.php?width=10000&ImageID=")
                    cartridge.images.append(full_url)

                # get developer info
                developer = dev.Developer()
                developer.id = i
                if availablecarttokens["developer"] == 1:
                    developer.name = str(
                        primary_data_table.find(text="Developer")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                        .get_text()
                    ).strip()

                # get publisher info
                publisher = pub.Publisher()
                publisher.id = i
                if availablecarttokens["publisher"] == 1:
                    publisher.name = str(
                        primary_data_table.find(text="Publisher")
                        .parent.parent.find_all("td")[0]
                        .contents[0]
                        .get_text()
                    ).strip()

                # get region info
                region = rgn.Region()
                region.id = i
                if availablecarttokens["region"] == 1:
                    region.name = str(
                        primary_data_table.find(text="Region")
                        .parent.parent.find_all("td")[0]
                        .contents[0]["title"]
                    ).strip()
                    region.image = BASE_URL + str(
                        primary_data_table.find(text="Region")
                        .parent.parent.find_all("td")[0]
                        .contents[0]["src"]
                    ).strip()

                # get producer info
                producer = pro.Producer()
                producer.id = i
                if availablecarttokens["producer"] == 1:
                    if (
                        len(
                            cart_data_table.find(text="Cart Producer")
                            .parent.parent.find_all("td")[0]
                            .find_all("img")
                        )
                        > 0
                    ):
                        producer.name = str(
                            cart_data_table.find(text="Cart Producer")
                            .parent.parent.find_all("td")[0]
                            .contents[0]["title"]
                        ).strip()
                        producer.image = BASE_URL + str(
                            cart_data_table.find(text="Cart Producer")
                            .parent.parent.find_all("td")[0]
                            .contents[0]["src"]
                        ).strip()
                    else:
                        producer.name = str(
                            cart_data_table.find(text="Cart Producer")
                            .parent.parent.find_all("td")[0]
                            .contents[0]
                        ).strip()

                # get cartridge chip info
                for j in range(3, len(chip_info_table.find_all("tr")) - 1):
                    cartridgechip = cartchip.CartridgeChip()
                    cartridgechip.id = j - 2
                    cartridgechip.cartid = i
                    if availablecarttokens["designation"] == 1:
                        cartridgechip.designation = str(
                            chip_info_table.find_all("tr")[j].find_all("td")[0].contents[0]
                        ).strip().replace("<i>", "").replace("</i>", "")
                    if availablecarttokens["manufacturer"] == 1:
                        if (
                            len(
                                chip_info_table.find_all("tr")[j].find_all("td")[1].find_all("img")
                            )
                            > 0
                        ):
                            cartridgechip.manufacturer = str(
                                chip_info_table.find_all("tr")[j].find_all("td")[1].contents[0]["title"]
                            ).strip()
                            cartridgechip.manufacturerImage = BASE_URL + str(
                                chip_info_table.find_all("tr")[j].find_all("td")[1].contents[0]["src"]
                            ).strip()
                        else:
                            cartridgechip.manufacturer = str(
                                chip_info_table.find_all("tr")[j].find_all("td")[1].contents[0]
                            ).strip()

                    if availablecarttokens["partnumber"] == 1:
                        cartridgechip.partnumber = str(
                            chip_info_table.find_all("tr")[j].find_all("td")[2].contents[0]
                        ).strip().replace("<span class=\"implied\">", "").replace("</span>", "")
                    if availablecarttokens["type"] == 1:
                        cartridgechip.type = str(
                            chip_info_table.find_all("tr")[j].find_all("td")[3].contents[0]
                        ).strip()
                    if availablecarttokens["package"] == 1:
                        cartridgechip.package = str(
                            chip_info_table.find_all("tr")[j].find_all("td")[4].contents[0]
                        ).strip()

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

                cart_scraped += 1
            except:
                cart_errorcount += 1
                errors.append(BASE_URL + CART_URL + str(i))
                print("ERROR WITH: " + BASE_URL + CART_URL + str(i))
                print(sys.exc_info())
                traceback.print_tb(sys.exc_info()[2])
                print()
                pass
        
        # make output directory
        if not os.path.exists('output'):
            os.makedirs('output')

        # write errors to file
        cart_error_file = open("output/cart-errors.txt", "w")
        for err in errors:
            cart_error_file.write(err + "\n")
        cart_error_file.close()

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

    end = time.time()

    if (scrapeCartData == True):
        print(f"Carts Captured: {str(cart_scraped)}")
        print(f"Carts Unavailable: {str(cart_unavailable)}")
        print(f"Carts With Errors: {str(cart_errorcount)}")

    if (scrapeCartData == True):
        print(f"PCBs Captured: {str(pcb_scraped)}")
        print(f"PCBs Unavailable: {str(pcb_unavailable)}")
        print(f"PCBs With Errors: {str(pcb_errorcount)}")

    print(f"Elapsed Time: {str(end - start)}")


if __name__ == "__main__":
    if len(sys.argv) != 2:
        print(f"Usage: python ./sitescraper.py pcb|cartridge|all")
        exit()
    
    main(sys.argv[1])
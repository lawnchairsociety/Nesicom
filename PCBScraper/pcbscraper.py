import requests
from bs4 import BeautifulSoup
import json

#http://bootgod.dyndns.org:7777/profile.php?id=173
BASE_URL = 'http://bootgod.dyndns.org:7777'
URL = '/pcb.php?PcbID='

class PCB:
  def __init__(self):
    self.id = None
    self.manufacturer = None
    self.manufacturerLogo = None
    self.pcbName = None
    self.pcbNotes = None
    self.pcbImages = []
    self.lifeSpan = None
    self.pcbClass = None
    self.mapper = None
    self.prgRom = None
    self.prgRam = None
    self.chrRom = None
    self.chrRam = None
    self.batteryPresent = None
    self.mirroring = None
    self.cic = None
    self.otherChips = []
  
  def to_dict(self):
      return {"id": self.id,
              "manufacturer": self.manufacturer,
              "manufacturerLogo": self.manufacturerLogo,
              "pcbName": self.pcbName,
              "pcbNotes": self.pcbNotes,
              "pcbImages": self.pcbImages,
              "lifeSpan": self.lifeSpan,
              "pcbClass": self.pcbClass,
              "mapper": self.mapper,
              "prgRom": self.prgRom,
              "prgRam": self.prgRam,
              "chrRom": self.chrRom,
              "chrRam": self.chrRam,
              "batteryPresent": self.batteryPresent,
              "mirroring": self.mirroring,
              "cic": self.cic,
              "otherChips": self.otherChips}

def main():
  global pcbs
  pcbs = []

  for i in range(1, 647):
    try:
      print(i)
      pcb = PCB()
      page = requests.get(BASE_URL + URL + str(i))
      soup = BeautifulSoup(page.content, 'html.parser')
      results = soup.find(id='pcbview')
      rows = results.find_all('tr')

      pcb.id = i
      pcb.manufacturer = rows[0].find('img').get('title')
      pcb.manufacturerLogo = BASE_URL + rows[0].find('img').get('src')
      pcb.pcbName = rows[0].find('a').contents[0]
      pcb.pcbNotes = rows[0].find_all('th')[1].contents[0]
      
      for img in rows[1].find_all('img'):
        pcb.pcbImages.append(BASE_URL + "/" + img.get('src'))
      
      pcb.lifeSpan =  rows[2].find('td').contents[0]
      pcb.pcbClass = rows[3].find('td').contents[0]
      pcb.mapper = rows[4].find('td').contents[0]
      pcb.prgRom = rows[5].find('td').contents[0]
      pcb.prgRam = rows[6].find('td').contents[0]
      pcb.chrRom = rows[7].find('td').contents[0]
      pcb.chrRam = rows[8].find('td').contents[0]
      pcb.batteryPresent = rows[9].find('td').contents[0]
      pcb.mirroring = rows[10].find('td').contents[0]
      pcb.cic = rows[11].find('td').contents[0]

      for chips in rows[12].find_all('span'):
        pcb.otherChips.append(chips.contents[0])
      
      pcbs.append(pcb)
    except:
      print("ERROR WITH: " + BASE_URL + URL + str(i))
      pass
  
  jsonParse = [pObj.to_dict() for pObj in pcbs]
  jsonStr = json.dumps({"pcbs": jsonParse})
  pcb_file = open("pcbs.json", "w")
  n = pcb_file.write(jsonStr)
  pcb_file.close()

main()
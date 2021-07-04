class Cartridge:
  def __init__(self):
    self.id = None
    self.color = None
    self.formfactor = None
    self.embossedtext = None
    self.frontlabelentry = None
    self.sealofquality = None
    self.mfgstrpresent = None
    self.backlabelentry = None
    self.twodigitcode = None
    self.revision = None
    self.pcb = None
    self.cictype = None
    self.hardware = None
    self.wram = None
    self.vram = None
    self.images = []

  def to_dict(self):
    return {"id": self.id,
            "color": self.color,
            "formfactor": self.formfactor,
            "embossedtext": self.embossedtext,
            "frontlabelentry": self.frontlabelentry,
            "sealofquality": self.sealofquality,
            "mfgstrpresent": self.mfgstrpresent,
            "backlabelentry": self.backlabelentry,
            "twodigitcode": self.twodigitcode,
            "revision": self.revision,
            "pcb": self.pcb,
            "cictype": self.cictype,
            "hardware": self.hardware,
            "wram": self.wram,
            "vram": self.vram,
            "images": self.images}
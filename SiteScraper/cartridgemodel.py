import json

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
        self.developer = None
        self.publisher = None
        self.region = None
        self.producer = None
        self.game = None
        self.cartridgechips = []

    def toJSON(self):
        return json.dumps(self, default=lambda o: o.__dict__, indent=4)

    def to_dict(self):
        return {
            "id": self.id,
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
            "images": self.images,
            "developer": self.developer,
            "publisher": self.publisher,
            "region": self.region,
            "producer": self.producer,
            "game": self.game,
            "cartridgechips": self.cartridgechips
        }

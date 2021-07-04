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
        self.otherChips = None

    def to_dict(self):
        return {
            "id": self.id,
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
            "otherChips": self.otherChips,
        }

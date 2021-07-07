class CartridgeChip:
    def __init__(self):
        self.partnumber = None
        self.manufacturer = None
        self.manufacturerImage = None
        self.designation = None
        self.type = None
        self.package = None

    def to_dict(self):
        return {
            "partnumber": self.partnumber,
            "manufacturer": self.manufacturer,
            "manufacturerImage": self.manufacturerImage,
            "designation": self.designation,
            "type": self.type,
            "package": self.package,
        }

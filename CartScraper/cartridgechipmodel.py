class CartridgeChip:
    def __init__(self):
        self.id = None
        self.cartid = None
        self.partnumber = None
        self.manufacturer = None
        self.designation = None
        self.type = None
        self.package = None

    def to_dict(self):
        return {
            "id": self.id,
            "cartid": self.cartid,
            "partnumber": self.partnumber,
            "manufacturer": self.manufacturer,
            "designation": self.designation,
            "type": self.type,
            "package": self.package,
        }

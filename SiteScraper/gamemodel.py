class Game:
    def __init__(self):
        self.name = None
        self.cartclass = None
        self.catalogentry = None
        self.players = None
        self.releasedate = None
        self.peripherals = None
        self.peripheralsImage = None
        self.developer = None
        self.publisher = None
        self.region = None

    def to_dict(self):
        return {
            "name": self.name,
            "cartclass": self.cartclass,
            "catalogentry": self.catalogentry,
            "players": self.players,
            "releasedate": self.releasedate,
            "peripherals": self.peripherals,
            "peripheralsImage": self.peripheralsImage,
            "developer": self.developer,
            "publisher": self.publisher,
            "region": self.region
        }

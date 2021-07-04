class Game:
    def __init__(self):
        self.id = None
        self.name = None
        self.cartclass = None
        self.catalogentry = None
        self.players = None
        self.releasedate = None

    def to_dict(self):
        return {
            "id": self.id,
            "name": self.name,
            "cartclass": self.cartclass,
            "catalogentry": self.catalogentry,
            "players": self.players,
            "releasedate": self.releasedate,
        }
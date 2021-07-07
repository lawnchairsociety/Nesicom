class Producer:
    def __init__(self):
        self.name = None
        self.image = None

    def to_dict(self):
        return {"name": self.name, "image": self.image}

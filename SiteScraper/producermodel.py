class Producer:
    def __init__(self):
        self.id = None
        self.name = None

    def to_dict(self):
        return {"id": self.id, "name": self.name}

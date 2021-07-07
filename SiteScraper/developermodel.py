class Developer:
    def __init__(self):
        self.name = None

    def to_dict(self):
        return {"name": self.name}

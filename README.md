# Nesicom

## Overview
This is a scrape of the data on http://bootgod.dyndns.org:7777. I am reorganizing the data into an more scalable database and creating an API for it. The site has the XML for the data available as recently as 2017 but the XML doesn't have all the data that the corresponding pages do so scrapers for the individual games/cartridges, and PCBs are being created.

The project is broken up into the following parts:
- CartDB.API
- CartDB.Database
- CartDB.Parser
- SiteScraper

## Projects
### CartDB.API
- C# Project
- .Net 5
- Serves up an API for querying the data models

### CartDB.Database
- C# Project
- .Net 5
- EF Core Database library for the models created by the Parser and used by the API

### CartDB.Parser
- C# Project
- Parses the CartScraper and PCBScraper JSON data into C# models, makes some adjustments, downloads any images, and outputs SQL insertion files.
- Must copy JSON files from `SiteScraper/output` to `CartDB.Parser/Resources` first

### SiteScraper
- Python Project
- Scrapes http://bootgod.dyndns.org:7777/profile.php?id= from id 1 to 4773 for all of the PCB data
- Scrapes http://bootgod.dyndns.org:7777/pcb.php?PcbID= from id 1 to 647 for all of the PCB data
- Usage: `python .\sitescraper.py <content>` where `<content>` is `pcb`, `cartridge`, or `all`

## Database Design
See [DATABASE.md](DATABASE.md)
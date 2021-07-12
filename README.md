# Nesicom

## Overview
This is a scrape of the data on http://bootgod.dyndns.org:7777. I am reorganizing the data into an more scalable database and creating an API for it. The site has the XML for the data available as recently as 2017 but the XML doesn't have all the data that the corresponding pages do so scrapers for the individual games/cartridges, and PCBs are being created.

The project is broken up into the following parts:
- CartDB.API
- CartDB.Database
- CartDB.Downloader
- CartDB.Frontend
- CartDB.Parser
- SiteScraper

## Projects
### CartDB.API
- C# Web API Project
- .Net 5
- Serves up an API for querying the data models

### CartDB.Database
- C# Library Project
- .Net 5
- EF Core Database library for the models created by the Parser and used by the API
- Requires SQL Server (or SQL Express) and PostgreSQL to be installed locally
- This project was initially written for SQL Server but has since been modified to work with PostgreSQL as well
- To initialize database:
  1. Select `CartDB.Database` in the `Solution Explorer`
  2. Open Package Manager Console and select `CartDB.Database` from the `Default Project` dropdown
  3. Run `Add-Migration InitialCreate -Context NesicomSqlServerContext -OutputDir Migrations\SqlServerMigrations`
  4. Run `Add-Migration InitialCreate -Context NesicomPostgreContext -OutputDir Migrations\PostgreMigrations`
  5. Run `Update-Database -Context NesicomSqlServerContext -Migration InitialCreate`
  6. Run `Update-Database -Context NesicomPostgreContext -Migration InitialCreate`
- If using PostgreSQL, see [this page](https://www.postgresqltutorial.com/postgresql-uuid/) on how to set up UUID generation

### CartDB.Downloader
- C# Console Application Project
- .Net 5
- Scans the database for any image URLs, downloads them, then updates the URL with the new filename.

### CartDB.Frontend
- Web Application Project
- React JS
- Frontend website for the CartDB.API
- To start:
  1. Run `npm install`
  2. Run `npm start`

### CartDB.Parser
- C# Console Application Project
- .Net 5
- Parses the CartScraper and PCBScraper JSON data into C# models, makes some adjustments, downloads any images, and outputs SQL insertion files.

### SiteScraper
- Python Project
- Scrapes http://bootgod.dyndns.org:7777/profile.php?id= from id 1 to 4773 for all of the PCB data
- Scrapes http://bootgod.dyndns.org:7777/pcb.php?PcbID= from id 1 to 647 for all of the PCB data
- Usage: `python .\sitescraper.py <content>` where `<content>` is:
  - `pcb` : gets the PCB data
  - `cartridge` : gets the cartridge data
  - `all` : gets the PCB and cartridge data
- Example: `python .\sitescraper.py all`

## Database Design
See [SQL-DATABASE.md](SQL-DATABASE.md)
See [PGS-DATABASE.md](PGS-DATABASE.md)

## Acknowledgements
Thanks to [RustyCase](https://github.com/RustyCase) and [Davis Templeton](https://github.com/BashfulBandit) for the help with restructuring `CartDB.Parser`
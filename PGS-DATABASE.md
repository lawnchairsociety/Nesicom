# Table: Pcbs

- `Name`: Pcbs
- `Comment`: PCBs used in different carts

## `Primary Key`

- `Columns`: PcbId
- `Cluster`: `false`

## `Indexes[]`
| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| ManufacturerId       | `false`   | `false`  |
| PcbName              | `false`   | `false`  |
| PcbClass             | `false`   | `false`  |
| Mapper               | `false`   | `false`  |
| LifeSpanStart        | `false`   | `false`  |
| LifeSpanEnd          | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`      | `Ref Table`   | `Ref Columns`  | `Options` |
|----------------|---------------|----------------|-----------|
| ManufacturerId | Manufacturers | ManufacturerId |           |

## `Columns[]`

| `Name`         | `Type`                     | `Nullable` | `Default`            | `Comment` |
|----------------|----------------------------|------------|----------------------|-----------|
| PcbId          | uuid                       | `false`    | uuid_generate_v4 ()  |           |
| ManufacturerId | uuid                       | `true`     |                      |           |
| PcbName        | text                       | `false`    |                      |           |
| PcbNotes       | text                       | `true`     |                      |           |
| LifeSpanStart  | timestamp without timezone | `true`     |                      |           |
| LifeSpanEnd    | timestamp without timezone | `true`     |                      |           |
| PcbClass       | text                       | `true`     |                      |           |
| Mapper         | text                       | `true`     |                      |           |
| PrgRom         | text                       | `true`     |                      |           |
| PrgRam         | text                       | `true`     |                      |           |
| ChrRom         | text                       | `true`     |                      |           |
| ChrRam         | text                       | `true`     |                      |           |
| BatteryPresent | integer                    | `false`    | 0                    |           |
| Mirroring      | integer                    | `false`    | 0                    |           |
| CIC            | text                       | `true`     |                      |           |
| OtherChips     | text                       | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Manufacturers

- `Name`: Manufacturers
- `Comment`: Manufacturers of the cart PCBs

## `Primary Key`

- `Columns`: ManufacturerId
- `Cluster`: `false`

## `Indexes[]`
| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| ManufacturerName     | `false`   | `false`  |

## `Columns[]`

| `Name`           | `Type`              | `Nullable` | `Default`            | `Comment` |
|------------------|---------------------|------------|----------------------|-----------|
| ManufacturerId   | uuid                | `false`    | uuid_generate_v4 ()  |           |
| ManufacturerName | text                | `false`    |                      |           |
| Image            | text                | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Games

- `Name`: Games
- `Comment`: NES/Famicom games

## `Primary Key`

- `Columns`: GameId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| GameId               | `false`   | `false`  |
| GameName             | `false`   | `false`  |
| CatalogEntry         | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`    | `Ref Table` | `Ref Columns` | `Options` |
|--------------|-------------|---------------|-----------|
| PublisherId  | Publishers  | PublisherId   |           |
| DeveloperId  | Developers  | DeveloperId   |           |
| RegionId     | Regions     | RegionId      |           |

## `Columns[]`

| `Name`           | `Type`                     | `Nullable` | `Default`            | `Comment` |
|------------------|----------------------------|------------|----------------------|-----------|
| GameId           | uuid                       | `false`    | uuid_generate_v4 ()  |           |
| GameName         | text                       | `false`    |                      |           |
| Class            | text                       | `true`     |                      |           |
| CatalogEntry     | text                       | `false`    |                      |           |
| PublisherId      | uuid                       | `true`     |                      |           |
| DeveloperId      | uuid                       | `true`     |                      |           |
| RegionId         | uuid                       | `true`     |                      |           |
| Players          | integer                    | `true`     |                      |           |
| ReleaseDate      | timestamp without timezone | `true`     |                      |           |
| Peripherals      | text                       | `true`     |                      |           |
| PeripheralsImage | text                       | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Publishers

- `Name`: Publishers
- `Comment`: Publishers of NES/Famicom games

## `Primary Key`

- `Columns`: PublisherId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| PublisherName        | `false`   | `false`  |

## `Columns[]`

| `Name`        | `Type`              | `Nullable` | `Default`            | `Comment` |
|---------------|---------------------|------------|----------------------|-----------|
| PublisherId   | uuid                | `false`    | uuid_generate_v4 ()  |           |
| PublisherName | text                | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Developers

- `Name`: Developers
- `Comment`: Developers of NES/Famicom games

## `Primary Key`

- `Columns`: DeveloperId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| DeveloperName        | `false`   | `false`  |

## `Columns[]`

| `Name`        | `Type`              | `Nullable` | `Default`            | `Comment` |
|---------------|---------------------|------------|----------------------|-----------|
| DeveloperId   | uuid                | `false`    | uuid_generate_v4 ()  |           |
| DeveloperName | text                | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Regions

- `Name`: Regions
- `Comment`: Regions where NES/Famicom games were released

## `Primary Key`

- `Columns`: RegionId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| RegionName           | `false`   | `false`  |

## `Columns[]`

| `Name`       | `Type`              | `Nullable` | `Default`            | `Comment` |
|--------------|---------------------|------------|----------------------|-----------|
| RegionId     | uuid                | `false`    | uuid_generate_v4 ()  |           |
| RegionName   | text                | `false`    |                      |           |
| Image        | text                | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Cartridges

- `Name`: Cartridges
- `Comment`: Cartridges for the NES/Famicom games

## `Primary Key`

- `Columns`: CartridgeId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| FormFactor           | `false`   | `false`  |
| Color                | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`      | `Ref Table`   | `Ref Columns`  | `Options` |
|----------------|---------------|----------------|-----------|
| ManufacturerId | Manufacturers | ManufacturerId |           |
| GameId         | Games         | GameId         |           |
| PcbId          | Pcbs          | PcbId          |           |

## `Columns[]`

| `Name`          | `Type`              | `Nullable` | `Default`            | `Comment` |
|-----------------|---------------------|------------|----------------------|-----------|
| CartridgeId     | uuid                | `false`    | uuid_generate_v4 ()  |           |
| ManufacturerId  | uuid                | `true`     |                      |           |
| GameId          | uuid                | `true`     |                      |           |
| Color           | text                | `true`     |                      |           |
| FormFactor      | text                | `true`     |                      |           |
| EmbossedText    | text                | `true`     |                      |           |
| FrontLabelEntry | text                | `true`     |                      |           |
| SealOfQuality   | text                | `true`     |                      |           |
| MfgStrPresent   | boolean             | `true`     |                      |           |
| BackLabelEntry  | text                | `true`     |                      |           |
| TwoDigitCode    | text                | `true`     |                      |           |
| Revision        | text                | `true`     |                      |           |
| PcbId           | uuid                | `true`     |                      |           |
| CICType         | text                | `true`     |                      |           |
| Hardware        | text                | `true`     |                      |           |
| WRAM            | text                | `true`     |                      |           |
| VRAM            | text                | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: CartridgeChips

- `Name`: CartridgeChips
- `Comment`: Specific chips used in the NES/Famicom cartridges

## `Primary Key`

- `Columns`: CartridgeChipId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| PartNumber           | `false`   | `false`  |
| Designation          | `false`   | `false`  |
| Package              | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`      | `Ref Table`   | `Ref Columns`  | `Options` |
| ---------------|---------------|----------------|-----------|
| ManufacturerId | Manufacturers | ManufacturerId |           |
| CartridgeId    | Cartridges    | CartridgeId    |           |

## `Columns[]`

| `Name`          | `Type`              | `Nullable` | `Default`            | `Comment` |
|-----------------|---------------------|------------|----------------------|-----------|
| CartridgeChipId | uuid                | `false`    | uuid_generate_v4 ()  |           |
| PartNumber      | text                | `false`    |                      |           |
| ManufacturerId  | uuid                | `true`     |                      |           |
| CartridgeId     | uuid                | `true`     |                      |           |
| Designation     | text                | `true`     |                      |           |
| Type            | text                | `true`     |                      |           |
| Package         | text                | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: Images

- `Name`: Images
- `Comment`: Images for all items

## `Primary Key`

- `Columns`: ImageId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| Filename             | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`      | `Ref Table`   | `Ref Columns`  | `Options` |
| ---------------|---------------|----------------|-----------|
| PcbId          | Pcbs          | PcbId          |           |
| CartridgeId    | Cartridges    | CartridgeId    |           |

## `Columns[]`

| `Name`       | `Type`              | `Nullable` | `Default`            | `Comment` |
|--------------|---------------------|------------|----------------------|-----------|
| ImageId      | uuid                | `false`    | uuid_generate_v4 ()  |           |
| Filename     | text                | `false`    |                      |           |
| PcbId        | uuid                | `false`    |                      |           |
| CartridgeId  | uuid                | `false`    |                      |           |
| Primary      | boolean             | `false`    | 0                    |           |
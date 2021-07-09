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

| `Name`         | `Type`              | `Nullable` | `Default`            | `Comment` |
|----------------|---------------------|------------|----------------------|-----------|
| PcbId          | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| ManufacturerId | uniqueidentifier    | `true`     |                      |           |
| PcbName        | nvarchar(max)       | `false`    |                      |           |
| PcbNotes       | nvarchar(max)       | `true`     |                      |           |
| LifeSpanStart  | datetime            | `true`     |                      |           |
| LifeSpanEnd    | datetime            | `true`     |                      |           |
| PcbClass       | nvarchar(max)       | `true`     |                      |           |
| Mapper         | nvarchar(max)       | `true`     |                      |           |
| PrgRom         | nvarchar(max)       | `true`     |                      |           |
| PrgRam         | nvarchar(max)       | `true`     |                      |           |
| ChrRom         | nvarchar(max)       | `true`     |                      |           |
| ChrRam         | nvarchar(max)       | `true`     |                      |           |
| BatteryPresent | int                 | `false`    | 0                    |           |
| Mirroring      | int                 | `false`    | 0                    |           |
| CIC            | nvarchar(max)       | `true`     |                      |           |
| OtherChips     | nvarchar(max)       | `true`     |                      |           |

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
| ManufacturerId   | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| ManufacturerName | nvarchar(max)       | `false`    |                      |           |
| Image            | nvarchar(max)       | `true`     |                      |           |

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

| `Name`           | `Type`              | `Nullable` | `Default`            | `Comment` |
|------------------|---------------------|------------|----------------------|-----------|
| GameId           | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| GameName         | nvarchar(max)       | `false`    |                      |           |
| Class            | nvarchar(max)       | `true`     |                      |           |
| CatalogEntry     | nvarchar(max)       | `false`    |                      |           |
| PublisherId      | uniqueidentifier    | `true`     |                      |           |
| DeveloperId      | uniqueidentifier    | `true`     |                      |           |
| RegionId         | uniqueidentifier    | `true`     |                      |           |
| Players          | int                 | `true`     |                      |           |
| ReleaseDate      | datetime            | `true`     |                      |           |
| Peripherals      | nvarchar(max)       | `true`     |                      |           |
| PeripheralsImage | nvarchar(max)       | `true`     |                      |           |

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
| PublisherId   | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| PublisherName | nvarchar(max)       | `false`    |                      |           |

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
| DeveloperId   | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| DeveloperName | nvarchar(max)       | `false`    |                      |           |

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
| RegionId     | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| RegionName   | nvarchar(max)       | `false`    |                      |           |
| Image        | nvarchar(max)       | `true`     |                      |           |

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
| CartridgeId     | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| ManufacturerId  | uniqueidentifier    | `true`     |                      |           |
| GameId          | uniqueidentifier    | `true`     |                      |           |
| Color           | nvarchar(max)       | `true`     |                      |           |
| FormFactor      | nvarchar(max)       | `true`     |                      |           |
| EmbossedText    | nvarchar(max)       | `true`     |                      |           |
| FrontLabelEntry | nvarchar(max)       | `true`     |                      |           |
| SealOfQuality   | nvarchar(max)       | `true`     |                      |           |
| MfgStrPresent   | bit                 | `true`     |                      |           |
| BackLabelEntry  | nvarchar(max)       | `true`     |                      |           |
| TwoDigitCode    | nvarchar(max)       | `true`     |                      |           |
| Revision        | nvarchar(max)       | `true`     |                      |           |
| PcbId           | uniqueidentifier    | `true`     |                      |           |
| CICType         | nvarchar(max)       | `true`     |                      |           |
| Hardware        | nvarchar(max)       | `true`     |                      |           |
| WRAM            | nvarchar(max)       | `true`     |                      |           |
| VRAM            | nvarchar(max)       | `true`     |                      |           |

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
| CartridgeChipId | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| PartNumber      | nvarchar(max)       | `false`    |                      |           |
| ManufacturerId  | uniqueidentifier    | `true`     |                      |           |
| CartridgeId     | uniqueidentifier    | `true`     |                      |           |
| Designation     | nvarchar(max)       | `true`     |                      |           |
| Type            | nvarchar(max)       | `true`     |                      |           |
| Package         | nvarchar(max)       | `true`     |                      |           |

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
| ImageId      | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| Filename     | nvarchar(max)       | `false`    |                      |           |
| PcbId        | uniqueidentifier    | `false`    |                      |           |
| CartridgeId  | uniqueidentifier    | `false`    |                      |           |
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
| PcbNotes       | nvarchar(max)       | `false`    |                      |           |
| LifeSpanStart  | datetime            | `true`     |                      |           |
| LifeSpanEnd    | datetime            | `true`     |                      |           |
| PcbClass       | nvarchar(max)       | `false`    |                      |           |
| Mapper         | nvarchar(max)       | `false`    |                      |           |
| PrgRom         | nvarchar(max)       | `true`     |                      |           |
| PrgRam         | nvarchar(max)       | `true`     |                      |           |
| ChrRom         | nvarchar(max)       | `true`     |                      |           |
| ChrRam         | nvarchar(max)       | `true`     |                      |           |
| BatteryPresent | int                 | `false`    | 0                    |           |
| Mirroring      | int                 | `false`    | 0                    |           |
| CIC            | nvarchar(max)       | `true`     |                      |           |

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
| Class                | `false`   | `false`  |
| CatalogEntry         | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`    | `Ref Table` | `Ref Columns` | `Options` |
|--------------|-------------|---------------|-----------|
| PublisherId  | Publishers  | PublisherId   |           |
| DeveloperId  | Developers  | DeveloperId   |           |
| RegionId     | Regions     | RegionId      |           |

## `Columns[]`

| `Name`       | `Type`              | `Nullable` | `Default`            | `Comment` |
|--------------|---------------------|------------|----------------------|-----------|
| GameId       | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| GameName     | nvarchar(max)       | `false`    |                      |           |
| Class        | nvarchar(max)       | `false`    |                      |           |
| CatalogEntry | nvarchar(max)       | `true`     |                      |           |
| PublisherId  | uniqueidentifier    | `true`     |                      |           |
| DeveloperId  | uniqueidentifier    | `true`     |                      |           |
| RegionId     | uniqueidentifier    | `true`     |                      |           |
| Players      | int                 | `true`     |                      |           |
| ReleaseDate  | datetime            | `true`     |                      |           |

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
| PcbId          | Pcbs          | PcbId          |           |

## `Columns[]`

| `Name`          | `Type`              | `Nullable` | `Default`            | `Comment` |
|-----------------|---------------------|------------|----------------------|-----------|
| CartridgeId     | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| ManufacturerId  | uniqueidentifier    | `true`     |                      |           |
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

## `Columns[]`

| `Name`          | `Type`              | `Nullable` | `Default`            | `Comment` |
|-----------------|---------------------|------------|----------------------|-----------|
| CartridgeChipId | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| PartNumber      | nvarchar(max)       | `false`    |                      |           |
| ManufacturerId  | uniqueidentifier    | `true`     |                      |           |
| Designation     | nvarchar(max)       | `true`     |                      |           |
| Type            | nvarchar(max)       | `true`     |                      |           |
| Package         | nvarchar(max)       | `true`     |                      |           |

\
&nbsp;
\
&nbsp;

# Table: CartridgeCartridgeChips

- `Name`: CartridgeCartridgeChips
- `Comment`: Joining table of Cartridges to CartridgeChips

## `Primary Key`

- `Columns`: CartridgeCartridgeChipId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`                | `Cluster` | `Unique` |
|--------------------------|-----------|----------|
| CartridgeId              | `false`   | `false`  |
| CartridgeChipId          | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`       | `Ref Table`    | `Ref Columns`   | `Options` |
|-----------------|----------------|-----------------|-----------|
| CartridgeId     | Cartridges     | CartridgeId     |           |
| CartridgeChipId | CartridgeChips | CartridgeChipId |           |

## `Columns[]`

| `Name`                   | `Type`              | `Nullable` | `Default`            | `Comment` |
|--------------------------|---------------------|------------|----------------------|-----------|
| CartridgeCartridgeChipId | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| CartridgeId              | uniqueidentifier    | `false`    |                      |           |
| CartridgeChipId          | uniqueidentifier    | `false`    |                      |           |

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

## `Columns[]`

| `Name`       | `Type`              | `Nullable` | `Default`            | `Comment` |
|--------------|---------------------|------------|----------------------|-----------|
| ImageId      | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| Filename     | nvarchar(max)       | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: CartridgeImages

- `Name`: CartridgeImages
- `Comment`: Joining for Cartridges to Images

## `Primary Key`

- `Columns`: CartridgeImageId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| CartridgeId          | `false`   | `false`  |
| ImageId              | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`       | `Ref Table`    | `Ref Columns`   | `Options` |
|-----------------|----------------|-----------------|-----------|
| CartridgeId     | Cartridges     | CartridgeId     |           |
| ImageId         | Images         | ImageId         |           |

## `Columns[]`

| `Name`           | `Type`              | `Nullable` | `Default`            | `Comment` |
|------------------|---------------------|------------|----------------------|-----------|
| CartridgeImageId | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| CartridgeId      | uniqueidentifier    | `false`    |                      |           |
| ImageId          | uniqueidentifier    | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: PcbImages

- `Name`: PcbImages
- `Comment`: Joining for PCBs to Images

## `Primary Key`

- `Columns`: PcbImageId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| PcbId                | `false`   | `false`  |
| ImageId              | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`       | `Ref Table`    | `Ref Columns`   | `Options` |
|-----------------|----------------|-----------------|-----------|
| PcbId           | Pcbs           | PcbId           |           |
| ImageId         | Images         | ImageId         |           |

## `Columns[]`

| `Name`           | `Type`              | `Nullable` | `Default`            | `Comment` |
|------------------|---------------------|------------|----------------------|-----------|
| PcbImageId       | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| PcbId            | uniqueidentifier    | `false`    |                      |           |
| ImageId          | uniqueidentifier    | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: ManufacturerImages

- `Name`: ManufacturerImages
- `Comment`: Joining for Manufacturers to Images

## `Primary Key`

- `Columns`: ManufacturerImageId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| ManufacturerId       | `false`   | `false`  |
| ImageId              | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`       | `Ref Table`    | `Ref Columns`   | `Options` |
|-----------------|----------------|-----------------|-----------|
| ManufacturerId  | Manufacturers  | ManufacturerId  |           |
| ImageId         | Images         | ImageId         |           |

## `Columns[]`

| `Name`              | `Type`              | `Nullable` | `Default`            | `Comment` |
|---------------------|---------------------|------------|----------------------|-----------|
| ManufacturerImageId | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| ManufacturerId      | uniqueidentifier    | `false`    |                      |           |
| ImageId             | uniqueidentifier    | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: OtherChips

- `Name`: OtherChips
- `Comment`: Other chips found on the PCBs

## `Primary Key`

- `Columns`: OtherChipId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| OtherChipId          | `false`   | `false`  |
| OtherChipName        | `false`   | `false`  |


## `Columns[]`

| `Name`              | `Type`              | `Nullable` | `Default`            | `Comment` |
|---------------------|---------------------|------------|----------------------|-----------|
| OtherChipId         | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| OtherChipName       | nvarchar(max)       | `false`    |                      |           |

\
&nbsp;
\
&nbsp;

# Table: PcbOtherChips

- `Name`: PcbOtherChips
- `Comment`: Joining for Pcbs to OtherChips

## `Primary Key`

- `Columns`: PcbOtherChipId
- `Cluster`: `false`

## `Indexes[]`

| `Columns`            | `Cluster` | `Unique` |
|----------------------|-----------|----------|
| PcbOtherChipId       | `false`   | `false`  |
| PcbId                | `false`   | `false`  |
| OtherChipId          | `false`   | `false`  |

## `Foreign Keys[]`

| `Columns`       | `Ref Table`    | `Ref Columns`   | `Options` |
|-----------------|----------------|-----------------|-----------|
| PcbId           | Pcbs           | PcbId           |           |
| OtherChipId     | OtherChips     | OtherChipId     |           |


## `Columns[]`

| `Name`              | `Type`              | `Nullable` | `Default`            | `Comment` |
|---------------------|---------------------|------------|----------------------|-----------|
| PcbOtherChipId      | uniqueidentifier    | `false`    |  NEWSEQUENTIALID()   |           |
| PcbId               | uniqueidentifier    | `false`    |                      |           |
| OtherChipId         | uniqueidentifier    | `false`    |                      |           |
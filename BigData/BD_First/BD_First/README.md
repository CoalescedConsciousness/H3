# Weatherdata Big Data API
### Version: *1.1.0*
### Author: *Mads Søndergaard*
### Supervisor: *Christian Thygesen*
### Org: *EUC Syd*

---
## Functionality:
### Harvest data from DMI (Danish Meteorological Institute) for the region of Sorø, using WebAPI calls (Service/Controllers/WeatherModelsController.cs)
- /api/WeatherModels fetches a single snapshot dataset using current datetime
- /api/WeatherModels/{int} fetches a number of datasets equal to the number supplied in the URI, spaced 1 hour apart
- /api/WeatherModels/continuous fetches datasets continuously for as long as the program is running.
- /api/WeatherModels/map processes data

### Data is ingested into the IngestModel class, with minimal polishing of said data (Service/WeatherService.cs):
- int ID
- string Data (JSON)
- DateTime Date (the upper boundary of the hourly measurement returned, i.e. the latter of "1/1/2022 18:00 to 1/1/2022 19:00")
- bool UsingTimer (indicates whether the dataset was a snapshot or part of a series of datasets)
- :exclamation: Note that the Data property remains fully intact; the Date property is only extracted at this stage to facilitate local recursive execution of the program.

### The resulting IngestModel objects are subsequently stored in a localised SQL database (Data/BD_FirstContext.cs).
---
## ToDo
- Move certain sensitive information into configuration file.

---
## Known issues:
- Spark not fully operationally; final obstacle appears to be network access based rather than programmatical in nature.

---
---
## Changelog:
### 1.1.0 (Breaking Change):
- Added LTE-method for processing stored (Datalake) data into more comprehensible structured (Warehouse) data
- (BREAKING) No longer uses local SQL; uses (1) a primitive SQLite Database which requires manual integration with (2) Metabase (Docked). Note that Spark is mostly integrated.
- Data is extracted and transformed in WeatherService.cs
- Visualization and Dashboarding is carried out via Metabase


### 1.0.1.:
- Added example of Data Query Layer; simple extraction and aggregation of datasets based on Date property using LINQ.


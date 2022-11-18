# Weatherdata Big Data API
### Author: Mads Søndergaard
### Org: EUC Syd
### Supervisor: Christian Thygesen
### Version: 1.0.0
---
## Functionality:
### Harvest data from DMI (Danish Meteorological Institute) for the region of Sorø, using WebAPI calls (Service/Controllers/WeatherModelsController.cs)
- /api/WeatherModels fetches a single snapshot dataset using current datetime
- /api/WeatherModels/{int} fetches a number of datasets equal to the number supplied in the URI, spaced 1 hour apart
- /api/WeatherModels/continuous fetches datasets continuously for as long as the program is running.

### Data is ingested into the IngestModel class, with minimal polishing of the class used to store said data (Service/WeatherService.cs):
- int ID
- string Data (JSON)
- DateTime Date (the upper boundary of the hourly measurement returned, i.e. the latter of "1/1/2022 18:00 to 1/1/2022 19:00")
- bool UsingTimer (indicates whether the dataset was a snapshot or part of a series of datasets)
:exclamation: Note that the Data property remains fully intact; the Date property is only extracted at this stage to facilitate local recursive execution of the program.

### The resulting IngestModel objects are subsequently stored in a localised SQL database (Data/BD_FirstContext.cs).
---
## ToDo
- Add greater granular resolution of data, i.e. parse IngestModel objects to more useful WeatherModel objects (template for latter already exists, but tentatively).
- Add visualization of resulting aggregated and scrubbed data.
---
## Known issues:
- Spark implementation is currently incomplete, but is otherwise also unnecessary at the current stage. Code is thus present but commented out for the time being.
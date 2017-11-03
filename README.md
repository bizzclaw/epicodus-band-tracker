# Band Tracker
Joseph Tomlinson

This web page can be used to keep track of what bands have played at what venues.

Bands and venues can be added to a list and bands can be logged as having played at that venue.

Information is stored in a MySQL database

## Requirements
* #### MySQL Server using [MAMP](https://www.mamp.info/en/) or [MySQL Community](https://dev.mysql.com/downloads/mysql/)
* #### .NET Framework [v1.1](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg)
* #### .NET [runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg)




## Instructions
Clone with git or download as a zip file and extract to a directory on your machine.

##### Sql Setup
In order to load the proper information into a database, some tables must be created.
You can create these tables by entering the following MySQL commands into your Sql
Server


``` SQL
CREATE DATABASE band_trakcer;
USE DATABASE band_trakcer;

CREATE TABLE bands (id SERIAL, name VARCHAR(255));
CREATE TABLE venues (id SERIAL, name VARCHAR(255));
CREATE TABLE bands_venues (band_id INT, venue_id INT)
```

If you wish to perform your own tests, use the following:

``` SQL
CREATE DATABASE band_trakcer_test;
USE DATABASE band_trakcer_test;

CREATE TABLE bands (id SERIAL, name VARCHAR(255));
CREATE TABLE venues (id SERIAL, name VARCHAR(255));
CREATE TABLE bands_venues (band_id INT, venue_id INT)
```
###### (Pretty much the same thing, except with a database called "test")

## Specifications


| Specificiation                             | Example Input                          | Example Output                                                                                                   |
|--------------------------------------------|----------------------------------------|------------------------------------------------------------------------------------------------------------------|
| User can create a band                     | A button called "Add Band" is clicked  | A form for entering the name is opened, after it is entered, the band is now displayed on the bands list.        |
| User Can create a venue                    | A button called "Add Venue" is clicked | A Form for entering the name of the venue opens, after it is entered, the venue is displayed on a list of venues |
| Bands can be added as "played" at a venue. | A button called "Add Band" is clicked  | A list of all bands are displayed, clicking one will add it to the list of played bands for that venue.          |


##### This app makes use of the following frameworks/libraries:
* Bootstrap
* Dotnet

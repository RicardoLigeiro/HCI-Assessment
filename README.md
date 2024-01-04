Project done in .Net Core 8

In all the projects the folders that start with "_" are NOT namespace provider. I created those taht way so the project structure can be more readable.


The project is devided in solutions folders to split project types

Hci.Models
Contains a basic model just to show enough code in the UI.

Hci.Services
We could have split in 2 projects (Repository and Services or even in a new one Database) 

Hci.WebApi

NOTE: on the appsettings.json, change the path for the sql server
      Then in viaual studio, open a window Package Manager Console and run the command: Update-Database
      Verify that in the program.cs line 13 also change the correct port where is the react app using

hci-app
  Uses Axio, Bootstrap

NOTE: If you are getting connection refused change the file services/api-client.ts for the correct port number where the api is using
  

# EBO.CodingTask.API

.Net 4.7.2 Web API application  

Runs on localhost:44316 (default).  

Download and Restore Nuget Packages.  

Entity Framework 6 (with Code-First approach) is used to manipulate data.  

Automatically created database .mdf and .ldf files are in App_Data folder.  

Creation codes of Database & Tables (Primary-Foreign Keys) is in Migration/202110152053573_Initial.cs class.  

Initial table data is created in Migration/Configuration.cs class.  

Run "Update-Database" on Nuget PM console to re-create DB.  

Unit test project is EBO.CodingTask.API.Tests (MSTest project). (In-memory data sources used in unit tests)  

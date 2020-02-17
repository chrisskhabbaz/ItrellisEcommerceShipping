The coode is written in C#.
It is .net Core.
It has code to run in IIS. If in Cloud, Code line must be commented out.(Program.cs Line 41).
To ensure correct database connection, the connection string is found in 2 places:
Those needs to be replaced, and then the code will run and create the DB and seed it automatically.
The files are appsettings.json in both api and web projects.
Unit tests cover api and domain.
project can be run as web only as a startup project and the gui should show. It is either in Visual studio debug mode or deployed to IIS via deploy to iis in vs.
The api is exposed via swagger for testing purposes.

The solution is created in a micro service architecture.
The only change that needs to be done to make this complete is to host the API in iis,
and call the method using AJAX from the gui Javascript or using c# as a backend call to an api to avoid CORS
in case there are different domains and this way the gui will not be dependent on the business layer, it will be calling th api instead.

Current setup is the gui is calling the business layer for its information.

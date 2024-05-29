CrayonCloudSales 

Introduction
CrayoinCloudSales API is a RESTful API built with .NET Core 6.0 for managing a collection of items. It includes JWT authentication and Swagger for API documentation.
It uses external service by service layer and CrayonCloudSales.DataAccess for manipulation with database entites.

CrayonCloudSales.DataAccess is project for creating and seeding database and do all manipulations with EntityFrameforkCore 6.0.

CCPService is simulation of real external API that main project use to get info about avaliable services. 

Features
CRUD operations for items
JWT Authentication
Swagger Documentation

Prerequisites
.NET 6.0
SQL Server or LocalDB

Installation
1. Clone the repository:
git clone https://github.com/tcesic/CrayonCloudSales.git
cd CrayonCloudSales
2. Restore dependencies
3. Set up the database:
Update connection string in appsettings.json in main project and database with some mocked data would be created first time you run the app (Code First Approach)
"ConnectionStrings": {
  "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CrayonCloudSales;Integrated Security=True"
}
4. There is Credentials class for secret, username and password in purpose of testing this case (for production database, hashed or some secret manager)
5. Run the main project (set up to run https://localhost:7147 if busy you can change to port you want to use in launchSettings.json of main project)
6. Run the CCP Service project (set up to run https://localhost:7061/ if busy you can change to port you want to use in launchSettings.json of this project and in that case change url of this service in
   app.settings of main project)
     "CcpServiceBaseUrl": "https://localhost:7061", 
8. Use the main project APIs
9. First you need to authenticate POST /api/Auth/login - provide username and password from mentioned Credentials class and then when you got token you can autenticate to swagger autorize
10. Use APIs


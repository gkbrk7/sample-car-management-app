# sample-car-management-app

A sample template of car management app for basic operations

# Technologies and Libraries

- This application is designed by clean architecture principle by applying Onion architecture which consists of four different layers namely domain, infrastructure, application and presentation (webapi). They allows application to have better physical and logical isolation and it helps to separate cross-cutting concerns easily.
- MSSQLServer is used for persistency to store all the application specific data. In this application, vehicles table is the only table and all the pre-generated data is being used to insert into database through the SQL script under scripts folder at root directory.
- Global error and exception handling are adapted for this application by using FluentValidation and MediatR libraries.
- FluentValidation is also used for validating the incoming requests based on business logic.
- The application utilizes the MediatR features to distinguish both queries and commands to be able to support better scalability, extensibility and robustness.
- Built-in swagger documentation and api versioning are supported for controlling new version of controllers.
- Moq, FluentAssertions and xUnit are utilized for testing purposes and most of the business logic is covered by unit tests.

# Quick Start

- Please ensure that postgres is running somewhere to be able to access it through the application. Modify appsettings.Development.json for connection string and navigate to the SampleCarManagementApp.WebApi folder and then apply migrations by using this command. (Please note that dotnet-ef should be globally installed in local machine to run this command):

```
dotnet ef database update --project ../SampleCarManagementApp.Infrastructure
```

- To run the applications, following commands can be used under the SampleCarManagementApp.WebApi folder

```
dotnet run
dotnet watch
```

# Scripts

- One can run the mssqlserver in local environment with the help of docker images so just run the below command to run mssqlserver container in local environment for testing purposes.

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD={PASSWORD_HERE}' -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server
```

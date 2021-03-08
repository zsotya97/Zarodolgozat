@echo off
if not exist "DataBase" md "DataBase"
dotnet ef migrations add Noveny -c NovenyContext
dotnet ef migrations add Projekt -c ProjektContext
dotnet ef database update -c ProjektContext
dotnet ef database update -c NovenyContext


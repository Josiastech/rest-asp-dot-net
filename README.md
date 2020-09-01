#### Use with ASP.NET Core Web API

Basic ASP.NET Core JSON API application that performs CRUD operations on blog posts.

Create the folder project

```cmd
C:\ BlogPostApi
```
Initialize project
```cmd
dotnet new webapi
```
Add the MySql connecto package
```cmd
dotnet add package MySqlConnector
```

Verify the build
```
dotnet run
```

Update Configuration Files
appsettings.json holds .NET Core logging levels and the ADO.NET Connection String:

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft": "Warning",
            "Microsoft.Hosting.Lifetime": "Information"
        }
    },
    "ConnectionStrings": {
        "DefaultConnection": "server=127.0.0.1;user id=root;password=pass;port=3306;database=blog;"
    }
}
```


##### .NET Core Startup
Startup.cs contains runtime configuration and framework services. Add this call to ConfigureServices to make an instance of AppDb available to controller methods.

```c#
services.AddTransient<AppDb>(_ => new AppDb(Configuration["ConnectionStrings:DefaultConnection"]));
```
Now our app is configured and we can focus on writing the core functionality!
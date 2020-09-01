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

### Adding Swagger
```
dotnet add package Swashbuckle --version 5.6.0
```

Add configuration to work with *OpenAPI*
```c#
using Microsoft.OpenApi.Models;
```

Add configuration in *Startup.cs*
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    AddSwagger(services);
}

private void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        var groupName = "v1";

        options.SwaggerDoc(groupName, new OpenApiInfo
        {
            Title = $"Foo {groupName}",
            Version = groupName,
            Description = "Foo API",
            Contact = new OpenApiContact
            {
                Name = "Foo Company",
                Email = string.Empty,
                Url = new Uri("https://foo.com/"),
            }
        });
    });
}
```

Also `configure` method should be updated
```c#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
    });

    app.UseRouting();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

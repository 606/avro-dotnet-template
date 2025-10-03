# Avro .NET 10 Web API Template

A production-ready .NET 10 Web API template for building modern backend applications. This template follows Microsoft's official guidelines and best practices, providing a solid foundation for your next project.

## Features

- ✅ .NET 10 targeting (`net10.0`)
- ✅ Modern minimal hosting pattern
- ✅ File-scoped namespaces (C# 10+)
- ✅ Nullable reference types enabled
- ✅ Swagger/OpenAPI documentation (optional)
- ✅ Health checks endpoint (optional)
- ✅ Structured project organization (Models, Services, Repositories, Extensions)
- ✅ Sample Weather API controller
- ✅ Dependency injection setup
- ✅ Environment-based configuration (Development/Production)
- ✅ EditorConfig for consistent code style
- ✅ Comprehensive .gitignore for .NET projects

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- A code editor (Visual Studio, VS Code, or Rider)

## Installation

### Install the Template

To install this template locally, navigate to the repository directory and run:

```bash
dotnet new install .
```

This will register the template with your local .NET CLI.

### Verify Installation

Check that the template is installed:

```bash
dotnet new list
```

You should see `avro-dotnet10` in the list of available templates.

## Usage

### Create a New Project

To create a new project from this template:

```bash
dotnet new avro-dotnet10 -n MyAwesomeApi
```

This creates a new project named `MyAwesomeApi` with the default settings.

### Customize with Parameters

The template supports several parameters for customization:

```bash
dotnet new avro-dotnet10 -n MyApi \
  --CompanyName "Contoso" \
  --HttpPort 8080 \
  --HttpsPort 8443 \
  --EnableSwagger true \
  --EnableHealthChecks true
```

### Available Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `CompanyName` | string | `Company1` | The name of your company/organization |
| `HttpPort` | integer | `5000` | Port number for HTTP |
| `HttpsPort` | integer | `5001` | Port number for HTTPS |
| `EnableSwagger` | bool | `true` | Enable Swagger/OpenAPI documentation |
| `EnableHealthChecks` | bool | `true` | Enable health check endpoints |

### Example Commands

**Basic project with defaults:**
```bash
dotnet new avro-dotnet10 -n MyApi
```

**Custom company name:**
```bash
dotnet new avro-dotnet10 -n MyApi --CompanyName Acme
```

**Custom ports:**
```bash
dotnet new avro-dotnet10 -n MyApi --HttpPort 8080 --HttpsPort 8443
```

**Without Swagger:**
```bash
dotnet new avro-dotnet10 -n MyApi --EnableSwagger false
```

## Project Structure

After creating a project, you'll have the following structure:

```
MyApi/
├── src/
│   └── AvroDotNet.MyApi/
│       ├── Controllers/
│       │   └── WeatherForecastController.cs
│       ├── Extensions/
│       │   ├── ServiceCollectionExtensions.cs
│       │   └── SwaggerExtensions.cs (if Swagger enabled)
│       ├── Models/
│       │   └── WeatherForecast.cs
│       ├── Repositories/
│       │   └── IRepository.cs
│       ├── Services/
│       │   ├── IWeatherService.cs
│       │   └── WeatherService.cs
│       ├── appsettings.json
│       ├── appsettings.Development.json
│       ├── AvroDotNet.MyApi.csproj
│       └── Program.cs
├── .editorconfig
├── .gitignore
└── README.md
```

## Running the Project

After creating your project:

1. Navigate to the project directory:
   ```bash
   cd MyApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   cd src/AvroDotNet.MyApi
   dotnet run
   ```

4. Access the API:
   - Swagger UI (if enabled): `https://localhost:5001/swagger`
   - Weather API: `https://localhost:5001/api/weatherforecast`
   - Health Check (if enabled): `https://localhost:5001/health`

## Development

### Adding New Services

1. Create your service interface in `Services/IYourService.cs`
2. Implement the service in `Services/YourService.cs`
3. Register the service in `Extensions/ServiceCollectionExtensions.cs`:
   ```csharp
   services.AddScoped<IYourService, YourService>();
   ```

### Adding New Controllers

1. Create a new controller in the `Controllers/` directory
2. Inherit from `ControllerBase`
3. Add the `[ApiController]` and `[Route]` attributes
4. Inject dependencies via constructor

### Configuration

- Development settings: `appsettings.Development.json`
- Production settings: `appsettings.json`
- Environment-specific configuration is loaded automatically

## Uninstalling the Template

To remove this template from your system:

```bash
dotnet new uninstall AvroDotNet.Template.WebAPI.10
```

Or specify the path where the template was installed:

```bash
dotnet new uninstall /path/to/avro-dotnet-template
```

## Best Practices

This template follows modern .NET best practices:

- **File-scoped namespaces**: Reduces indentation and improves readability
- **Nullable reference types**: Helps prevent null reference exceptions
- **Minimal hosting**: Uses the modern minimal hosting model
- **Dependency injection**: Promotes loose coupling and testability
- **Configuration management**: Environment-based configuration
- **API documentation**: Swagger/OpenAPI for easy API exploration
- **Health checks**: Monitor application health
- **Structured logging**: Built-in logging infrastructure

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For issues, questions, or contributions, please visit the [GitHub repository](https://github.com/606/avro-dotnet-template).

---

**Happy coding! 🚀**
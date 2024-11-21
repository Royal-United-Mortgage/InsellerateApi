# Insellerate API Client

This project provides a client for interacting with the Insellerate API. It includes methods for performing various operations such as searching, changing status, testing connections, and posting leads.

## Getting Started

### Installing the Package

```shell 
donet add source https://nuget.pkg.github.com/Royal-United-Mortgage/index.json -n github
dotnet add package InsellerateApi
```

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)
- [Git](https://git-scm.com/)

### Installation

1. **Clone the repository:**

    ```shell
    git clone https://github.com/your-repo/insellerate-api-client.git
    cd insellerate-api-client
    ```

2. **Restore NuGet packages:**

    ```shell
    dotnet restore
    ```

3. **Build the solution:**

    ```shell
    dotnet build
    ```

### Configuration

Create an `appsettings.json` file in the root of your project with the following structure:

```json
{
  "Insellerate": {
    "BaseUrl": "https://api.insellerate.com",
    "Username": "your-username",
    "Password": "your-password",
    "OrgId": "your-org-id",
    "LmbUrl": "Optional Lead Provider URL",
    "LmbUsername": "Optional Lead Provider Username",
    "LmbPassword": "Optional Lead Provider Password"
  }
}
```

### Usage

1. **Register the Insellerate API client in your `Startup.cs` or `Program.cs`:**

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInsellerateApiClient(Configuration, Logger);
    }
    ```

2. **Inject and use the `IInsellerateApiClient` in your services or controllers:**

    ```csharp
    public class MyService
    {
        private readonly IInsellerateApiClient _insellerateApiClient;

        public MyService(IInsellerateApiClient insellerateApiClient)
        {
            _insellerateApiClient = insellerateApiClient;
        }

        public async Task PerformOperationAsync()
        {
            var response = await _insellerateApiClient.IQLSearchAsync(queryBuilder, selectFields);
            // Handle the response
        }
    }
    ```

### Running Tests

To run the tests, use the following command:

```shell
dotnet test
```

### Continuous Integration

This project uses GitHub Actions for continuous integration. The workflow is defined in `.github/workflows/ci.yml`.

This workflow builds the project and generates a NuGet package on every push to the `main` branch. The package is then published to GitHub Packages.
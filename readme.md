# InsellerateApi

## Overview

InsellerateApi is a .NET 8.0 library that provides a comprehensive client for interacting with the Insellerate CRM API system. This library is specifically designed for Royal United Mortgage's lead management and customer relationship management workflows, offering robust API integration capabilities for lead processing, status management, and data synchronization.

## Purpose

Insellerate serves as Royal United Mortgage's primary CRM system for managing leads, prospects, and customer interactions. This API client library enables seamless integration between internal applications and the Insellerate platform, facilitating automated lead processing, status updates, and comprehensive customer data management.

## Key Features

### Core Functionality
- **IQL (Insellerate Query Language) Search**: Advanced querying capabilities with custom query builders
- **Lead Management**: Complete CRUD operations for lead data
- **Status Management**: Automated lead status updates and transitions
- **DNC (Do Not Contact) Integration**: Compliance management and contact restrictions
- **Multi-Provider Support**: Support for multiple lead provider integrations
- **Connection Testing**: Built-in connectivity and health check capabilities

### Enterprise Features
- **Dependency Injection**: Full Microsoft.Extensions.DependencyInjection support
- **Configuration Management**: IOptions pattern integration
- **Structured Logging**: Microsoft.Extensions.Logging integration
- **HTTP Client Management**: Optimized HttpClient usage with proper disposal
- **Async/Await Support**: Complete asynchronous API coverage
- **Error Handling**: Comprehensive exception handling and error recovery

## Technology Stack

- **.NET 8.0**: Latest .NET framework with performance optimizations
- **Microsoft.Extensions.Http**: HttpClient factory pattern implementation
- **Microsoft.Extensions.Configuration**: Configuration binding and management
- **Microsoft.Extensions.Logging**: Structured logging and diagnostics
- **Microsoft.Extensions.Options**: Configuration options pattern
- **System.Text.Json**: High-performance JSON serialization

## Project Structure

```
InsellerateApi/
├── InsellerateApi/              # Core library source code
│   ├── Extensions/             # Service registration extensions
│   │   └── InsellerateServiceExtension.cs
│   ├── Models/                 # Data models and DTOs
│   │   ├── DNCInsellerateLeadsRequest.cs
│   │   ├── DNCInsellerateLeadsResponse.cs
│   │   ├── IQLQueryBuilder.cs
│   │   ├── IQLSearchResponse.cs
│   │   ├── InsellerateField.cs
│   │   ├── InsellerateStatus.cs
│   │   ├── LeadPostRequest.cs
│   │   ├── LeadPostResult.cs
│   │   ├── LmbLeadRequest.cs
│   │   └── StatusChangeResult.cs
│   ├── Services/               # Core service implementations
│   │   ├── IInsellerateApiClient.cs
│   │   ├── InsellerateApiClientClient.cs
│   │   └── InsellerateConfig.cs
│   └── InsellerateApi.csproj  # Project configuration
├── InsellerateApi.sln         # Solution file
└── README.md                  # This file
```

## Prerequisites

- .NET 8.0 SDK or later
- Valid Insellerate API credentials
- Network access to Insellerate API endpoints
- Microsoft.Extensions.DependencyInjection container

## Installation

### NuGet Package (GitHub Packages)
```bash
# Add GitHub Packages as a source
dotnet nuget add source https://nuget.pkg.github.com/Royal-United-Mortgage/index.json -n github

# Install the package
dotnet add package InsellerateApi
```

### From Source
```bash
# Clone the repository
git clone https://github.com/Royal-United-Mortgage/InsellerateApi.git
cd InsellerateApi

# Restore dependencies
dotnet restore

# Build the solution
dotnet build --configuration Release
```

## Configuration

### Application Settings
Configure the Insellerate API settings in your `appsettings.json`:

```json
{
  "Insellerate": {
    "BaseUrl": "https://api.insellerate.com",
    "Username": "your-username",
    "Password": "your-password",
    "OrgId": "your-organization-id",
    "LmbUsername": "lmb-username",
    "LmbPassword": "lmb-password",
    "LeadProviderInformation": [
      {
        "Name": "LeadProvider1",
        "Url": "https://provider1.api.endpoint.com",
        "Username": "provider1-username",
        "Password": "provider1-password"
      },
      {
        "Name": "LeadProvider2", 
        "Url": "https://provider2.api.endpoint.com",
        "Username": "provider2-username",
        "Password": "provider2-password"
      }
    ]
  }
}
```

### User Secrets (Development)
For local development, use user secrets to store sensitive configuration:

```bash
dotnet user-secrets init
dotnet user-secrets set "Insellerate:Username" "your-username"
dotnet user-secrets set "Insellerate:Password" "your-password"
dotnet user-secrets set "Insellerate:OrgId" "your-org-id"
```

## Setup and Integration

### 1. Service Registration

Register the Insellerate API client in your dependency injection container:

```csharp
// Program.cs (Minimal API)
var builder = WebApplication.CreateBuilder(args);

// Register Insellerate API client
builder.Services.AddInsellerateApiClient(builder.Configuration, builder.Logging);

var app = builder.Build();
```

```csharp
// Startup.cs (Traditional)
public void ConfigureServices(IServiceCollection services)
{
    services.AddInsellerateApiClient(Configuration, Logger);
}
```

### 2. Dependency Injection Usage

Inject and use the client in your services:

```csharp
public class LeadProcessingService
{
    private readonly IInsellerateApiClient _insellerateClient;
    private readonly ILogger<LeadProcessingService> _logger;

    public LeadProcessingService(
        IInsellerateApiClient insellerateClient,
        ILogger<LeadProcessingService> logger)
    {
        _insellerateClient = insellerateClient;
        _logger = logger;
    }

    public async Task<IQLSearchResponse> SearchLeadsAsync(string criteria)
    {
        var queryBuilder = new IQLQueryBuilder()
            .Where("Status", "Active")
            .Where("Created", ">", DateTime.Today.AddDays(-30));

        var selectFields = new[] { "Id", "FirstName", "LastName", "Email", "Phone" };
        
        return await _insellerateClient.IQLSearchAsync(queryBuilder, selectFields);
    }
}
```

## Usage Examples

### IQL Search Operations

#### Basic Search
```csharp
public async Task<IQLSearchResponse> GetActiveLeadsAsync()
{
    var queryBuilder = new IQLQueryBuilder()
        .Where("Status", "Active")
        .OrderBy("Created", "DESC")
        .Limit(100);

    var fields = new[] { "Id", "FirstName", "LastName", "Email", "Phone", "Status" };
    
    return await _insellerateClient.IQLSearchAsync(queryBuilder, fields);
}
```

#### Advanced Search with Multiple Conditions
```csharp
public async Task<IQLSearchResponse> GetRecentHighValueLeadsAsync()
{
    var queryBuilder = new IQLQueryBuilder()
        .Where("Status", "Active")
        .Where("LoanAmount", ">", 500000)
        .Where("Created", ">", DateTime.Today.AddDays(-7))
        .Where("LeadSource", "IN", new[] { "Website", "Referral" })
        .OrderBy("LoanAmount", "DESC");

    var fields = new[] { 
        "Id", "FirstName", "LastName", "Email", "Phone", 
        "LoanAmount", "LeadSource", "Created", "Status" 
    };
    
    return await _insellerateClient.IQLSearchAsync(queryBuilder, fields);
}
```

### Lead Management

#### Create New Lead
```csharp
public async Task<LeadPostResult> CreateLeadAsync(LeadPostRequest leadData)
{
    return await _insellerateClient.PostLeadAsync(leadData);
}
```

#### Update Lead Status
```csharp
public async Task<StatusChangeResult> UpdateLeadStatusAsync(string leadId, string newStatus)
{
    return await _insellerateClient.ChangeStatusAsync(leadId, newStatus);
}
```

### DNC (Do Not Contact) Management

#### Mark Leads as DNC
```csharp
public async Task<DNCInsellerateLeadsResponse> MarkLeadsAsDNCAsync(List<string> leadIds)
{
    var request = new DNCInsellerateLeadsRequest
    {
        LeadIds = leadIds,
        Reason = "Customer Request",
        Notes = "Customer requested to be removed from contact list"
    };

    return await _insellerateClient.DNCInsellerateLeadsAsync(request);
}
```

### Connection Testing

#### Test API Connectivity
```csharp
public async Task<bool> TestConnectionAsync()
{
    try
    {
        return await _insellerateClient.TestConnectionAsync();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Failed to connect to Insellerate API");
        return false;
    }
}
```

## API Methods Reference

### IInsellerateApiClient Interface

| Method | Description | Parameters | Returns |
|--------|-------------|------------|---------|
| `IQLSearchAsync` | Execute IQL search query | `IQLQueryBuilder`, `string[]` | `IQLSearchResponse` |
| `PostLeadAsync` | Create or update lead | `LeadPostRequest` | `LeadPostResult` |
| `ChangeStatusAsync` | Update lead status | `string`, `string` | `StatusChangeResult` |
| `DNCInsellerateLeadsAsync` | Mark leads as DNC | `DNCInsellerateLeadsRequest` | `DNCInsellerateLeadsResponse` |
| `TestConnectionAsync` | Test API connectivity | None | `bool` |

### IQLQueryBuilder Methods

| Method | Description | Example |
|--------|-------------|---------|
| `Where(field, value)` | Add equality condition | `.Where("Status", "Active")` |
| `Where(field, operator, value)` | Add condition with operator | `.Where("Created", ">", DateTime.Today)` |
| `OrderBy(field, direction)` | Add sorting | `.OrderBy("Created", "DESC")` |
| `Limit(count)` | Limit results | `.Limit(100)` |
| `Offset(count)` | Skip results | `.Offset(50)` |

## Error Handling

### Exception Types
The library provides specific exception handling for common scenarios:

```csharp
try
{
    var result = await _insellerateClient.IQLSearchAsync(queryBuilder, fields);
}
catch (HttpRequestException ex)
{
    _logger.LogError(ex, "Network error communicating with Insellerate API");
    // Handle network errors
}
catch (ArgumentException ex)
{
    _logger.LogError(ex, "Invalid parameters provided to Insellerate API");
    // Handle parameter validation errors
}
catch (InvalidOperationException ex)
{
    _logger.LogError(ex, "Invalid operation state for Insellerate API call");
    // Handle state-related errors
}
catch (Exception ex)
{
    _logger.LogError(ex, "Unexpected error in Insellerate API operation");
    // Handle unexpected errors
}
```

### Retry Logic
Implement retry logic for transient failures:

```csharp
public async Task<IQLSearchResponse> SearchWithRetryAsync(IQLQueryBuilder query, string[] fields)
{
    var retryCount = 3;
    var delay = TimeSpan.FromSeconds(1);

    for (int i = 0; i < retryCount; i++)
    {
        try
        {
            return await _insellerateClient.IQLSearchAsync(query, fields);
        }
        catch (HttpRequestException) when (i < retryCount - 1)
        {
            _logger.LogWarning("Insellerate API call failed, retrying in {Delay}ms", delay.TotalMilliseconds);
            await Task.Delay(delay);
            delay = TimeSpan.FromMilliseconds(delay.TotalMilliseconds * 2); // Exponential backoff
        }
    }

    throw new InvalidOperationException("Failed to connect to Insellerate API after multiple attempts");
}
```

## Testing

### Unit Tests
```bash
dotnet test
```

### Integration Tests
Create integration tests using the TestHost pattern:

```csharp
[Test]
public async Task TestInsellerateConnection()
{
    // Arrange
    var client = _serviceProvider.GetRequiredService<IInsellerateApiClient>();

    // Act
    var isConnected = await client.TestConnectionAsync();

    // Assert
    Assert.IsTrue(isConnected);
}
```

## Performance Considerations

### Caching
Implement caching for frequently accessed data:

```csharp
public class CachedInsellerateService
{
    private readonly IInsellerateApiClient _client;
    private readonly IMemoryCache _cache;

    public async Task<IQLSearchResponse> GetCachedSearchResultsAsync(string cacheKey, IQLQueryBuilder query, string[] fields)
    {
        if (_cache.TryGetValue(cacheKey, out IQLSearchResponse cachedResult))
        {
            return cachedResult;
        }

        var result = await _client.IQLSearchAsync(query, fields);
        _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
        
        return result;
    }
}
```

### Batch Operations
Process multiple operations efficiently:

```csharp
public async Task<List<StatusChangeResult>> BulkStatusUpdateAsync(
    Dictionary<string, string> leadStatusUpdates)
{
    var tasks = leadStatusUpdates.Select(kvp => 
        _insellerateClient.ChangeStatusAsync(kvp.Key, kvp.Value));

    return (await Task.WhenAll(tasks)).ToList();
}
```

## Security

### Configuration Security
- Store sensitive credentials in Azure Key Vault or similar secure storage
- Use managed identities when possible
- Implement credential rotation policies
- Never commit credentials to source control

### API Security
- Implement request/response logging for audit trails
- Use HTTPS-only communication
- Validate all input parameters
- Implement rate limiting to prevent abuse

## Monitoring and Diagnostics

### Logging
The library integrates with Microsoft.Extensions.Logging:

```csharp
services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddApplicationInsights();
    builder.SetMinimumLevel(LogLevel.Information);
});
```

### Health Checks
Implement health checks for monitoring:

```csharp
services.AddHealthChecks()
    .AddCheck<InsellerateHealthCheck>("insellerate-api");

public class InsellerateHealthCheck : IHealthCheck
{
    private readonly IInsellerateApiClient _client;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var isHealthy = await _client.TestConnectionAsync();
            return isHealthy 
                ? HealthCheckResult.Healthy("Insellerate API is responding")
                : HealthCheckResult.Unhealthy("Insellerate API is not responding");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Insellerate API health check failed", ex);
        }
    }
}
```

## Deployment

### GitHub Packages
The library is published to GitHub Packages with automated CI/CD:

```yaml
# .github/workflows/ci.yml
name: CI/CD Pipeline
on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build-and-publish:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v4
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --configuration Release --no-restore
    - name: Test
      run: dotnet test --configuration Release --no-build
    - name: Pack
      run: dotnet pack --configuration Release --no-build
    - name: Publish to GitHub Packages
      run: dotnet nuget push "**/*.nupkg" --source https://nuget.pkg.github.com/Royal-United-Mortgage/index.json --api-key ${{ secrets.GITHUB_TOKEN }}
```

## Continuous Integration

### Automated Testing
- Unit tests run on every commit
- Integration tests run on pull requests
- Code coverage reporting
- Static code analysis

### Quality Gates
- Minimum test coverage threshold
- Code quality metrics
- Security vulnerability scanning
- Dependency vulnerability checks

## Support and Troubleshooting

### Common Issues

1. **Authentication Failures**
   - Verify credentials in configuration
   - Check network connectivity
   - Validate API endpoint URLs

2. **Query Performance**
   - Use appropriate field selection
   - Implement result limits
   - Consider query optimization

3. **Rate Limiting**
   - Implement exponential backoff
   - Monitor API usage metrics
   - Consider request batching

### Debugging
Enable detailed logging for troubleshooting:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "InsellerateApi": "Debug"
    }
  }
}
```

## Version History

- **v1.2.0**: Current release with .NET 8.0 support and enhanced features
- **v1.1.0**: Added DNC management and multi-provider support
- **v1.0.0**: Initial release with core API functionality
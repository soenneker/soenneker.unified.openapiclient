[![](https://img.shields.io/nuget/v/soenneker.unified.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.unified.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.unified.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.unified.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.unified.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.unified.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.unified.openapiclient/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.unified.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Unified.OpenApiClient

A Kiota-generated client for Unified's normalized APIs, with typed request builders and response models across its integration categories.

## Installation

```bash
dotnet add package Soenneker.Unified.OpenApiClient
```

## Usage

Create a Kiota adapter with the workspace API token in the `Authorization` header:

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Unified.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.unified.to/")
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", apiKey);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new UnifiedOpenApiClient(adapter);
```

For example, list connections in the Sandbox environment:

```csharp
var connections = await client.Unified.Connection.GetAsync(
    request =>
    {
        request.QueryParameters.Env = "Sandbox";
        request.QueryParameters.Limit = 100;
    },
    cancellationToken);
```

Use `https://api-eu.unified.to/` or `https://api-au.unified.to/` as the base address when the workspace belongs to that data region. The caller owns the request adapter and `HttpClient`. API failures are thrown through Kiota's normal exception handling.

For configuration-based authentication, caching, and service registration, use `Soenneker.Unified.OpenApiClientUtil` instead.

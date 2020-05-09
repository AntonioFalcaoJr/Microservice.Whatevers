# WIP - Microservice.Whatevers (Work in progress)

![.NET Core](https://github.com/AntonioFalcao/Microservice.Whatevers/workflows/.NET%20Core/badge.svg?branch=master)
[![Codacy Badge](https://api.codacy.com/project/badge/Coverage/7b3fd1197a4d4da98aa6704ffde219a3)](https://www.codacy.com/manual/arfj/Microservice.Whatevers?utm_source=github.com&utm_medium=referral&utm_content=AntonioFalcao/Microservice.Whatevers&utm_campaign=Badge_Coverage)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/ee6104d0e614426b989cefb353215412)](https://app.codacy.com/manual/arfj/Microservice.Whatevers?utm_source=github.com&utm_medium=referral&utm_content=AntonioFalcao/Microservice.Whatevers&utm_campaign=Badge_Grade_Dashboard)
[![CodeFactor](https://www.codefactor.io/repository/github/antoniofalcao/microservice.whatevers/badge/master)](https://www.codefactor.io/repository/github/antoniofalcao/microservice.whatevers/overview/master)

Projeto inicial para meetup/hand's-on .NET Core

Nos próximos encontros, iremos evoluir o projeto para tópicos:

*   Estruturação de Projeto com derivação conceitual Domain Driven;
*   Conhecendo o Dotnet CLI;
*   Conhecendo o *.SLN e *.CSPROJ;
*   Implementação de designs, tais como: Template Method, Strategy, Repository, Buider, Strategy, dentre outros... 
*   Fluent Validation;
*   Auto Mapper;
*   Entity Framework com SQLite, Migrations e SEED.
*   Evoluindo API para alta disponibilidade com processamento assíncrono (Async/Await);
*   Versionamento de API;
*   Documentação de API's com Swagger;
*   Serviço de Log utilizando ILogger e Log4Net;
*   Tratar esgotamento de socket com IHttpClientFactory e respectivo design para clients;
*   Resiliência com Polly;

## Getting Started

After clone the project

```bash
dotnet run
```

### Prerequisites

Se faz necessário ambiente com seguintes recursos:

[.NET Core 3.1](https://dotnet.microsoft.com/download) - The framework used

To check this functionality:

```bash
dotnet --version
```

For more details

```bash
dotnet --info
```

## Running the tests

To run the tests use dotnet CLI

```bash
dotnet test
```

## Built With

[Microsoft .NET Core](https://dotnet.microsoft.com/)    
[Entity Framework Core](https://docs.microsoft.com/en-us/ef/#pivot=efcore)  
[Fluent Validation](https://fluentvalidation.net/)  
[Auto Mapper](https://automapper.org/)  
[SQLite](https://www.sqlite.org/index.html/)    
[xUnit](https://xunit.net/)

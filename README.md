# Serilog.Sinks.ILogger

[![NuGet Version](http://img.shields.io/nuget/v/Serilog.Sinks.ILogger.svg?style=flat)](https://www.nuget.org/packages/Serilog.Sinks.ILogger/)

Writes [Serilog](https://serilog.net) events to a `Microsoft.Extensions.Logging.ILogger`.

### Getting started

Install the [Serilog.Sinks.ILogger](https://www.nuget.org/packages/Serilog.Sinks.ILogger) package from NuGet:

```powershell
Install-Package Serilog.Sinks.ILogger
```

To configure the sink in C# code, call `WriteTo.ILogger()` during logger configuration:

```csharp
var log = new LoggerConfiguration()
    .WriteTo.ILogger(logger)
    .CreateLogger();
```

**logger** The `ILogger`.

### Optional parameters

**outputTemplate** A message template describing the output messages. See https://github.com/serilog/serilog/wiki/Formatting-Output.

**restrictedToMinimumLevel** The minimum level for events passed through the sink.
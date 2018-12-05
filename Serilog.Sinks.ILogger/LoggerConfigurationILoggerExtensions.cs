using Serilog.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Formatting.Display;
using Serilog.Events;
using System;

namespace Serilog.Sinks.ILogger
{
  /// <summary>
  /// Extends Serilog configuration to write events to a Microsoft ILogger.
  /// </summary>
  public static class LoggerConfigurationILoggerExtensions
  {
    /// <summary>
    /// Adds a sink that writes log events to a Microsoft ILogger
    /// </summary>
    /// <param name="loggerSinkConfiguration">The logger configuration.</param>
    /// <param name="logger">The ILogger.</param>
    /// <param name="outputTemplate">A message template describing the output messages.See https://github.com/serilog/serilog/wiki/Formatting-Output.</param>
    /// <param name="restrictedToMinimumLevel">The minimum level for events passed through the sink.</param>
    public static LoggerConfiguration ILogger(this LoggerSinkConfiguration loggerSinkConfiguration, Microsoft.Extensions.Logging.ILogger logger, string outputTemplate = null, LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose)
    {
      var messageTemplateTextFormatter = String.IsNullOrWhiteSpace(outputTemplate) ? null : new MessageTemplateTextFormatter(outputTemplate, null);
      return loggerSinkConfiguration.Sink(new ILoggerSink(logger, messageTemplateTextFormatter), restrictedToMinimumLevel);
    }
  }
}

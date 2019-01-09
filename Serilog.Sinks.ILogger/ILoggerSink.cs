using Serilog.Core;
using Serilog.Events;
using System;
using Microsoft.Extensions.Logging;
using Serilog.Formatting.Display;
using System.IO;

namespace Serilog.Sinks.ILogger
{
  class ILoggerSink : ILogEventSink
  {
    readonly Microsoft.Extensions.Logging.ILogger logger;
    readonly MessageTemplateTextFormatter formatter;

    public ILoggerSink(Microsoft.Extensions.Logging.ILogger logger, MessageTemplateTextFormatter formatter = null)
    {
      this.logger = logger;
      this.formatter = formatter;
    }

    public void Emit(LogEvent logEvent)
    {
      var logLevel = (LogLevel)(int)logEvent.Level;
      if (formatter != null)
      {
        using (var stringWriter = new StringWriter())
        {
          formatter.Format(logEvent, stringWriter);
          var message = stringWriter.ToString();
          logger.Log(logLevel, message, logEvent.Exception, logEvent.Properties);
        }
      }
      else
      {
        logger.Log(logLevel, logEvent.RenderMessage(), logEvent.Exception, logEvent.Properties);
      }
    }
  }
}

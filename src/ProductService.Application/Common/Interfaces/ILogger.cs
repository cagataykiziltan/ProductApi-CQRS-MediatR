using System;
using System.Collections.Generic;

namespace ProductService.Application.Common.Interfaces
{
    public interface ILogger
    {
        void Debug(string message, Exception exception = null, IDictionary<string, string> customProperties = null);


       void Information(string message, Exception exception = null, IDictionary<string, string> customProperties = null);


        void Warning(string message, Exception exception = null, IDictionary<string, string> customProperties = null);


        void Error(Exception exception, IDictionary<string, string> customProperties = null);


        void Error(string message, Exception exception = null, IDictionary<string, string> customProperties = null);


        void Fatal(Exception exception = null, IDictionary<string, string> customProperties = null);


        void Fatal(string message, Exception exception = null, IDictionary<string, string> customProperties = null);

    }
}

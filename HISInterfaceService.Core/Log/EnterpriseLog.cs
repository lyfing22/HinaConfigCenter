using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace HinaConfigCenter.Core.Log
{
    public sealed class EnterpriseLog
      : ILogger
    {
        #region Members


        #endregion



        #region Private Methods

        /// <summary>
        /// Trace internal message in configured listeners
        /// </summary>
        /// <param name="eventType">Event type to trace</param>
        /// <param name="message">Message of event</param>
        void TraceInternal(TraceEventType eventType, string message)
        {


            try
            {
                LogEntry entry = new LogEntry();
                entry.Severity = eventType;
                entry.Message = message;
                entry.Categories.Add(eventType.ToString());
                Logger.Write(entry);
            }
            catch (SecurityException)
            {
                //Cannot access to file listener or cannot have
                //privileges to write in event log etc...
            }

        }
        #endregion

        #region ILogger Members

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void LogInfo(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Information, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void LogRestInfo(string message)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = message;

                TraceInternal(TraceEventType.Information, messageToTrace);
            }
        }
        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void LogWarning(string message, params object[] args)
        {

            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Warning, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void LogError(string message, params object[] args)
        {
            return;
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Error, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="exception"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void LogError(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                string messageToTrace = "";
                if (args != null && args.Length > 0)
                {
                    messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);
                }
                else
                {
                    messageToTrace = message;
                }
                var exceptionData = exception.ToString(); // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Error, string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void Debug(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Verbose, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="exception"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void Debug(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.StackTrace; // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Error, string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="item"><see cref="ILogger"/></param>
        public void Debug(object item)
        {
            if (item != null)
            {
                TraceInternal(TraceEventType.Verbose, item.ToString());
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="args"><see cref="ILogger"/></param>
        public void Fatal(string message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                TraceInternal(TraceEventType.Critical, messageToTrace);
            }
        }

        /// <summary>
        /// <see cref="ILogger"/>
        /// </summary>
        /// <param name="message"><see cref="ILogger"/></param>
        /// <param name="exception"><see cref="ILogger"/></param>
        /// <param name="args"> </param>
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message)
                &&
                exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString(); // The ToString() create a string representation of the current exception

                TraceInternal(TraceEventType.Critical, string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));
            }
        }


        #endregion
    }
}

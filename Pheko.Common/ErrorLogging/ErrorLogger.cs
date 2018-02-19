using Pheko.Common.UtilityComponent;

using System;
using System.Diagnostics;
using System.Text;

namespace Pheko.Common.ErrorLogging
{
    public class ErrorLogger
    {
        private string _EventSource;

        public ErrorLogger() { }

        public ErrorLogger(string applicationName, string projectName)
        {
            _EventSource = applicationName;

            if (!EventLog.SourceExists(applicationName))
            {
                EventLog.CreateEventSource(applicationName, projectName);
            }
        }

        public void WriteToEventLog(Exception exception)
        {
            EventLog.WriteEntry(_EventSource, CreateEventLog(exception));
        }

        private string CreateEventLog(Exception exception)
        {
            StringBuilder fileErrorMessage = new StringBuilder();

            if (exception != null)
            {
                fileErrorMessage.AppendLine("Message: \n" + exception.Message.ToString() + "\n");

                if (exception.InnerException != null)
                {
                    string innerExceptionMessage = "";
                    innerExceptionMessage = AddInnerException(exception.InnerException, innerExceptionMessage);
                    fileErrorMessage.AppendLine(innerExceptionMessage + "\n");
                }

                fileErrorMessage.AppendLine("Stack Trace: \n" + exception.StackTrace + "\n");
                fileErrorMessage.AppendLine("Error Date: \n" + DateTime.Now.ToString(Constants.DATETIME_FORMAT) + "\n");

            }

            return fileErrorMessage.ToString();
        }

        private string AddInnerException(Exception exception, string message)
        {
            message += "\t Inner Exception : \n\t" + exception.Message + "\n";
            if (exception.InnerException != null)
            {
                message = AddInnerException(exception.InnerException, message);
            }
            return message;
        }

    }
}

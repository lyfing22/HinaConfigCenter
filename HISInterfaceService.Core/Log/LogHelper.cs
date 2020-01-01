using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace HinaConfigCenter.Core.Log
{
    public class LogHelper
    {
        /// <summary>
        /// 请求，用户行为  记录日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            string logName = "loginfo";
            message = GetCurrentMethodFullName() + "     " + message;
            LogManager.GetLogger(logName).Info(message);
        }

        /// <summary>
        /// 请求，用户行为  记录日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Info(string message, Exception ex)
        {
            string logName = "loginfo";
            message = GetCurrentMethodFullName() + "     " + message;
            LogManager.GetLogger(logName).Info(message, ex);
        }

        /// <summary>
        /// 错误、异常时候记录日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            string logName = "logerror";
            message = GetCurrentMethodFullName() + "     " + message;
            LogManager.GetLogger(logName).Error(message);
        }

        /// <summary>
        /// 错误、异常 记录日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception)
        {
            string logName = "logerror";
            message = GetCurrentMethodFullName() + "     " + message;
            LogManager.GetLogger(logName).Error(message, exception);
        }

        private static string GetCurrentMethodFullName()
        {
            StackFrame frame;
            string MethodFunStr = "";
            string MethodFullNameStr = "";
            // bool flag;
            try
            {
                int num = 2;
                StackTrace stackTrace = new StackTrace();
                int length = stackTrace.GetFrames().Length;
                //do
                //{
                int num1 = num;
                // num = num1 + 1;
                frame = stackTrace.GetFrame(num1);
                MethodFunStr = frame.GetMethod().DeclaringType.ToString();
                // flag = (!MethodFunStr.EndsWith("Exception") ? false : num < length);
                //}
                //while (flag);
                string name = frame.GetMethod().Name;
                MethodFullNameStr = string.Concat(MethodFunStr, ".", name);
            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
                MethodFullNameStr = exMessage.Substring(0, exMessage.Length > 200 ? 200 : exMessage.Length);
                LogManager.GetLogger("内部调试").Error("GetCurrentMethodFullName()方法报错啦！！！", ex);
            }
            return MethodFullNameStr;
        }

    }
}

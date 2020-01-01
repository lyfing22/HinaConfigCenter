using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinaConfigCenter.Core.Log
{
    public class LoggerFactory
    {
        #region Members

        static ILoggerFactory currentLogFactory;

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the  log factory to use
        /// </summary>
        /// <param name="logFactory">Log factory to use</param>
        public static void SetCurrent(ILoggerFactory logFactory)
        {
            if (currentLogFactory == null)
                currentLogFactory = logFactory;
        }

        /// <summary>
        /// Createt a new 
        /// </summary>
        /// <returns>Created ILog</returns>
        public  static ILogger CreateLog()
        {
            return (currentLogFactory != null) ? currentLogFactory.Create() : null;
        }

        #endregion
    }
}

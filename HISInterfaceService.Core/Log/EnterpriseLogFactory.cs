using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinaConfigCenter.Core.Log
{
    /// <summary>
    /// A Trace Source base, log factory
    /// </summary>
    public class EnterpriseLogFactory
        : ILoggerFactory
    {
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create()
        {
            return new EnterpriseLog();
        }
    }
}

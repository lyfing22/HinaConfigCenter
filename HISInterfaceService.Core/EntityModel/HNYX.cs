using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinaConfigCenter.Core.EntityModel
{

    /// <summary>
    /// 蓝网超声历史数据中间视图
    /// </summary>
    public class HNYX
    {
        public string AccessionNubmer { get; set; }

        public string StudyInstanceUID { get; set; }

        public string HisOrderCode { get; set; }

        public string HisExamNo { get; set; }
    }
}

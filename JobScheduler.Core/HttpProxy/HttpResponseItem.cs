using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Core.HttpProxy
{
    public class HttpResponseItem
    {
        /// <summary>
        /// 返回code
        /// </summary>
        public ResultAckCodeEnum AckCode { get; set; }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        public string ResultMsg { get; set; }
    }
}

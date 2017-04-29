using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Core.Common
{
    public class DateUtility
    {
        public static DateTimeOffset ConvertStringToDateTimeOffset(string date)
        {
            DateTimeOffset ret = default(DateTimeOffset);
            if (!string.IsNullOrWhiteSpace(date))
            {
                DateTimeOffset.TryParse(date, out ret);
            }

            return ret;
        }
    }
}

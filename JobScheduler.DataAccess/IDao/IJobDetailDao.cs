﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.DataAccess.IDao
{
    public interface IJobDetailDao
    {
        int GetJobCount();
    }
}

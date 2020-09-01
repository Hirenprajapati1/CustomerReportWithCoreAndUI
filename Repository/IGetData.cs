using CustmorReportCore.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustmorReportCore.Repository
{
    public interface IGetData
    {
        public List<Report> GetReportPay();
    }
}

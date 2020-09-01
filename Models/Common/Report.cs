using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustmorReportCore.Models.Common
{
    public class Report
    {
        public int No { get; set; }
        public DateTime DateOfMonthInvoice { get; set; }
        public DateTime DateOfMonthPay { get; set; }
        public DateTime DateOfMonth { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public int NoOfInvoices { get; set; }
        public int Sales { get; set; }
        public int PaymentCollection { get; set; }
    }
}

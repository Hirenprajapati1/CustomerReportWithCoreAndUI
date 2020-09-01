using System;
using System.Collections.Generic;

namespace CustmorReportCore.Models.Entity
{
    public partial class Payment
    {
        public string PaymentNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }
    }
}

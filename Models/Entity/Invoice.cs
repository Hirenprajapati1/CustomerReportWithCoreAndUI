﻿using System;
using System.Collections.Generic;

namespace CustmorReportCore.Models.Entity
{
    public partial class Invoice
    {
        public string InvoiceNo { get; set; }
        public string CustomerNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceAmount { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}

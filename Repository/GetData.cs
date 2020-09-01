using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustmorReportCore.Models.Common;
using CustmorReportCore.Models.Entity;
namespace CustmorReportCore.Repository
{
    public class GetData : IGetData
    {
        #region ReportPayfinaloutput

        public List<Report> GetReportPay()
        {
            List<Report> Reports = new List<Report>();
            try
            {
                using (var dBContext = new CustomerDBContext())
                {
                    Report Report1;
                    int i = 0;
                    foreach (var Inv in dBContext.Invoice.ToList())
                    {
                        Report1 = new Report();
                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == Inv.CustomerNo);
                        Report1.DateOfMonthInvoice = new DateTime(Inv.InvoiceDate.Year, Inv.InvoiceDate.Month, 11);

                        Report1.DateOfMonth = Report1.DateOfMonthInvoice;

                        //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
                        if (Cust != null)
                        {
                            Report1.CustomerNo = Inv.CustomerNo;
                            Report1.CustomerName = Cust.CustomerName;
                        }
                        Report1.NoOfInvoices = 1;
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            if (a.DateOfMonthInvoice == Report1.DateOfMonthInvoice && a.CustomerNo == Report1.CustomerNo)
                            {
                                a.Sales = Inv.InvoiceAmount + a.Sales;
                                a.NoOfInvoices = a.NoOfInvoices + 1;
                                b = true;
                            }


                        }
                        if (b == false)
                        {
                            Report1.Sales = Inv.InvoiceAmount;
                            i++;
                            Report1.No = i;
                            Reports.Add(Report1);
                        }

                    }
                    foreach (var PayInv in dBContext.Payment.ToList())
                    {
                        Report1 = new Report();
                        var inv = dBContext.Invoice.FirstOrDefault(x => x.InvoiceNo == PayInv.InvoiceNo);

                        var Cust = dBContext.Customer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                        if (PayInv != null)
                        {
                            Report1.DateOfMonthPay = new DateTime(PayInv.PaymentDate.Year, PayInv.PaymentDate.Month, 11);
                            Report1.DateOfMonth = Report1.DateOfMonthPay;
                        }

                        //Report1.MonthPayment = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentDate;
                        if (Cust != null)
                        {
                            Report1.CustomerNo = Cust.CustomerNo;
                            Report1.CustomerName = Cust.CustomerName;
                        }
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            //if (a.Year == Report1.Year && a.Month == Report1.Month && a.CustomerNo == Report1.CustomerNo)
                            if ((a.DateOfMonth == Report1.DateOfMonthPay || a.DateOfMonthPay == Report1.DateOfMonthPay) && a.CustomerNo == Report1.CustomerNo)
                            {
                                //   a.PaymentCollection = a.PaymentCollection + dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                                if (PayInv != null)
                                {
                                    a.PaymentCollection = PayInv.PaymentAmount + a.PaymentCollection;
                                }
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            // Report1.PaymentCollection = dBContext.Pyment.FirstOrDefault(x => x.InvoiceNo == Inv.InvoiceNo).PaymentAmount;
                            if (PayInv != null)
                            {
                                Report1.PaymentCollection = PayInv.PaymentAmount;
                            }
                            Reports.Add(Report1);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();
            return Reports;
        }

        #endregion

    }
}

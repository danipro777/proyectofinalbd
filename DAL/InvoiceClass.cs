using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceClass
    {
        private InvoiceTableAdapter tableAdapter;

        public InvoiceClass()
        {
            tableAdapter = new InvoiceTableAdapter();
        }

        public DataTable GetInvoice()
        {
            return tableAdapter.GetDataInvoice();
        }
    }
}

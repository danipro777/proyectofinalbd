using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceDetailClass
    {
        private InvoiceTableAdapter tableAdapter;

        public InvoiceDetailClass()
        {
            tableAdapter = new InvoiceTableAdapter();
        }

        public DataTable GetInvoiceDetail()
        {
            return tableAdapter.GetDataInvoice();
        }
    }
}

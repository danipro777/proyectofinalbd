using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalInvoice
    {
        private InvoiceTableAdapter invoice = null;
        private InvoiceTableAdapter invoiceTable = new InvoiceTableAdapter();

        private InvoiceTableAdapter INVOICE
        {
            get
            {
                if (invoice == null)
                    invoice = new InvoiceTableAdapter();
                return invoice;
            }
        }//fin private

        public void SaveInvoice(string seriesLetter, int idcustomer, int idEmployee)
        {
            invoiceTable.InsertQueryInvoice(seriesLetter, idcustomer, idEmployee);
        }

    }
}

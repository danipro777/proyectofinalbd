using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalDetail
    {
        private InvoiceDetailTableAdapter invoice = null;
        private InvoiceDetailTableAdapter invoiceTable = new InvoiceDetailTableAdapter();

        private InvoiceDetailTableAdapter INVOICE
        {
            get
            {
                if (invoice == null)
                    invoice = new InvoiceDetailTableAdapter();
                return invoice;
            }
        }//fin private

        public void SaveInvoice(int idInvoice, int idTipopago, string description, decimal amount)
        {
            invoiceTable.InsertQueryDetail(idInvoice, idTipopago, description, amount);
        }

        

    }
}

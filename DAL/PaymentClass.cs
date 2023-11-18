using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PaymentClass
    {
        public PaymentTypeTableAdapter tableAdapter;

        public PaymentClass()
        {
            tableAdapter = new PaymentTypeTableAdapter();
        }

        public DataTable GetPayment()
        {
            return tableAdapter.GetDataPaymentType();
        }
    }
}

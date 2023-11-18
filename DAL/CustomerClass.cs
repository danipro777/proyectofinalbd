using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerClass
    {
        private CustomersTableAdapter tableAdapter;

        public CustomerClass()
        {
            tableAdapter = new CustomersTableAdapter();
        }

        public DataTable GeCustomer()
        {
            return tableAdapter.GetDatacmbCustomers();
        }
    }
}

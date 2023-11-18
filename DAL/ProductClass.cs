using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductClass
    {
        private ProductsTableAdapter tableAdapter;

        public ProductClass()
        {
            tableAdapter = new ProductsTableAdapter();
        }

        public DataTable GetProducts()
        {
            return tableAdapter.GetDataProducts();
        }
    }
}

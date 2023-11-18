using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryProductsClass
    {
        private CategoryProductTableAdapter tableAdapter;

        public CategoryProductsClass()
        {
            tableAdapter = new CategoryProductTableAdapter();
        }

        public DataTable GetCategoryProducts()
        {
            return tableAdapter.GetDataCategoryProduct();
        }
    }
}

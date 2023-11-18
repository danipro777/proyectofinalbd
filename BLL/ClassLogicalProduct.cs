using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalProduct
    {
        private ProductsTableAdapter products = null;
        private ProductsTableAdapter productsTable = new ProductsTableAdapter();
        private ProductsTableAdapter PRODUCTS
        {
            get
            {
                if (products == null)
                    products = new ProductsTableAdapter();
                return products;
            }
        }//fin private

        public DataTable ListProduct()
        {
            return PRODUCTS.GetDataProducts();//Este es el metodo del dataset
        }

        public void SaveProduct(int idcategory, string name, string description, int saleprice, decimal discount, string brand, string model, DateTime warranty, int maxstock, int minstock)
        {
            productsTable.InsertQueryProducts(idcategory, name, description, saleprice, discount, brand, model, warranty, maxstock, minstock);
        }

        public string UpdateProduct(int idcategory, string name, string description, int saleprice, decimal discount, string brand, string model, DateTime warranty, int maxstock, int minstock, int id)
        {
            int existe;
            existe = Convert.ToInt32(products.ScalarQueryProduct(name));
            if (existe > 1)
                return "Error: El tipo de categoria " + name + " ya existe previamente";
            else
            {
                products.UpdateQueryProducts(idcategory, name, description, saleprice, discount, brand, model, warranty, maxstock, minstock, id);
                return "Se editó el tipo de producto con registro: " + id;
            }
        }//Fin editarPaymentType
    }
}
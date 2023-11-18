using DAL;
using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalCategoryProduct
    {

        private CategoryProductTableAdapter CategoryProduct = null;
        private CategoryProductsClass categoryp = null;
        public ClassLogicalCategoryProduct()
        {
            categoryp = new CategoryProductsClass();
        }
        private CategoryProductTableAdapter CATEGORYPRODUCT
        {
            get
            {
                if (CategoryProduct == null)
                    CategoryProduct = new CategoryProductTableAdapter();
                return CategoryProduct;
            }
        }

        //Metodos

        // Método para obtener los roles disponibles
        public List<string> GetProducts()
        {
            List<string> productosDisponibles = new List<string>();

            DataTable tableCategory = categoryp.GetCategoryProducts();// Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tableCategory.Rows)
            {
                string nameCategory = fila["Name_CategoryProduct"].ToString(); // Reemplaza con el nombre real del campo
                productosDisponibles.Add(nameCategory);
            }

            return productosDisponibles;
        }

        public DataTable ListCategoryProduct()
        {
            return CATEGORYPRODUCT.GetDataCategoryProduct();
        }

        public string NewCategoryProduct(string payment)
        {
            int existe;
            existe = Convert.ToInt32(CATEGORYPRODUCT.ScalarQueryCategoryProduct(payment));
            if (existe > 0)
                return "Error: El tipo de pago " + payment + " ya existe previamente";
            else
            {
                CATEGORYPRODUCT.InsertQueryCategoryProduct(payment);
                return "Se agregó nuevo tipo de pago " + payment;
            }
        }//Fin Nuevo CategoryProduct

        public string UpdatePaymentType(string payment, int id)
        {
            int existe;
            existe = Convert.ToInt32(CategoryProduct.ScalarQueryCategoryProduct(payment));
            if (existe > 1)
                return "Error: La categoria del producto " + payment + " ya existe previamente";
            else
            {
                CategoryProduct.UpdateQueryCategoryProduct(payment, id);
                return "Se editó la categoria del producto con registro: " + id;
            }
        }//Fin editarCategoryProduct
    }
}

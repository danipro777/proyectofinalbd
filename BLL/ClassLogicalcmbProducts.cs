using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalcmbProducts
    {
        private ProductClass productClass;

        public ClassLogicalcmbProducts()
        {
            productClass = new ProductClass();
        }

        // Método para obtener los Customer disponibles
        public List<string> GetProducts()
        {
            List<string> lista = new List<string>();

            DataTable tabla = productClass.GetProducts();// Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tabla.Rows)
            {
                string nombre = fila["Name_Product"].ToString(); // Reemplaza con el nombre real del campo
                lista.Add(nombre);
            }

            return lista;
        }
    }
}

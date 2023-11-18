using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalcmbCustomer
    {
        private CustomerClass customerDataAccess;

         public ClassLogicalcmbCustomer()
        {
            customerDataAccess = new CustomerClass();
        }


        // Método para obtener los Customer disponibles
        public List<string> ObtenerCustomerDisponibles()
        {
            List<string> CustomerDisponibles = new List<string>();

            DataTable tablaCustomer = customerDataAccess.GeCustomer(); // Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tablaCustomer.Rows)
            {
                string nombreCustomer = fila["Name_Customer"].ToString(); // Reemplaza con el nombre real del campo
                CustomerDisponibles.Add(nombreCustomer);
            }

            return CustomerDisponibles;
        }

    }


}

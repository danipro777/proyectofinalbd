using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalcmbPayment
    {
        private PaymentClass paymentClass;

        public ClassLogicalcmbPayment()
        {
            paymentClass = new PaymentClass();
        }

        // Método para obtener los Customer disponibles
        public List<string> GetPayment()
        {
            List<string> lista = new List<string>();

            DataTable tabla = paymentClass.GetPayment(); // Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tabla.Rows)
            {
                string nombre = fila["PaymentType"].ToString(); // Reemplaza con el nombre real del campo
                lista.Add(nombre);
            }

            return lista;
        }
    }
}

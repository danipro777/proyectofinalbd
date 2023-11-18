using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalcmbInvoiceDetail
    {
        private InvoiceDetailClass invoiceDetailClass;

        public ClassLogicalcmbInvoiceDetail()
        {
            invoiceDetailClass = new InvoiceDetailClass();
        }

        // Método para obtener los Customer disponibles
        public List<string> GetInvoiceDetail()
        {
            List<string> lista = new List<string>();

            DataTable tabla = invoiceDetailClass.GetInvoiceDetail(); // Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tabla.Rows)
            {
                string nombre = fila["SeriesLetter"].ToString(); // Reemplaza con el nombre real del campo
                lista.Add(nombre);
            }

            return lista;
        }
    }
}

using DAL;
using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalInvoice
    {
        private InvoiceTableAdapter invoice = null;
        private InvoiceTableAdapter invoiceTable = new InvoiceTableAdapter();
        private InvoiceClass invoiceClass;

        private InvoiceTableAdapter INVOICE
        {
            get
            {
                if (invoice == null)
                    invoice = new InvoiceTableAdapter();
                return invoice;
            }
        }//fin private

        public void SaveInvoice(string seriesLetter, int idcustomer, int idEmployee)
        {
            invoiceTable.InsertQueryInvoice(seriesLetter, idcustomer, idEmployee);
        }

        public void Anular(string seriesLetter)
        {
            invoiceTable.ActualizarMontoAnulado(seriesLetter);
        }

        public List<string> GetInvoices()
        {
            List<string> rolesDisponibles = new List<string>();

            DataTable tablaRoles = invoiceClass.GetInvoice(); // Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tablaRoles.Rows)
            {
                string nombreRol = fila["SeriesLetter"].ToString(); // Reemplaza con el nombre real del campo
                rolesDisponibles.Add(nombreRol);
            }

            return rolesDisponibles;
        }


        public bool FacturaYaAnulada(string seriesLetter)
        {
            try
            {
                // Realizar una consulta para verificar si la factura ya está anulada en ambas tablas
                // (Puedes ajustar la conexión y la consulta según tu entorno)
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7121MS8\\SQLEXPRESS;Initial Catalog=ProyectoBD; Integrated Security=True;"))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT 1 FROM Invoice WHERE SeriesLetter = @SeriesLetter AND Estado = 0 AND EXISTS (SELECT 1 FROM InvoiceDetail WHERE ID_Invoice = Invoice.ID AND Amount = 0)", connection))
                    {
                        cmd.Parameters.AddWithValue("@SeriesLetter", seriesLetter);
                        return (int)cmd.ExecuteScalar() == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

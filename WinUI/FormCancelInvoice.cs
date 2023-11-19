using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class FormCancelInvoice : Form
    {
        private ClassLogicalcmbInvoice invoice;
        public FormCancelInvoice()
        {
            InitializeComponent();
            invoice = new ClassLogicalcmbInvoice();
            CargarFactura();
        }

        private void btnAnularFac_Click(object sender, EventArgs e)
        {
            /*ClassLogicalInvoice anular = new ClassLogicalInvoice();
            string series = cmbSelect.Text;
            anular.Anular(series);
            MessageBox.Show("Factura anulada con exito");*/

            ClassLogicalInvoice anular = new ClassLogicalInvoice();
            string series = cmbSelect.Text;

            // Verificar si la factura ya está anulada
            if (anular.FacturaYaAnulada(series))
            {
                MessageBox.Show("Esta factura ya ha sido anulada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Anular la factura
                anular.Anular(series);
                MessageBox.Show("Factura anulada con éxito.");
            }
        }


        private void CargarFactura()
        {
            try
            {
                List<string> lista = invoice.GetInvoice();


                cmbSelect.DataSource = lista;


                cmbSelect.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message);
            }
        }
    }
}

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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnCategoryProduct_Click(object sender, EventArgs e)
        {
            CRUDCategoryProducts formSecundario = new CRUDCategoryProducts();
            formSecundario.Show();
        }

        private void btnCustomerType_Click(object sender, EventArgs e)
        {
            CRUDCustomerType formSecundario = new CRUDCustomerType();
            formSecundario.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            CRUDEmployees formSecundario = new CRUDEmployees();
            formSecundario.Show();
        }

        private void btnPaymentType_Click(object sender, EventArgs e)
        {
            CRUDPaymentType formSecundario = new CRUDPaymentType();
            formSecundario.Show();
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            CRUDProvider formSecundario = new CRUDProvider();
            formSecundario.Show();
        }

        private void btnRols_Click(object sender, EventArgs e)
        {
            CRUDRol formSecundario = new CRUDRol();
            formSecundario.Show();
        }
    }
}

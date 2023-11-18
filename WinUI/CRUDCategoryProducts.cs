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
    public partial class CRUDCategoryProducts : Form
    {
       ClassLogicalCategoryProduct logica = new ClassLogicalCategoryProduct();
        public CRUDCategoryProducts()
        {
            InitializeComponent();
        }

        private void NUEVO_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void CRUDCategoryProducts_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            respuesta = logica.NewCategoryProduct(txtCategoryProduct.Text);
            MessageBox.Show(respuesta);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            respuesta = logica.UpdatePaymentType(txtCategoryProduct.Text, Convert.ToInt32(label3.Text));
            MessageBox.Show(respuesta);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                this.label3.Visible = true;
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCategoryProduct.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
                groupBox1.Enabled = true;
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logica.ListCategoryProduct();
            dataGridView1.Refresh();
            btnUpdate.Enabled = true;
        }
    }
}

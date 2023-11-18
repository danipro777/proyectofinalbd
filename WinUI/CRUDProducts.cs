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
    public partial class CRUDProducts : Form
    {
        private ClassLogicalCategoryProduct category;
        ClassLogicalProduct product = new ClassLogicalProduct();
        public CRUDProducts()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = product.ListProduct();
            dataGridView1.Refresh();
            btnUpdate.Enabled = true;
            category = new ClassLogicalCategoryProduct();
            CargarProductos();
        }

        private void CRUDProducts_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            category = new ClassLogicalCategoryProduct();
            CargarProductos();
            groupBox1.Enabled = true;
            btnSave.Enabled = true;
            cmbCategory.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbCategory.Visible = true;
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                this.label12.Visible = true;
                cmbCategory.SelectedIndex = 0;
                cmbCategory.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[0].ToString();
                label12.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSalePrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtModel.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtWarranty.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtMaxStock.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtMinStock.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
                groupBox1.Enabled = true;
            }

        }

        private void CargarProductos()
        {
            try
            {
                List<string> rolesDisponibles = category.GetProducts();


                cmbCategory.DataSource = rolesDisponibles;


                cmbCategory.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorias: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClassLogicalProduct classLogical = new ClassLogicalProduct();
            int idcategory = cmbCategory.SelectedIndex + 1;
            string name = txtName.Text;
            string description = txtDescription.Text;
            int saleprice = Convert.ToInt32(txtSalePrice.Text);
            decimal discount = Convert.ToDecimal(txtDiscount.Text);
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            DateTime warranty = Convert.ToDateTime(txtWarranty.Text);
            int maxstock = Convert.ToInt32(txtMaxStock.Text);
            int minstock = Convert.ToInt32(txtMinStock.Text);

            classLogical.SaveProduct(idcategory, name, description, saleprice, discount, brand, model, warranty, maxstock, minstock);
            MessageBox.Show("Producto ingresado exitosamente");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            respuesta = product.UpdateProduct(Convert.ToInt32(cmbCategory.SelectedIndex), txtName.Text, txtDescription.Text, Convert.ToInt32(txtSalePrice.Text), Convert.ToDecimal(txtDiscount.Text), txtBrand.Text, txtModel.Text, Convert.ToDateTime(txtWarranty.Text), Convert.ToInt32(txtMaxStock.Text), Convert.ToInt32(txtMinStock.Text), Convert.ToInt32(label12.Text));
            MessageBox.Show(respuesta);
        }
    }
}
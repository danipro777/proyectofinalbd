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
    public partial class CRUDEmployees : Form
    {
        private ClassLogicalRols rolManager;
        ClassLogicalEmployees logica = new ClassLogicalEmployees();

        public CRUDEmployees()
        {
            InitializeComponent();
            rolManager = new ClassLogicalRols(); 
            CargarRolesEnComboBox();
        }

        private void CargarRolesEnComboBox()
        {
            try
            {
                List<string> rolesDisponibles = rolManager.ObtenerRolesDisponibles(); 

               
                cmbRol.DataSource = rolesDisponibles;
               

                cmbRol.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
        }
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {        
            ClassLogicalEmployees classLogicalEmployees = new ClassLogicalEmployees();
            int idrol = cmbRol.SelectedIndex + 1;
            string name = txtName.Text;
            string address = txtAddress.Text;
            int phone = Convert.ToInt32(txtPhone.Text);
            string email = txtEmail.Text;
            int age = Convert.ToInt32(txtAge.Text);
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            classLogicalEmployees.SaveEmployee(idrol, name, address, phone, email, age, username, password);
            MessageBox.Show("Empleado ingresado exitosamente");
        }

        private void CRUDEmployees_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logica.ListEmployee();
            dataGridView1.Refresh();
            btnUpdate.Enabled = true;
        }
    }
}

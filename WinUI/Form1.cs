using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;


namespace WinUI
{
    public partial class Form1 : Form
    {
        ClassLogicalEmployees pss = new ClassLogicalEmployees();
        ClassLogicalEmployees verificate = new ClassLogicalEmployees();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDEmployees formSecundario = new CRUDEmployees();
            formSecundario.Show();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            ClassLogicalLogin userService = new ClassLogicalLogin();
            pss.GetInfo(username);
            verificate.GetID(username);
            if(password == pss.GetInfo(username))
            {
                MessageBox.Show("Bienvenido " + username);
                if(verificate.GetID(username) == "1")
                {
                    FormAdmin formSecundario = new FormAdmin();
                    formSecundario.Show();
                } 
                else if (verificate.GetID(username) == "2")
                {
                    FormGrocer formSecundario = new FormGrocer();
                    formSecundario.Show();
                }
                else if (verificate.GetID(username) == "3")
                {
                    FormCashier formSecundario = new FormCashier();
                    formSecundario.Show();
                }
                else if (verificate.GetID(username) == "4")
                {
                    FormManager formSecundario = new FormManager();
                    formSecundario.Show();
                }
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}

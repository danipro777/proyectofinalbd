using BLL;
using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.IO;


namespace WinUI
{
    public partial class SaleInvoice : Form
    {
        private ClassLogicalcmbCustomer customer;
        private ClassLogicalcmbEmployee employees;
        private ClassLogicalcmbProducts products;
        private ClassLogicalcmbInvoice invoice;
        private ClassLogicalcmbInvoiceDetail detail;
        private ClassLogicalcmbPayment payment;
        ClassLogicalInvoice logica = new ClassLogicalInvoice();
        ClassLogicalSales product = new ClassLogicalSales();
        decimal MONTO;
        decimal totales;

        public SaleInvoice()
        {
            InitializeComponent();
            customer = new ClassLogicalcmbCustomer();
            CargarCustomer();
            employees = new ClassLogicalcmbEmployee();
            CargarEmployee();
            products = new ClassLogicalcmbProducts();
            CargarProduct();
        }



        private void btnVender_Click(object sender, EventArgs e)
        {
            GenerarFacturaPDF();
        }


        private void CargarCustomer()
        {
            try
            {
                List<string> customerDisponibles = customer.ObtenerCustomerDisponibles();


                cmbCliente.DataSource = customerDisponibles;


                cmbCliente.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void CargarEmployee()
        {
            try
            {
                List<string> employeeDisponibles = employees.ObtenerEmployeeDisponibles();


                cmbEmployee.DataSource = employeeDisponibles;


                cmbEmployee.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message);
            }
        }

        private void CargarProduct()
        {
            try
            {
                List<string> lista = products.GetProducts();


                cmbProduct.DataSource = lista;


                cmbProduct.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void CargarFactura()
        {
            try
            {
                List<string> lista = invoice.GetInvoice();


                cmbInvoice.DataSource = lista;


                cmbInvoice.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message);
            }
        }

        private void CargarFactura2()
        {
            try
            {
                List<string> lista = detail.GetInvoiceDetail();


                cmdInvoiceID.DataSource = lista;


                cmdInvoiceID.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message);
            }
        }

        private void CargarTipoPago()
        {
            try
            {
                List<string> lista = payment.GetPayment();


                cmbPaymentType.DataSource = lista;


                cmbPaymentType.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de pago: " + ex.Message);
            }
        }


        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void SaleInvoice_Load(object sender, EventArgs e)
        {

        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            ClassLogicalInvoice classLogical = new ClassLogicalInvoice();

            string name = textBox2.Text;
            int idcliente = cmbCliente.SelectedIndex + 1;
            int idemployee = cmbEmployee.SelectedIndex + 1;

            classLogical.SaveInvoice(name, idcliente, idemployee);
            MessageBox.Show("Factura iniciada");
            invoice = new ClassLogicalcmbInvoice();
            CargarFactura();
            detail = new ClassLogicalcmbInvoiceDetail();
            CargarFactura2();
            payment = new ClassLogicalcmbPayment();
            CargarTipoPago();

         
        }

        private void btnSales_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            ClassLogicalSales classLogical = new ClassLogicalSales();
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Text);
            int IdInvoice = cmbInvoice.SelectedIndex + 1;
            int idProduct = cmbProduct.SelectedIndex + 1;
            int typepay = cmbPaymentType.SelectedIndex + 1;
            classLogical.SaveSale(fecha, IdInvoice, idProduct, typepay);
            // Obtén el texto seleccionado del ComboBox
            string texto = cmbProduct.SelectedItem.ToString();

            // Agrega el texto seleccionado a la celda de la primera fila y la columna "ProductosColumn"
            dataGridView1.Rows.Add(texto);
            MessageBox.Show("Producto agregado");


            //TOTAL
            int idFactura = cmbInvoice.SelectedIndex + 1;
            Console.WriteLine("ID de factura seleccionado: " + idFactura);
            // Aquí debes obtener el ID de factura que desees consultar

            ClassLogicalSales total = new ClassLogicalSales();
            DataTable resultadoProcedimiento = total.EjecutarProcedimientoAlmacenado(idFactura);

            if (resultadoProcedimiento != null && resultadoProcedimiento.Rows.Count > 0)
            {
                decimal totals = Convert.ToDecimal(resultadoProcedimiento.Rows[0]["TotalSum"]);
                totales = totals;
                MONTO = totals;               
                label13.Text = totals.ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para el ID de factura proporcionado.");
            }

            //descontar inventario
            //TOTAL
            int cmbProductIndex = cmbProduct.SelectedIndex + 1; 
            int cmbInvoices = cmbInvoice.SelectedIndex + 1;

            ClassLogicalSales descontar = new ClassLogicalSales(); 

            descontar.ActualizarInventarioDesdeVentas(cmbProductIndex, cmbInvoices);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            txtDescription.Enabled = false;
        

            ClassLogicalDetail classLogicals = new ClassLogicalDetail();
            int idInvoice = cmdInvoiceID.SelectedIndex + 1;
            int idpay = cmbPaymentType.SelectedIndex + 1;
            string descripcion = txtDescription.Text;
            decimal amount = Convert.ToDecimal(label13.Text);

            classLogicals.SaveInvoice(idInvoice, idpay, descripcion, amount);


            if (decimal.TryParse(textBox3.Text, out decimal monto))
            {
                decimal resta1 = MONTO - monto;

                if (resta1 == 0)
                {
                    label13.Text = "00.00";
                    MessageBox.Show("Pago COMPLETADO");
                    MONTO = 0; // Se establece el MONTO en cero ya que la venta se ha completado.
                }
                else if (resta1 > 0)
                {
                    label13.Text = resta1.ToString("0.00");
                    MessageBox.Show("Pago realizado");
                    MONTO = resta1; // Actualizamos el MONTO con el nuevo valor después del pago.
                }
                else if (monto > MONTO)
                {
                    decimal cambio = monto - MONTO;
                    MessageBox.Show("El monto a devolver es: " + cambio.ToString("0.00"));
                    label13.Text = "00.00";
                    MONTO = 0; // Se establece el MONTO en cero ya que la venta se ha completado.
                }
            }
            else
            {
                MessageBox.Show("Monto ingresado no válido.");
            }


            string tipoPago = cmbPaymentType.SelectedItem.ToString();
            string montos = textBox3.Text; 

            dataGridView2.Rows.Add(tipoPago, montos);

            textBox3.Clear();


        }

        //FACTURA
        private void GenerarFacturaPDF()
        {
            // Usar un cuadro de diálogo para que el usuario elija dónde guardar el archivo de texto
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            saveFileDialog.Title = "Guardar factura como archivo de texto";
            saveFileDialog.FileName = "Factura.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivoTexto = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(rutaArchivoTexto))
                {
                    // Escribe los datos en el archivo de texto
                    writer.WriteLine("Número de Serie: " + cmbInvoice.SelectedItem.ToString());
                    writer.WriteLine("Cliente: " + cmbCliente.SelectedItem.ToString());
                    writer.WriteLine("Empleado: " + cmbEmployee.SelectedItem.ToString());
                    writer.WriteLine("----------------------------------------------------");

                    writer.WriteLine("Productos:");
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Productos"] != null && row.Cells["Productos"].Value != null)
                        {
                            writer.WriteLine(row.Cells["Productos"].Value.ToString());
                            writer.WriteLine("----------------------------------------------------");
                        }
                    }

                    writer.WriteLine("Detalles de pago:");
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells["TipoPago"] != null && row.Cells["TipoPago"].Value != null)
                        {
                            writer.WriteLine("Pago con: " + row.Cells["TipoPago"].Value.ToString());
                            writer.WriteLine("Monto: " + row.Cells["Montos"].Value.ToString());
                            writer.WriteLine("----------------------------------------------------");
                        }
                    }

                    writer.WriteLine("Fecha Venta: " + dateTimePicker1.Text.ToString());
                    writer.WriteLine("----------------------------------------------------");
                    writer.WriteLine("Descripcion: " + txtDescription.Text);
                    writer.WriteLine("----------------------------------------------------");
                    writer.WriteLine("TOTAL A PAGAR: " + totales.ToString());
                }

                MessageBox.Show("Factura guardada como archivo de texto.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAnularFac_Click(object sender, EventArgs e)
        {
            FormCancelInvoice form = new FormCancelInvoice();
            form.Show();
        }

        private void cmdInvoiceID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    } 

  }

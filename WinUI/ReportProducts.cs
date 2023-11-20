using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinUI
{
    public partial class ReportProducts : Form
    {
        public ReportProducts()
        {
            InitializeComponent();
        }

        private void ReportProducts_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
             DateTime startDate = dtp1.Value;
             DateTime endDate = dtp2.Value;

             // Llamada al método para obtener datos según el rango de fechas
             var data = GetSalesReportData(startDate, endDate);

             // Configurar el origen de datos para el informe
             ReportDataSource reportDataSource = new ReportDataSource("DataSet1", data);
             this.reportViewer1.ProcessingMode = ProcessingMode.Local;
             this.reportViewer1.LocalReport.ReportEmbeddedResource = @"WinUI.Reports.ReportMasVendidos.rdlc";
             this.reportViewer1.LocalReport.DataSources.Clear();
             this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
             this.reportViewer1.RefreshReport();
        }

         public DataTable GetSalesReportData(DateTime startDate, DateTime endDate)
         {
             string cadenaConexion = "Data Source=DESKTOP-7121MS8\\SQLEXPRESS;Initial Catalog=ProyectoBD;Integrated Security=True";

             using (SqlConnection conexion = new SqlConnection(cadenaConexion))
             {
                 conexion.Open();

                 using (SqlCommand comando = new SqlCommand("MasVendidosGet", conexion))
                 {
                     comando.CommandType = CommandType.StoredProcedure;
                     comando.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = startDate });
                     comando.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date) { Value = endDate });

                     using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                     {
                         DataTable tablaResultado = new DataTable();
                         adaptador.Fill(tablaResultado);
                         return tablaResultado;
                     }
                 }
             }
         }
      

    }
}

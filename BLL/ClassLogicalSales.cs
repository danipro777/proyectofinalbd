﻿using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalSales
    {
        private Products1TableAdapter product = null;
        private Products1TableAdapter invoiceProduct = new Products1TableAdapter();
        private SalesTableAdapter invoiceSales = new SalesTableAdapter();
        private Products1TableAdapter PRODUCTS
        {
            get
            {
                if (product == null)
                    product = new Products1TableAdapter();
                return product;
            }
        }//fin private

        private SalesTableAdapter SALES
        {
            get
            {
                if (invoiceSales == null)
                    invoiceSales = new SalesTableAdapter();
                return invoiceSales;
            }
        }//fin private
        public DataTable ListProduct()
        {
            return PRODUCTS.GetDataProductList();
        }

        public void SaveSale(DateTime fecha, int idFactura, int idProducto)
        {
            invoiceSales.InsertarVenta(fecha, idFactura, idProducto);
        }

        //sumar
        public DataTable EjecutarProcedimientoAlmacenado(int idFactura)
        {
            string cadenaConexion = "Data Source=DESKTOP-7121MS8\\SQLEXPRESS;Initial Catalog=ProyectoBD;Integrated Security=True";

            string nombreProcedimiento = "SumarTotalAmountPorID";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agrega el parámetro necesario para el procedimiento almacenado
                    comando.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = idFactura });

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable tablaResultado = new DataTable();
                        adaptador.Fill(tablaResultado);
                        return tablaResultado;
                    }
                }
            }

        }

        //DESCONTAR inventario
        public void ActualizarInventarioDesdeVentas(int cmbProductIndex, int cmbInvoice)
        {
            string cadenaConexion = "Data Source=DESKTOP-7121MS8\\SQLEXPRESS;Initial Catalog=ProyectoBD;Integrated Security=True";

            string nombreProcedimiento = "ActualizarInventarioDesdeVentas";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agrega el parámetro necesario para el procedimiento almacenado
                    comando.Parameters.Add(new SqlParameter("@InventarioID", SqlDbType.Int) { Value = cmbProductIndex });
                    comando.Parameters.Add(new SqlParameter("@IDINVOICE", SqlDbType.Int) { Value = cmbInvoice });
                    // Ejecuta el procedimiento almacenado
                    comando.ExecuteNonQuery();
                }
            }
        }

    }
}


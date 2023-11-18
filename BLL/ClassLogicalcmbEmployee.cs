using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalcmbEmployee
    {
        private EmployeeClass cemployeeDataAccess;

        public ClassLogicalcmbEmployee()
        {
            cemployeeDataAccess = new EmployeeClass();
        }


        // Método para obtener los Customer disponibles
        public List<string> ObtenerEmployeeDisponibles()
        {
            List<string> EmployeeDisponibles = new List<string>();

            DataTable tablaCustomer = cemployeeDataAccess.GetEmployee(); // Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tablaCustomer.Rows)
            {
                string nombreEmployee = fila["Name_Employee"].ToString(); // Reemplaza con el nombre real del campo
                EmployeeDisponibles.Add(nombreEmployee);
            }

            return EmployeeDisponibles;
        }
    }
}

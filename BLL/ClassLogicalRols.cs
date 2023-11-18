using DAL;
using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalRols
    {
        //Show in cmb

        private RolsClass rolDataAccess;

        public ClassLogicalRols()
        {
            rolDataAccess = new RolsClass(); 
        }


        // Método para obtener los roles disponibles
        public List<string> ObtenerRolesDisponibles()
        {
            List<string> rolesDisponibles = new List<string>();

            DataTable tablaRoles = rolDataAccess.ObtenerRoles(); // Llama al método de la capa DAL para obtener los roles

            // Recorre la tabla y agrega los nombres de los roles a la lista
            foreach (DataRow fila in tablaRoles.Rows)
            {
                string nombreRol = fila["RolType"].ToString(); // Reemplaza con el nombre real del campo
                rolesDisponibles.Add(nombreRol);
            }

            return rolesDisponibles;
        }



        private RolsTableAdapter Rols = null;
        private RolsTableAdapter ROLS
        {
            get
            {
                if (Rols == null)
                    Rols = new RolsTableAdapter();
                return Rols;
            }
        }

        public DataTable ListRols()
        {
            return ROLS.GetDataRols();
        }

        public string NewRol(string rol)
        {
            int existe;
            existe = Convert.ToInt32(ROLS.ScalarQueryRols(rol));
            if (existe > 0)
                return "Error: El tipo de rol " + rol + " ya existe previamente";
            else
            {
                ROLS.InsertQueryRols(rol);
                return "Se agregó nuevo tipo de rol " + rol;
            }
        }//End NewRol

        public string UpdateRol(string rol, int id)
        {
            int existe;
            existe = Convert.ToInt32(Rols.ScalarQueryRols(rol));
            if (existe > 1)
                return "Error: El tipo de rol " + rol + " ya existe previamente";
            else
            {
                Rols.UpdateQueryRols(rol, id);
                return "Se editó el tipo de rol con registro: " + id;
            }
        }//Fin editarPaymentType


        
    }
}

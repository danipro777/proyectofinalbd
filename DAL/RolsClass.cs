using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RolsClass
    {
        private RolsTableAdapter tableAdapter; 

        public RolsClass()
        {
            tableAdapter = new RolsTableAdapter(); 
        }

        public DataTable ObtenerRoles()
        {
            return tableAdapter.GetDataRols();
        }

    }
}
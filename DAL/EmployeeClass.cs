using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeClass
    {
        private Employees1TableAdapter tableAdapter;

        public EmployeeClass()
        {
            tableAdapter = new Employees1TableAdapter();
        }

        public DataTable GetEmployee()
        {
            return tableAdapter.GetDataEmployeecmb();
        }
    }
}

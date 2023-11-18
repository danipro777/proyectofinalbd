using DAL;
using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalEmployees
    {
        private EmployeesTableAdapter employeesTableAdapter = new EmployeesTableAdapter();


       
        private EmployeesTableAdapter Employee = null;
        private EmployeesTableAdapter EMPLOYEE
        {
            get
            {
                if (Employee == null)
                    Employee = new EmployeesTableAdapter();
                return Employee;
            }
        }

        //METHODS
        public void SaveEmployee(int idRol, string name, string address, int phone, string email, int age, string username, string password)
        {
            employeesTableAdapter.EncryptEmployee(idRol, name, address, phone, email, age, username, password);
        }
        public string NewEmployee(int idRol, string name, string address, int phone, string email, int age, string username, string password)
        {
            int existe;
            existe = Convert.ToInt32(EMPLOYEE.ScalarQueryEmployees(name));
            if (existe > 0)
                return "Error: El empleado " + name + " ya existe previamente";
            else
            {
                EMPLOYEE.InsertQueryEmployees(idRol, name, address, phone, email, age, username, password);
                return "Se agregó nuevo empleado " + name;
            }
        }//End NewProvider

        public DataTable ListEmployee()
        {
            return EMPLOYEE.GetDataEmployees();
        }

        public string UpdateEmployee(int idRol, string name, string address, int phone, string email, int age, string username, string password, int id)
        {
            int existe;
            existe = Convert.ToInt32(Employee.ScalarQueryEmployees(name));
            if (existe > 1)
                return "Error: el empleado " + name + " ya existe previamente";
            else
            {
                Employee.UpdateQueryEmployees(idRol, name, address, phone, email, age, username, password, id);
                return "Se editó el empleado con registro: " + id;
            }
        }

        public string GetInfo(string username)
        {
            return Convert.ToString(employeesTableAdapter.GetPasswordByUsername(username));
            
        }

        public string GetID(string username)
        {
            return Convert.ToString(employeesTableAdapter.GetIdRolByUsername(username));
        }
    }
}

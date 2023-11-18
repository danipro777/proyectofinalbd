using DAL;
using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalLogin
    {
        public byte[] EncryptPassword(string username, string password)
        {
            EmployeesTableAdapter tableAdapter = new EmployeesTableAdapter(); 
            return (byte[])tableAdapter.FillByEncryptLogin(username, password);
        }
    }
}
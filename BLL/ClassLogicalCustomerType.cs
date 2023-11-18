using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalCustomerType
    {
        private CustomerTypeTableAdapter CustomerType = null;
        private CustomerTypeTableAdapter CUSTOMERTYPE
        {
            get
            {
                if (CustomerType == null)
                    CustomerType = new CustomerTypeTableAdapter();
                return CustomerType;
            }
        }
        //Metodos
        public DataTable ListCustomerType()
        {
            return CUSTOMERTYPE.GetDataCustomerType();
        }

        /// <summary>
        /// Método que grabará una nueva editorial
        /// </summary>
        /// <param name="nombre">refiere al nombre de la editorial</param>
        /// <param name="pais">refiere al pais de la editorial</param>
        /// <returns></returns>
        public string NewCustomerType(string type, decimal discount)
        {
            int existe;
            existe = Convert.ToInt32(CUSTOMERTYPE.ScalarQueryCustomerType(type));
            if (existe > 0)
                return "Error: El tipo cliente " + type + " ya existe previamente";
            else
            {
                CUSTOMERTYPE.InsertQueryCustomerType(type, discount);
                return "Se agregó nuevo tipo cliente " + type;
            }
        }//Fin Nuevo CustomerType


        public string UpdateCustomerType(string type, decimal discount, int id)
        {
            int existe;
            existe = Convert.ToInt32(CustomerType.ScalarQueryCustomerType(type));
            if (existe > 1)
                return "Error: el tipo cliente " + type + " ya existe previamente";
            else
            {
                CustomerType.UpdateQueryCustomerType(type, discount, id);
                return "Se editó el tipo cliente con registro: " + id;
            }
        }//Fin editarCustomerType
    }
}

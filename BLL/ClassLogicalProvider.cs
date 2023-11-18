using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class ClassLogicalProvider
    {
        private ProviderTableAdapter Provider = null;
        private ProviderTableAdapter PROVIDER
        {
            get
            {
                if (Provider == null)
                    Provider = new ProviderTableAdapter();
                return Provider;
            }
        }

        //METHODS
        public string NewProvider(string name, string address, int phone, string email)
        {
            int existe;
            existe = Convert.ToInt32(PROVIDER.ScalarQueryProvider(name));
            if (existe > 0)
                return "Error: El proveedor " + name + " ya existe previamente";
            else
            {
                PROVIDER.InsertQueryProvider(name, address, phone, email);
                return "Se agregó nuevo proveedor " + name;
            }
        }//End NewProvider

        public DataTable ListProvider()
        {
            return PROVIDER.GetDataProvider();
        }

        public string UpdateProvider(string name, string address, int phone, string email, int id)
        {
            int existe;
            existe = Convert.ToInt32(Provider.ScalarQueryProvider(name));
            if (existe > 1)
                return "Error: el proveedor " + name + " ya existe previamente";
            else
            {
                Provider.UpdateQueryProvider(name, address, phone, email, id);
                return "Se editó el proveedor con registro: " + id;
            }
        }

    }
}

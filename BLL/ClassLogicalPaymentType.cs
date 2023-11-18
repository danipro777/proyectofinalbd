using DAL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicalPaymentType
    {
        private PaymentTypeTableAdapter PaymentType = null;
        private PaymentTypeTableAdapter PAYMENTTYPE
        {
            get
            {
                if (PaymentType == null)
                    PaymentType = new PaymentTypeTableAdapter();
                return PaymentType;
            }
        }

        //Metodos
        public DataTable ListPaymentType()
        {
            return PAYMENTTYPE.GetDataPaymentType();
        }

        public string NewPaymentType(string payment)
        {
            int existe;
            existe = Convert.ToInt32(PAYMENTTYPE.ScalarQueryPaymentType(payment));
            if (existe > 0)
                return "Error: El tipo de pago " + payment + " ya existe previamente";
            else
            {
                PAYMENTTYPE.InsertQueryPaymentType(payment);
                return "Se agregó nuevo tipo de pago " + payment;
            }
        }//Fin Nuevo PaymentType

        public string UpdatePaymentType(string payment, int id)
        {
            int existe;
            existe = Convert.ToInt32(PaymentType.ScalarQueryPaymentType(payment));
            if (existe > 1)
                return "Error: El tipo de pago " + payment + " ya existe previamente";
            else
            {
                PaymentType.UpdateQueryPaymentType(payment, id);
                return "Se editó el tipo de pago con registro: " + id;
            }
        }//Fin editarPaymentType
    }
}

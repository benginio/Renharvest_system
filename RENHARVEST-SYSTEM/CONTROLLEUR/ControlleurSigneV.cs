using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.CONTROLLEUR
{
    public class ControlleurSigneV
    {
        private ModeleSigneV sign;
        public ControlleurSigneV()
        {
            sign = new ModeleSigneV();
        }

        public void AjouterSigneV(string code, string codePatient, string poids, string temperature, string tensionA, string createdby, string datecreated)
        {
            this.sign = new ModeleSigneV(code, codePatient, poids, temperature, tensionA, createdby, datecreated);
        }

        public string CodeSigneV(string codepatient)
        {
            return sign.CodeSigneV(codepatient);
        }

        public DataSet GetListerSigneV()
        {
            return (sign.ListerSigneV());
        }

        public DataSet GetListerSigne(string codePatient)
        {
            return (sign.ListerSigne(codePatient));
        }

        public string getCode()
        {
            if (sign != null)
                return sign.Code;
            else
                return null;
        }

        public string getCodePatient()
        {
            if (sign != null)
                return sign.Codepatient;
            else
                return null;
        }

        public string getPoids()
        {
            if (sign != null)
                return sign.Poids;
            else
                return null;
        }

        public string getTemperature()
        {
            if (sign != null)
                return sign.Temperature;
            else
                return null;
        }

        public string getTensionA()
        {
            if (sign != null)
                return sign.TensionA;
            else
                return null;
        }

        public string getCreatedby()
        {
            if (sign != null)
                return sign.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (sign != null)
                return sign.Datecreated;
            else
                return null;
        }


    }
}
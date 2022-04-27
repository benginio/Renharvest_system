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

        public void AjouterSigneV(string code, string codePatient, string poids, string temperature, string tensionA, string taille, string pouls, string createdby, string datecreated)
        {
            this.sign = new ModeleSigneV(code, codePatient, poids, temperature, tensionA, taille, pouls, createdby, datecreated);
            sign.AjouterSigneV();
        }
        public void ModifierSigneV(string code, string codePatient, string poids, string temperature, string tensionA, string taille, string pouls, string createdby, string datecreated)
        {
            this.sign = new ModeleSigneV(code, codePatient, poids, temperature, tensionA, taille, pouls, createdby, datecreated);
            sign.ModifierSigneV();
        }

        public string CodeSigneV()
        {
            return sign.CodeSigneV();
        }
        public void DeleteSigneV(string code)
        {
            sign.DeleteSigneV(code);
        }
        public DataSet GetListerSigneV()
        {
            return (sign.ListerSigneV());
        }
        public bool RechercheSigneVpatient(string codePatient, string datecreated)
        {
            return (sign.RechercheSigneVPatient(codePatient, datecreated));
        }
        public bool RechercheSigneV(string code)
        {
            return (sign.RechercheSigneV(code));
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
        public string getTaille()
        {
            if (sign != null)
                return sign.Taille;
            else
                return null;
        }
        public string getPouls()
        {
            if (sign != null)
                return sign.Pouls;
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
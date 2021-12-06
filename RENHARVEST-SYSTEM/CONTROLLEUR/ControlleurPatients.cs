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
    public class ControlleurPatients
    {
        private ModelePatients patients;
        public ControlleurPatients()
        {
            patients = new ModelePatients();
        }

        public void AjouterPatient(string codePatient, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string job, string g_s, string p_Respon, string lienARespon, string typeP, string createdby, string datecreated)
        {
            this.patients = new ModelePatients(codePatient, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, job, g_s, p_Respon, lienARespon, typeP, createdby, datecreated);
            patients.AjouterPatient();
        }

        public string Codepatient(string nomP, string prenomP)
        {
            return patients.Codepatient(nomP, prenomP);
        }

        public DataSet GetListerPatient()
        {
            return (patients.ListerPatient());
        }




        public string getCodePatient()
        {
            if (patients != null)
                return patients.CodePatient;
            else
                return null;
        }

        public string getNomP()
        {
            if (patients != null)
                return patients.NomP;
            else
                return null;
        }

        public string getPrenomP()
        {
            if (patients != null)
                return patients.PrenomP;
            else
                return null;
        }

        public string getSexe()
        {
            if (patients != null)
                return patients.Sexe;
            else
                return null;
        }

        public string getDateNaiss()
        {
            if (patients != null)
                return patients.DataNaiss;
            else
                return null;
        }

        public string getAdresse()
        {
            if (patients != null)
                return patients.Adresse;
            else
                return null;
        }

        public string getPhone()
        {
            if (patients != null)
                return patients.Phone;
            else
                return null;
        }

        public string getEmail()
        {
            if (patients != null)
                return patients.Email;
            else
                return null;
        }

        public string getJob()
        {
            if (patients != null)
                return patients.Job;
            else
                return null;
        }

        public string getG_S()
        {
            if (patients != null)
                return patients.G_S;
            else
                return null;
        }

        public string getP_Respon()
        {
            if (patients != null)
                return patients.P_Respon;
            else
                return null;
        }

        public string getLienARespon()
        {
            if (patients != null)
                return patients.LienArespon;
            else
                return null;
        }

        public string getTypeP()
        {
            if (patients != null)
                return patients.TypeP;
            else
                return null;
        }

        public string getCreatedby()
        {
            if (patients != null)
                return patients.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (patients != null)
                return patients.Datecreated;
            else
                return null;
        }

    }
}
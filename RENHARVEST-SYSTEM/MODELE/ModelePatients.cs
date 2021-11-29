using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.MODELE
{
    public class ModelePatients
    {
        private DataSet data;
        private string codePatient;
        private string nomP;
        private string prenomP;
        private string adresse;
        private string dateNaiss;
        private string sexe;
        private string statutMatri;
        private string phone;
        private string email;
        private string job;
        private string p_proche;
        private string phone_proche;

        public ModelePatients(string codePatient, string nomP, string prenomP, string dateNaiss, string adresse, string sexe, string phone, string email, string statutMatri, string job, string p_proche, string phone_proche)
        {
            this.codePatient = codePatient;
            this.nomP = nomP;
            this.prenomP = prenomP;
            this.adresse = adresse;
            this.dateNaiss = dateNaiss;
            this.sexe = sexe;
            this.statutMatri = statutMatri;
            this.phone = phone;
            this.email = email;
            this.job = job;
            this.p_proche = p_proche;
            this.phone_proche = phone_proche;
        }

    public ModelePatients() :this(null, null,null, null,null,null,null, null, null, null, null, null)
        { }

    public string CodePatient
        {
            get { return this.codePatient; }
            set { this.codePatient = value; }
        }

        public string NomP
        {
            get { return this.nomP; }
            set { this.nomP = value; }
        }

        public string PrenomP
        {
            get { return this.prenomP; }
            set { this.prenomP = value; }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        public string DataNaiss
        {
            get { return this.dateNaiss; }
            set { this.dateNaiss = value; }
        }

        public string Sexe
        {
            get { return this.sexe; }
            set { this.sexe = value; }
        }

        public string StatutMatri
        {
            get { return this.statutMatri; }
            set { this.statutMatri = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Job
        {
            get { return this.job; }
            set { this.job = value; }
        }

        public string P_proche
        {
            get { return this.p_proche; }
            set { this.p_proche = value; }
        }

        public string Phone_proche
        {
            get { return this.phone_proche; }
            set { this.phone_proche = value; }
        }






    }
}
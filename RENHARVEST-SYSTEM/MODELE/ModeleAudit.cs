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
    public class ModeleAudit
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        //patien et medecin
        private string codePatient;
        private string codeMedecin;
        private string nomP;
        private string prenomP;
        private string sexe;
        private string dateNaiss;
        private string adresse;
        private string phone;
        private string email;
        private string matricule;
        private string job;
        private string g_s;
        private string p_Respon;
        private string lienARespon;
        private string typeP;
        private string special;
        private string dateEmbauch;
        //sign v.
        private string codeS;
        private string poids;
        private string temperature;
        private string tensionA;
        private string taille;
        //end
        //user
        private string pseudo;
        private string password;
        private string status;
        //end
        //RDV
        private string numRDV;
        private string date;
        private string heure;
        //end
        //presction
        private string id;
        private string nbrFois;
        private string nbrFoisP;
        private string quant;
        private string form;
        //end
        //medicament
        private string codeMedic;
        private string nomM;
        private string dosage;
        //end
        //consultation
        private string signe;
        private string symptomes;
        private string histoire;
        private string motif;
        private string dateC;
        private string detail;
        //end
        //paiement
        private string montantA;
        private string montantP;
        private string balance;
        private string modeP;
        //end

        private string createdby;
        private string datecreated;

        public ModeleAudit(string codePatient, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string p_Respon, string lienARespon, string typeP, string codeMedecin, string special, string dateEmbauch, string codeS, string poids, string temperature, string tensionA, string taille, string pseudo, string password, string status)
        {
            this.codePatient = codePatient;
            this.nomP = nomP;
            this.prenomP = prenomP;
            this.sexe = sexe;
            this.dateNaiss = dateNaiss;
            this.adresse = adresse;
            this.phone = phone;
            this.email = email;
            this.matricule = matricule;
            this.job = job;
            this.g_s = g_s;
            this.p_Respon = p_Respon;
            this.lienARespon = lienARespon;
            this.typeP = typeP;
            this.codeMedecin = codeMedecin;
            this.special = special;
            this.dateEmbauch = dateEmbauch;
            this.codeS = codeS;
            this.poids = poids;
            this.temperature = temperature;
            this.tensionA = tensionA;
            this.taille = taille;
            this.pseudo = pseudo;
            this.password = password;
            this.status = status;

            this.createdby = createdby;
            this.datecreated = datecreated;
        }

         
        //public ModeleAudit(): this()
        //{}



    }
}
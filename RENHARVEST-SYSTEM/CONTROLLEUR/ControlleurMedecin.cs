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
    public class ControlleurMedecin
    {
        private ModeleMedecin medecin;
        public ControlleurMedecin()
        {
            medecin = new ModeleMedecin();
        }

        public void CreerMedecin(string codeMedecin, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string special, string dateEmbauch, string typeP, string pseudo, string password, string status, string createdby, string datecreated)
        {
            this.medecin = new ModeleMedecin(codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, special, dateEmbauch, typeP, pseudo, password, status, createdby, datecreated);
            medecin.CreerMedecin();
        }

        public void ModifierMedecin(string codeMedecin, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string special, string dateEmbauch, string typeP, string pseudo, string password, string status, string createdby, string datecreated)
        {
            this.medecin = new ModeleMedecin(codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, special, dateEmbauch, typeP, pseudo, password, status, createdby, datecreated);
            medecin.ModifierMedecin();
        }

        public string CodeMedecin(string nomP, string prenomP)
        {
            return medecin.CodeMedecins(nomP, prenomP);
        }
        public string CodeMedecin1(string nomP, string prenomP)
        {
            return medecin.CodeMedecins(nomP, prenomP);
        }

        public DataSet GetListerMedecin()
        {
            return (medecin.ListerMedecin());
        }
        public DataSet GetListerhisMedecin()
        {
            return (medecin.ListerhisMedecin());
        }


        public DataSet GetListerMedecinN(string nomP)
        {
            return (medecin.ListerMedecinN(nomP));
        }

        public DataSet GetListerMedecinP(string prenomP)
        {
            return (medecin.ListerMedecinP(prenomP));
        }
        public DataSet GetListerMedecinM(string matricule)
        {
            return (medecin.ListerMedecinM(matricule));
        }

        public bool Recherchemedecin(string codeMedecin)
        {
            return (medecin.RechercherMedecin(codeMedecin));
        }



        public string getCodeMedecin()
        {
            if (medecin != null)
                return medecin.CodeMedecin;
            else
                return null;
        }

        public string getNomP()
        {
            if (medecin != null)
                return medecin.NomP;
            else
                return null;
        }

        public string getPrenomP()
        {
            if (medecin != null)
                return medecin.PrenomP;
            else
                return null;
        }

        public string getSexe()
        {
            if (medecin != null)
                return medecin.Sexe;
            else
                return null;
        }

        public string getDateNaiss()
        {
            if (medecin != null)
                return medecin.DataNaiss;
            else
                return null;
        }

        public string getAdresse()
        {
            if (medecin != null)
                return medecin.Adresse;
            else
                return null;
        }

        public string getPhone()
        {
            if (medecin != null)
                return medecin.Phone;
            else
                return null;
        }

        public string getEmail()
        {
            if (medecin != null)
                return medecin.Email;
            else
                return null;
        }

        public string getMatricule()
        {
            if (medecin != null)
                return medecin.Matricule;
            else
                return null;
        }
        public string getJob()
        {
            if (medecin != null)
                return medecin.Job;
            else
                return null;
        }

        public string getG_S()
        {
            if (medecin != null)
                return medecin.G_S;
            else
                return null;
        }

        public string getP_Respon()
        {
            if (medecin != null)
                return medecin.Special;
            else
                return null;
        }

        public string getLienARespon()
        {
            if (medecin != null)
                return medecin.DateEmbauch;
            else
                return null;
        }

        public string getTypeP()
        {
            if (medecin != null)
                return medecin.TypeP;
            else
                return null;
        }

        public string getSpecial()
        {
            if (medecin != null)
                return medecin.Special;
            else
                return null;
        }

        public string getDateEmbauch()
        {
            if (medecin != null)
                return medecin.DateEmbauch;
            else
                return null;
        }
        public string getPseudo()
        {
            if (medecin != null)

                return medecin.Pseudo;
            else
                return null;
        }

        public string getPassword()
        {
            if (medecin != null)
                return medecin.Password;
            else
                return null;
        }

        public string getStatus()
        {
            if (medecin != null)
                return medecin.Status;
            else
                return null;
        }
        public string getCreatedby()
        {
            if (medecin != null)
                return medecin.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (medecin != null)
                return medecin.Datecreated;
            else
                return null;
        }



    }
}
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
    public class ControlleurUser
    {
        private ModeleUser user;
        public ControlleurUser()
        {
            user = new ModeleUser();
        }

        public void CreerUser(string codeUser, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string pseudo, string password, string typeP, string dateEmbauch, string createdby, string datecreated, string status)
        {
            this.user = new ModeleUser(codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, pseudo, password, typeP, dateEmbauch, createdby, datecreated, status);
            user.CreerUser();
        }

        public string CodeUSER(string nomP, string prenomP)
        {
            return user.CodeUSER(nomP, prenomP);
        }

        public bool LoginUser(string pseudo, string password)
        {
            return (user.LoginUser(pseudo, password));
        }
        public DataSet GetListeUser()
        {
            return (user.ListerUser());
        }
        public bool RechercherUser(string codeUser)
        {
            return (user.RechercheUser(codeUser));
        }


        public string getCodeUser()
        {
            if (user != null)
                return user.CodePatient;
            else
                return null;
        }

        public string getNomP()
        {
            if (user != null)
                return user.NomP;
            else
                return null;
        }

        public string getPrenomP()
        {
            if (user != null)
                return user.PrenomP;
            else
                return null;
        }

        public string getSexe()
        {
            if (user != null)
                return user.Sexe;
            else
                return null;
        }

        public string getDateNaiss()
        {
            if (user != null)
                return user.DataNaiss;
            else
                return null;
        }

        public string getAdresse()
        {
            if (user != null)
                return user.Adresse;
            else
                return null;
        }

        public string getPhone()
        {
            if (user != null)
                return user.Phone;
            else
                return null;
        }

        public string getEmail()
        {
            if (user != null)
                return user.Email;
            else
                return null;
        }
        public string getMatricule()
        {
            if (user != null)
                return user.Matricule;
            else
                return null;
        }
        public string getJob()
        {
            if (user != null)
                return user.Job;
            else
                return null;
        }

        public string getG_S()
        {
            if (user != null)
                return user.G_S;
            else
                return null;
        }

        public string getPseudo()
        {
            if (user != null)
                return user.Pseudo;
            else
                return null;
        }

        public string getPassword()
        {
            if (user != null)
                return user.Password;
            else
                return null;
        }

        public string getTypeP()
        {
            if (user != null)
                return user.TypeP;
            else
                return null;
        }
        public string getDateEmbauch()
        {
            if (user != null)
                return user.DateEmbauch;
            else
                return null;
        }

        public string getCreatedby()
        {
            if (user != null)
                return user.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (user != null)
                return user.Datecreated;
            else
                return null;
        }

        public string getStatus()
        {
            if (user != null)
            {
                return user.Status;
            }
            else
            
                return null;
            
        }


    }
}
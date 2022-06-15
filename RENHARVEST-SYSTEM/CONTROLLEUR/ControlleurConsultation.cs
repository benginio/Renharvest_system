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
    public class ControlleurConsultation
    {

        private ModeleConsultation cons;
        public ControlleurConsultation()
        {
            cons = new ModeleConsultation();
        }

        public void AjouterConsultation(string codecons, string codepatient, string codemedecin, string age, string signe, string symptomes, string histoire, string detail, string comment, string createdby, string datecreated, string heurecreated)
        {
            this.cons = new ModeleConsultation(codecons, codepatient, codemedecin, age, signe, symptomes, histoire,  detail, comment, createdby, datecreated, heurecreated);
            cons.AjouterConsultation();
        }
        public string codecons()
        {
            return cons.Codeconsu();
        }
        public string nbrConsToday(string codemedecin)
        {
            return cons.nbrConstoDay(codemedecin);
        }
        public DataSet getListerConsPM(string codepatient, string codemedecin, string datecreated)
        {
            return (cons.ListerConsultationPM(codepatient, codemedecin, datecreated));
        }
        public DataSet getListerCons()
        {
            return (cons.ListerConsultation());
        }
        
         public DataSet getcompConsult()
        {
            return (cons.compConsult());
        }
        public DataSet getListerCons(string codemedecin)
        {
            return (cons.ListerConsultation(codemedecin));
        }
        public DataSet getListerConsPaMe(string codepatient, string codemedecin)
        {
            return (cons.ListerConsultationPaMe(codepatient,codemedecin));
        }


        public bool RechercheConsultationD(string codepatient, string codemedecin, string datecreated)
        {
            return (cons.RechercheConsultationD(codepatient, codemedecin, datecreated));
        }
        public string getCodecons()
        {
            if (cons != null)
            {
                return cons.Codecons;
            }
            else
                return null;
        }
        public string getCodepatient()
        {
            if (cons != null)
            {
                return cons.Codepatient;
            }
            else
                return null;
        }
        public string getCodemedecin()
        {
            if (cons != null)
            {
                return cons.Codemedecin;
            }
            else
                return null;
        }
        public string getAge()
        {
            if (cons != null)
            {
                return cons.Age;
            }
            else
                return null;
        }
        //public string getMotif()
        //{
        //    if (cons != null)
        //    {
        //        return cons.Motif;
        //    }
        //    else
        //        return null;
        //}
        public string getSigne()
        {
            if (cons != null)
            {
                return cons.Signe;
            }
            else
                return null;
        }
        public string getSymptomes()
        {
            if (cons != null)
            {
                return cons.Symptomes;
            }
            else
                return null;
        }
        public string getHistoire()
        {
            if (cons != null)
            {
                return cons.Histoire;
            }
            else
                return null;
        }
       
        public string getDetail()
        {
            if (cons != null)
            {
                return cons.Detail;
            }
            else
                return null;
        }
        public string getComment()
        {
            if (cons != null)
            {
                return cons.Comment;
            }
            else
                return null;
        }
        public string getCreatedby()
        {
            if (cons != null)
            {
                return cons.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {
            if (cons != null)
            {
                return cons.Datecreated;
            }
            else
                return null;
        }
        public string getHeurecreated()
        {
            if (cons != null)
            {
                return cons.Heurecreated;
            }
            else
                return null;
        }


    }
}
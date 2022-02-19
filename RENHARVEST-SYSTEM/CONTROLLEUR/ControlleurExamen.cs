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
    public class ControlleurExamen
    {
        private ModeleExamen exam;
        public ControlleurExamen()
        {
            exam = new ModeleExamen();
        }
        public void AjouterExamen(string codePatient, string descriptionEx, string resultat, string createdby, string datecreated)
        {
            this.exam = new ModeleExamen(codePatient, descriptionEx, resultat, createdby, datecreated);
            exam.AjouterExamen();
        }

        //public void ModifierExament(string codePatient, string descriptionEx, string resultat, string createdby, string datecreated)
        //{
        //    this.exam = new ModeleExamen(codePatient, descriptionEx, resultat, createdby, datecreated);
        //    exam.AjouterExamen();
        //}
        //public DataSet GetListerMaladie()
        //{
        //    return (malad.ListerMaladie());
        //}
        //public DataSet GetListerhisMaladie()
        //{
        //    return (malad.ListerhisMaladie());
        //}
        //public void DeleteM(string codeMed)
        //{
        //    malad.DeleteM(codeMed);
        //}
        //public DataSet GetListerMaladieN(string nomMalad)
        //{
        //    return (malad.ListerMaladieN(nomMalad));
        //}
        //public bool RechercheMaladie(string codeMalad)
        //{
        //    return (malad.RechercheMalad(codeMalad));
        //}

        public string getCodePatient()
        {
            if (exam != null)
            {
                return exam.CodePatient;
            }
            else
                return null;
        }
        public string getDescriptionEx()
        {
            if (exam != null)
            {
                return exam.DescriptionEx;
            }
            else
                return null;
        }
        public string getResultat()
        {
            if (exam != null)
            {
                return exam.Resultat;
            }
            else
                return null;
        }
        public string getCreatedby()
        {
            if (exam != null)
            {
                return exam.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {
            if (exam != null)
            {
                return exam.Datecreated;
            }
            else
                return null;
        }




    }
}
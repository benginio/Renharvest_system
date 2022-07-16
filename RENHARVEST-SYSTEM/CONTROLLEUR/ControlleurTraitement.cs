using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.CONTROLLEUR
{
    public class ControlleurTraitement
    {
        private ModeleTraitement traitement;
        public ControlleurTraitement()
        {
            traitement = new ModeleTraitement();
        }
        public void AjouterTraitement(string numT, string codePatient, string codeMedecin, string durer, string prevention, string createdby, string datecreated)
        {
            this.traitement = new ModeleTraitement(numT, codePatient, codeMedecin, durer, prevention, createdby, datecreated);
            traitement.AjouterTraitement();
        }
        public string CodeTraitement()
        {
            return traitement.CodeTraitement();
        }
        //public void ModifierTraitement(string numT, string codePatient, string codeMedecin, string durer, string prevention,  string createdby, string datecreated)
        //{
        //    this.traitement = new Modeletraitementen(numT, codePatient, codeMedecin, durer, prevention,  createdby, datecreated);
        //    traitement.ModifierTraitement();
        //}
        public DataSet GetListeTraitement(string codePatient, string codeMedecin, string datecreated)
        {
            return (traitement.ListeTraitement(codePatient, codeMedecin, datecreated));
        }
        public DataSet GetListeTraitementAll(string codePatient, string codeMedecin)
        {
            return (traitement.ListeTraitementAll(codePatient, codeMedecin));
        }
        public bool Recherchetraitement(string codePatient, string codeMedecin, string datecreated)
        {
            return traitement.Recherchetraitement(codePatient, codeMedecin, datecreated);
        }

        public string getNumT()
        {
            if (traitement != null)
            {
                return traitement.NumT;
            }
            else
                return null;
        }
        public string getCodePatient()
        {
            if (traitement != null)
            {
                return traitement.CodePatient;
            }
            else
                return null;
        }
        public string getCodeMededcin()
        {
            if (traitement != null)
            {
                return traitement.CodeMedecin;
            }
            else
                return null;
        }
        public string getDurer() 
        { 
            if (traitement != null)
            {
                return traitement.Durer;
            }
            else
                return null;
        }
        public string getPrevention()
        {
            if (traitement != null)
            {
                return traitement.Prevention;
            }
            else
                return null;
        }
        //public string getNumOrdo()
        //{
        //    if (traitement != null)
        //    {
        //        return traitement.NumOrdo;
        //    }
        //    else
        //        return null;
        //}
        public string getCreatedby()
        {
            if (traitement != null)
            {
                return traitement.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {
            if (traitement != null)
            {
                return traitement.Datecreated;
            }
            else
                return null;
        }



    }
}
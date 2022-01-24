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
    public class ControlleurRDV
    {
        private ModeleRDV rdv;
        public ControlleurRDV()
        {
            rdv = new ModeleRDV();
        }

        public void CreerRDV(string codePatient, string codeMedecin, string date, string heure, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(codePatient, codeMedecin, date, heure, createdby, datecreated);
            rdv.CreerRDV();
        }

        public void Modifier(string codePatient, string codeMedecin, string date, string heure, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(codePatient, codeMedecin, date, heure, createdby, datecreated);
            rdv.ModifierRDV();
        }
        public DataSet GetListerRDV()
        {
            return (rdv.ListerRDV());
        }

        public DataSet GetListerMedecin1(string codePatient)
        {
            return (rdv.ListerRDV1(codePatient));
        }


        public string getCodePatient()
        {
            if (rdv != null)
            {
                return rdv.CodePatient;
            }
            else
                return null;
        }

        public string getCodeMedecin()
        {
            if (rdv != null)
            {
                return rdv.CodeMedecin;
            }
            else
                return null;
        }

        public string getDate()
        {
            if (rdv != null) 
            { 
            return rdv.Date;
            }else
            return null;
        }

        public string getHeure()
        {
            if (rdv != null)
            {
                return rdv.Heure;
            }
            else
                return null;
        }

        public string getCreatedby()
        {
            if (rdv != null)
                return rdv.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (rdv != null)
                return rdv.Datecreated;
            else
                return null;
        }

    }
}
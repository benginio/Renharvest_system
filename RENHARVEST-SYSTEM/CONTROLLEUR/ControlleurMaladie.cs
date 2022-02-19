using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.CONTROLLEUR
{
    public class ControlleurMaladie
    {
        private ModeleMaladie malad;
        public ControlleurMaladie()
        {
            malad = new ModeleMaladie();
        }


        public void AjouterMaladie(string codeMalad, string nomMalad, string detail, string createdby, string datecreated)
        {
            this.malad = new ModeleMaladie(codeMalad, nomMalad, detail, createdby, datecreated);
            malad.AjouterMaladie();
        }
        public string CodeMaladie(string nomMalad)
        {
            return malad.CodeMaladie(nomMalad);
        }
        public void ModifierMaladie(string codeMalad, string nomMalad, string detail, string createdby, string datecreated)
        {
            this.malad = new ModeleMaladie(codeMalad, nomMalad, detail, createdby, datecreated);
            malad.ModifierMaladie();
        }
        public DataSet GetListerMaladie()
        {
            return (malad.ListerMaladie());
        }
        public DataSet GetListerhisMaladie()
        {
            return (malad.ListerhisMaladie());
        }
        public void DeleteM(string codeMed)
        {
            malad.DeleteM(codeMed);
        }
        public DataSet GetListerMaladieN(string nomMalad)
        {
            return (malad.ListerMaladieN(nomMalad));
        }
        public bool RechercheMaladie(string codeMalad)
        {
            return (malad.RechercheMalad(codeMalad));
        }

        public string getCodeMalad()
        {
            if (malad != null)
            {
                return malad.CodeMalad;
            }
            else
                return null;
        }
        public string getNomMalad()
        {
            if (malad != null)
            {
                return malad.NomMalad;
            }
            else
                return null;
        }
        public string getDetail()
        {
            if (malad != null)
            {
                return malad.Detail;
            }
            else
                return null;
        }
        public string getCreatedby()
        {
            if (malad != null)
            {
                return malad.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {
            if (malad != null)
            {
                return malad.Datecreated;
            }
            else
                return null;
        }


    }
}
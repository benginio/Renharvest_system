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
    public class ControlleurOrdonnance
    {
        private ModeleOrdonnance ord;
        public ControlleurOrdonnance()
        {
            ord = new ModeleOrdonnance();
        }

        public void AjourterOrdonnace(string numOrd, string createdby, string datecreated)
        {
            this.ord = new ModeleOrdonnance(numOrd, createdby, datecreated);
            ord.AjouterOrdonnance();
        }
        public string NumOrdo()
        {
            return ord.NumOrdo();
        }
        public void Modifierordription(string numOrd, string createdby, string datecreated)
        {
            this.ord = new ModeleOrdonnance(numOrd, createdby, datecreated);
            ord.ModifierOrdonnance();

        }

        public DataSet getListerOrdonnance(string createdby, string codePatient)
        {
            return (ord.ListerOrdonnance(createdby, codePatient));
        }

        public bool Rechercherordription(string numOrd)
        {
            return (ord.RechercherOrdonnance(numOrd));
        }

        
        public string getNumOrd()
        {
            if (ord != null)
            {
                return ord.NumOrd;
            }
            else
                return null;
        }
        public string getCreatedby()
        {
            if (ord != null)
            {
                return ord.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {
            if (ord != null)
            {
                return ord.Datecreated;
            }
            else
                return null;
        }





    }
}
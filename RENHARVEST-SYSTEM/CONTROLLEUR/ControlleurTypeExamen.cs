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
    public class ControlleurTypeExamen
    {
        private ModeleTypeExamen typeEx;
        public ControlleurTypeExamen()
        {
            typeEx = new ModeleTypeExamen();
        }

        public void AjouterTypeEx(string numEx, string description, string createdby, string datecreated)
        {
            this.typeEx = new ModeleTypeExamen(numEx, description, createdby, datecreated);
            typeEx.AjouterTypeEx();
        }
        public string numExs(string description)
        {
            return typeEx.NumExamen(description);
        }
        public void ModifierTypeEx(string numEx, string description, string createdby, string datecreated)
        {
            this.typeEx = new ModeleTypeExamen(numEx, description, createdby, datecreated);
            typeEx.ModifierTypeEx();
        }

        public void DeleteTypeEx(string numEx)
        {
            typeEx.deleteTypeEx(numEx);
        }
        public DataSet GetListerTypeEx()
        {
            return (typeEx.ListerTypeEx());
        }
        public DataSet GetListerTypeExD(string description)
        {
            return (typeEx.ListerTypeExD(description));
        }

        public bool RechercherTypeEx(string numEx)
        {
            return (typeEx.RechercheTypeEx(numEx));
        }

        public string getNumEx()
        {
            if (typeEx != null)
                return typeEx.NumEx;
            else
                return null;
        }
        public string getDescription()
        {
            if (typeEx != null)
                return typeEx.Description;
            else
                return null;
        }
        
        public string getCreatedby()
        {
            if (typeEx != null)
                return typeEx.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (typeEx != null)
                return typeEx.Datecreated;
            else
                return null;
        }





    }
}
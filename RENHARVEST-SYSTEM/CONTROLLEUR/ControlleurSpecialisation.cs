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
    public class ControlleurSpecialisation
    {
        private  ModeleSpecialisation spe;
        public ControlleurSpecialisation()
        {
            spe = new ModeleSpecialisation();
        }

        public void AjouterSpecial(string codeSpecial, string description, string createdby, string datecreated)
        {
            this.spe = new ModeleSpecialisation(codeSpecial, description, createdby, datecreated);
            spe.AjouterSpecial();
        }
        public string NumSpecial()
        {
            return spe.NumSpecial();
        }
        public void ModifierSpecial(string codeSpecial, string description, string createdby, string datecreated)
        {
            this.spe = new ModeleSpecialisation(codeSpecial, description, createdby, datecreated);
            spe.ModifierSpecial();
        }

        public DataSet GetListerSpecial()
        {
            return (spe.ListerSpecial());
        }

        public bool RechercherSpecial(string codeSpecial)
        {
            return (spe.RechercheSpecial(codeSpecial));
        }

        public string getCodeSpecial()
        {
            if (spe != null)
                return spe.CodeSpecial;
            else
                return null;
        }
        public string getDescription()
        {
            if (spe != null)
                return spe.Description;
            else
                return null;
        }
        public string getCreatedby()
        {
            if (spe != null)
                return spe.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (spe != null)
                return spe.Datecreated;
            else
                return null;
        }




    }
}
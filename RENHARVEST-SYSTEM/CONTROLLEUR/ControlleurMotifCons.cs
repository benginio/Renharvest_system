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
    public class ControlleurMotifCons
    {
    private ModeleMotifCons motifCons;
        public ControlleurMotifCons()
        {
            motifCons = new ModeleMotifCons();
        }

        public void AjouterMotifCons(string numMotif, string description, string createdby, string datecreated)
        {
            this.motifCons = new ModeleMotifCons(numMotif, description, createdby, datecreated);
            motifCons.AjouterMotifCons();
        }
        public string numMotifCons(string description)
        {
            return motifCons.numMotifCons(description);
        }
        public void ModifierMotifCons(string numMotif, string description, string createdby, string datecreated)
        {
            this.motifCons = new ModeleMotifCons(numMotif, description, createdby, datecreated);
            motifCons.ModifierMotifCons();
        }

        public void DeleteMotifCons(string numMotif)
        {
            motifCons.deleteMotifCons(numMotif);
        }
        public DataSet GetListerMotifCons()
        {
            return (motifCons.ListerMotifCons());
        }
        public DataSet GetListerMotifConsD(string description)
        {
            return (motifCons.ListerMotifConsD(description));
        }

        public bool RechercherMotifCons(string numMotif)
        {
            return (motifCons.RechercheMotifCons(numMotif));
        }

        public string getNumMotifCons()
        {
            if (motifCons != null)
                return motifCons.NumMotif;
            else
                return null;
        }
        public string getDescription()
        {
            if (motifCons != null)
                return motifCons.Description;
            else
                return null;
        }
        
        public string getCreatedby()
        {
            if (motifCons != null)
                return motifCons.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (motifCons != null)
                return motifCons.Datecreated;
            else
                return null;
        }




    }
}
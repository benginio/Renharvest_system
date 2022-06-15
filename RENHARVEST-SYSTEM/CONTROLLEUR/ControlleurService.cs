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
    public class ControlleurService
    {
        private ModeleService Ser;
        public ControlleurService()
        {
            Ser = new ModeleService();
        }

        public void AjouterService(string codeService, string description, string prix, string createdby, string datecreated)
        {
            this.Ser = new ModeleService(codeService, description, prix, createdby, datecreated);
            Ser.AjouterService();
        }
        public string CodeServices()
        {
            return Ser.NumService();
        }
        public void ModifierService(string codeService, string description, string prix, string createdby, string datecreated)
        {
            this.Ser = new ModeleService(codeService, description, prix, createdby, datecreated);
            Ser.ModifierService();
        }

        public void DeleteService(string codeService)
        {
            Ser.deleteService(codeService);
        }
        public DataSet GetListerService()
        {
            return (Ser.ListerService());
        }

        public bool RechercherService(string codeService)
        {
            return (Ser.RechercheService(codeService));
        }

        public string getCodeService()
        {
            if (Ser != null)
                return Ser.CodeService;
            else
                return null;
        }
        public string getDescription()
        {
            if (Ser != null)
                return Ser.Description;
            else
                return null;
        }
        public string getPrix()
        {
            if (Ser != null)
                return Ser.Prix;
            else
                return null;
        }
        public string getCreatedby()
        {
            if (Ser != null)
                return Ser.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (Ser != null)
                return Ser.Datecreated;
            else
                return null;
        }





    }
}
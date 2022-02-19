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
    public class ControlleurMedicament
    {
        private ModeleMedicament medic;
        public ControlleurMedicament() 
        {
            medic = new ModeleMedicament();
        }

        
        public void AjouterMedicament(string codeMedic, string nomM, string dosage, string createdby, string datecreated)
        {
            this.medic = new ModeleMedicament(codeMedic, nomM, dosage, createdby, datecreated);
                medic.AjouterMedicament();
        }
        public string CodeMedicament(string nomM)
        {
            return medic.CodeMedicament(nomM);
        }
        public void ModifierMedicament(string codeMedic, string nomM, string dosage, string createdby, string datecreated)
        {
            this.medic = new ModeleMedicament(codeMedic, nomM, dosage, createdby, datecreated);
            medic.ModifierMedicament();
        }
        public DataSet GetListerMedicament()
        {
            return (medic.ListerMedicament());
        }
        public DataSet GetListerhisMedicament()
        {
            return (medic.ListerhisMedicament());
        }
        public void DeleteM(string codeMed)
        {
            medic.DeleteM(codeMed);
        }
        public DataSet GetListerMedicamentN(string nomM)
        {
            return (medic.ListerMedicamentN(nomM));
        }
        public bool RechercheMedicament(string codeMedic)
        {
            return (medic.RechercheMedicament(codeMedic));
        }

        public string getCodeMedic()
        {
            if (medic != null)
            {
                return medic.CodeMedic;
            }
            else
                return null; 
        }
        public string getNomM()
        {
            if (medic != null)
            {
                return medic.NomM;
            }
            else
                return null;
        }
        public string getDosage()
        {
            if (medic != null)
            {
                return medic.Dosage;
            }
            else
                return null;
        }
        public string getCreatedby()
        {
            if (medic != null)
            {
                return medic.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {if (medic != null)
            {
                return medic.Datecreated;
            }
            else
                return null;
        }




    }
}
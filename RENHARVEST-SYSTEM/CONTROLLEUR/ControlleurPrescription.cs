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
    public class ControlleurPrescription
    {
        private ModelePrescription presc;
        public ControlleurPrescription()
        {
            presc = new ModelePrescription();
        }

        public void AjouterPrescription( string numOrdo, string codeMedic, string nbrFois, string nbrFoisP, string quant, string form, string createdby, string datecreated)
        {
            this.presc = new ModelePrescription( numOrdo, codeMedic, nbrFois, nbrFoisP, quant, form, createdby, datecreated);
            presc.AjouterPrescription();

        }
        public void ModifierPrescription( string numOrdo, string codeMedic, string nbrFois, string nbrFoisP, string quant, string form, string createdby, string datecreated)
        {
            this.presc = new ModelePrescription( numOrdo, codeMedic, nbrFois, nbrFoisP, quant, form, createdby, datecreated);
            presc.ModifierPrescription();

        }
        public string numPrescription()
        {
            return presc.numPrescription();
        }
        public string Lastdate(string createdby, string codePatient)
        {
            return presc.lastdate(createdby, codePatient);
        }
        public DataSet getListerPrescription(string codeMedecin, string codePatient, string datecreated)
        {
            return (presc.ListerPrescription(codeMedecin, codePatient, datecreated));
        }
        
        public bool RechercherPrescription(string id)
        {
            return (presc.Rechercheprescription(id));
        }

        public string getNumOrdo()
        {
            if (presc != null)
            {
                return presc.NumOrdo;
            }
            else
                return null;
        }
        public string getCodeMedic()
        {
            if (presc != null)
            {
                return presc.CodeMedic;
            }
            else
                return null;
        }
        public string getNbrFois()
        {
            if (presc != null)
            {
                return presc.NbrFois;
            }
            else
                return null;
        }
        public string getNbrFoisP()
        {
            if (presc != null)
            {
                return presc.NbrFoisP;
            }
            else
                return null;
        }
        public string getQuant()
        {
            if (presc != null)
            {
                return presc.Quant;
            }
            else
                return null;
        }
        public string getForm()
        {
            if (presc != null)
            {
                return presc.Form;
            }
            else
                return null;
        }
       
        public string getCreatedby()
        {
            if (presc != null)
            {
                return presc.Createdby;
            }
            else
                return null;
        }
        public string getDatecreated()
        {
            if (presc != null)
            {
                return presc.Datecreated;
            }
            else
                return null;
        }




    }
}
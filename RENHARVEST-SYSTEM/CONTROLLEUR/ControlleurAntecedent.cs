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
    public class ControlleurAntecedent
    {
        private ModeleAntecedent ant;
        public ControlleurAntecedent()
        {
            ant = new ModeleAntecedent();
        }

        public void AjouterAntecedent(string codePatient, string codeMedecin, string typeAntecedent, string descriptionAnt, string dateOperation, string createdby, string datecreated)
        {
            this.ant= new ModeleAntecedent(codePatient, codeMedecin, typeAntecedent, descriptionAnt, dateOperation, createdby, datecreated);
            ant.AjouterAntecedent();
        }
        public DataSet getListeAntecedent(string codePatient, string codeMedecin, string typeAntecedent)
        {
            return ant.ListerAntecedent(codePatient, codeMedecin, typeAntecedent);
        }
        public DataSet getListeAntecedentinfo(string codePatient, string codeMedecin, string typeAntecedent, string datec)
        {
            return ant.ListerAntecedentinfo(codePatient, codeMedecin, typeAntecedent, datec);
        }
        public void DeleteAntecedent(string descriptionAnt, string typeAntecedent)
        {
            ant.DeleteAntecedent(descriptionAnt, typeAntecedent);
        }

        public string getCodePatient()
        {
            if (ant != null)
            {
                return ant.CodePatient;
            }
            return null;
        }
        public string getCodeMedecin()
        {
            if (ant != null)
            {
                return ant.CodeMedecin;
            }
            return null;
        }
        public string getTypeAntecedent()
        {
            if (ant != null)
            {
                return ant.TypeAntecedent;
            }
            return null;
        }
        public string getDescriptionAnt()
        {
            if (ant != null)
            {
                return ant.DescriptionAnt;
            }
            return null;
        }
        public string getDateOperation()
        {
            if (ant != null)
            {
                return ant.DateOperation;
            }
            return null;
        }
        public string getCreatedby()
        {
            if (ant != null)
            {
                return ant.Createdby;
            }
            return null;
        }
        public string getDatecreated()
        {
            if (ant != null)
            {
                return ant.Datecreated;
            }
            return null;
        }



    }
}
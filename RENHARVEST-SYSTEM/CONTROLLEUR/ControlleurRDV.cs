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

        public void CreerRDV(string num, string codePatient, string codeMedecin, string motifRDV, string date, string heure, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(num,codePatient, codeMedecin, motifRDV, date, heure, createdby, datecreated);
            rdv.CreerRDV();
        }

        public void Modifierrdv(string num, string codePatient, string codeMedecin, string motifRDV, string date, string heure, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(num,codePatient, codeMedecin, motifRDV, date, heure, createdby, datecreated);
            rdv.ModifierRDV();
        }
        public string Coderdv()
        {
            return rdv.numrdv();
        }
        public string verifierrdv(string codeMedecin, string date, string heure)
        {
            return rdv.verifierrdv(codeMedecin,date,heure);
        }
        //public DataSet GetListerRDV()
        //{
        //    return (rdv.ListerRDV());
        //}
        public bool Rechercherdv(string num)
        {
            return (rdv.Rechercherrdv(num));
        }
        public string nbrRDVtoDay(string codeMedecin)
        {
            return rdv.nbrRDVtoDay(codeMedecin);
        }
        public string nbrRDVtoDay1()
        {
            return rdv.nbrRDVtoDay1();
        }
        public DataSet GetListerRDV1(string codePatient, string codeMedecin)
        {
            return (rdv.ListerRDV1(codePatient,codeMedecin));
        }
        public DataSet GetListRDVnow(string codeMedecin)
        {
            return (rdv.ListerRDVnow(codeMedecin));
        }
        public DataSet GetListerRDV3( string codeMedecin)
        {
            return (rdv.ListerRDV3(codeMedecin));
        }
        public DataSet GetListerRDVI(string id, string codeMedecin)
        {
            return (rdv.ListerRDVI(id, codeMedecin));
        }
        public DataSet GetListerRDVN(string nom, string codeMedecin)
        {
            return (rdv.ListerRDVN(nom, codeMedecin));
        }
        public DataSet GetListerRDVP(string prenom, string codeMedecin)
        {
            return (rdv.ListerRDVN(prenom, codeMedecin));
        }
        public DataSet GetListerRDVD(string date, string codeMedecin)
        {
            return (rdv.ListerRDVN(date, codeMedecin));
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
        public string getMotifRDV()
        {
            if (rdv != null)
            {
                return rdv.MotifRDV;
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
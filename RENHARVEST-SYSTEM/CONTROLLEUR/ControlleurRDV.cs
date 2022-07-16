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
        //methode ajouter rendez-vous
        public void CreerRDV(string num, string codePatient, string codeMedecin, string motifRDV, string date, string heure, string status, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(num,codePatient, codeMedecin, motifRDV, date, heure, status, createdby, datecreated);
            rdv.CreerRDV();
        }
        //Methode de modification pour un rendez-vous
        public void Modifierrdv(string num, string codePatient, string codeMedecin, string motifRDV, string date, string heure,  string status, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(num,codePatient, codeMedecin, motifRDV, date, heure, status, createdby, datecreated);
            rdv.ModifierRDV();
        }
        //Annuler un rendez-vous
        public void cancelrdv(string num, string codePatient, string codeMedecin, string motifRDV, string date, string heure, string status, string createdby, string datecreated)
        {
            this.rdv = new ModeleRDV(num, codePatient, codeMedecin, motifRDV, date, heure, status, createdby, datecreated);
            rdv.cancelRDV();
        }
        //gere numero pour un rendez-vous
        public string Coderdv()
        {
            return rdv.numrdv();
        }
        //verifier sil y a deja un rendez-vous a cette date
        public string verifierrdv(string codeMedecin, string date, string heure)
        {
            return rdv.verifierrdv(codeMedecin,date,heure);
        }
        //supprimer  un rendez-vous
        public void DeleteRDV(string num, string codeMedecin)
        {
            rdv.DeleteRDV(num,codeMedecin);
        }
        //supprimer  un rendez-vous pour tous
        public void DeleteRDVall(string num)
        {
            rdv.DeleteRDVall(num);
        }
        //Methode rechercher un rendez-vous
        public bool Rechercherdv(string num)
        {
            return (rdv.Rechercherrdv(num));
        }
        public DataSet GetListerRDV()
        {
            return (rdv.ListerRDV());
        }
        //nombre de rendez-vous annuler pour un meddecin aujourd'hui
        public string nbrRDVtoDay(string codeMedecin)
        {
            return rdv.nbrRDVtoDay(codeMedecin);
        }
        //nombre de rendez-vous annuler pour un meddecin aujourd'hui
        public string nbrRDVtoDayCancel(string codeMedecin)
        {
            return rdv.nbrRDVtoDayCancel(codeMedecin);
        }
        //nombre de fille dans un rendez-vous aujourd'hui
        public string nbrRDVfille(string codeMedecin)
        {
            return rdv.nbrRDVfille(codeMedecin);
        }
        //nombre de garcon dans un rendez-vous aujourd'hui
        public string nbrRDVgarc(string codeMedecin)
        {
            return rdv.nbrRDVgarc(codeMedecin);
        }

        //nombre de rendez-vous pour tous
        public string nbrRDVtoDay1()
        {
            return rdv.nbrRDVtoDay1();
        }

        //nombre de rendez-vous annuler pour tous
        public string nbrRDVtoDay1Cancel()
        {
            return rdv.nbrRDVtoDay1Cancel();
        }
        //pour les rendez-vous d'un medecin et un patient precis
        public DataSet GetListerRDV1(string codePatient, string codeMedecin)
        {
            return (rdv.ListerRDV1(codePatient,codeMedecin));
        }

        //list des rendez-vous d'aujourd'hui
        public DataSet GetListRDVnow(string codeMedecin)
        {
            return (rdv.ListerRDVnow(codeMedecin));
        }

        //pour les rendez-vous d'un medecin
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
            return (rdv.ListerRDVP(prenom, codeMedecin));
        }
        public DataSet GetListerRDVD(string date, string codeMedecin)
        {
            return (rdv.ListerRDVD(date, codeMedecin));
        }
        //end**

        //pour les rendez-vous pour tous
        public DataSet GetListerRDVIall(string id)
        {
            return (rdv.ListerRDVIall(id));
        }
        public DataSet GetListerRDVNall(string nom)
        {
            return (rdv.ListerRDVNall(nom));
        }
        public DataSet GetListerRDVPall(string prenom)
        {
            return (rdv.ListerRDVPall(prenom));
        }
        public DataSet GetListerRDVDall(string date)
        {
            return (rdv.ListerRDVDall(date));
        }
        //end**

        //pour les rendez-vous annuler pour un medecin
        public DataSet GetListerRDVCancel(string codeMedecin)
        {
            return (rdv.ListerRDVcancel(codeMedecin));
        }
        public DataSet GetListerRDVICancel(string id, string codeMedecin)
        {
            return (rdv.ListerRDVICancel(id, codeMedecin));
        }
        public DataSet GetListerRDVNCancel(string nom, string codeMedecin)
        {
            return (rdv.ListerRDVNCancel(nom, codeMedecin));
        }
        public DataSet GetListerRDVPCancel(string prenom, string codeMedecin)
        {
            return (rdv.ListerRDVPCancel(prenom, codeMedecin));
        }
        public DataSet GetListerRDVDCancel(string date, string codeMedecin)
        {
            return (rdv.ListerRDVDCancel(date, codeMedecin));
        }
        //end**

        //start*** pour les rendez-vous annuler pour tous
        public DataSet GetListerRDVCancelall()
        {
            return (rdv.ListerRDVcancelall());
        }
        public DataSet GetListerRDVICancelall(string id)
        {
            return (rdv.ListerRDVICancelall(id));
        }
        public DataSet GetListerRDVNCancelall(string nom)
        {
            return (rdv.ListerRDVNCancelall(nom));
        }
        public DataSet GetListerRDVPCancelall(string prenom)
        {
            return (rdv.ListerRDVPCancelall(prenom));
        }
        public DataSet GetListerRDVDCancelall(string date)
        {
            return (rdv.ListerRDVDCancelall(date));
        }
        //end **




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
        public string getStatus()
        {
            if (rdv != null)
            {
                return rdv.Status;
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
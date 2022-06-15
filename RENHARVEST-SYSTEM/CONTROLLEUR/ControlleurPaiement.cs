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
    public class ControlleurPaiement
    {
        private ModelePaiement pay;
        public  ControlleurPaiement()
        {
            pay = new ModelePaiement();
        }

        public void AjouterPaiement(string codePaiement, string codepatient, string codeService, string montantA, string montantP, string balance, string modeP, string createdby, string datecreated)
        {
            this.pay = new ModelePaiement(codePaiement,codepatient, codeService, montantA, montantP, balance, modeP, createdby, datecreated);
            pay.AjouterPaiement();
        }
        public string CodePaiement()
        {
            return pay.NumPaiement();
        }
        public DataSet GetListerPaiement()
        {
            return (pay.ListerPaiment());
        }

        public DataSet GetListerPaiementP(string codePatient)
        {
            return (pay.ListerPaiementP(codePatient));
        }

        public string getCodePaiement()
        {
            if (pay != null)
                return pay.CodePaiement;
            else
                return null;
        }
        public string getCodePatient()
        {
            if (pay != null)
                return pay.Codepatient;
            else
                return null;
        }
        public string getCodeService()
        {
            if (pay != null)
                return pay.CodeService;
            else
                return null;
        }
        public string getMontantA()
        {
            if (pay != null)
                return pay.MontantA;
            else
                return null;
        }
        public string getMontantP()
        {
            if (pay != null)
                return pay.MontantP;
            else
                return null;
        }
        public string getBalance()
        {
            if (pay != null)
                return pay.Balance;
            else
                return null;
        }
        public string getModeP()
        {
            if (pay != null)
                return pay.ModeP;
            else
                return null;
        }

        public string getCreatedby()
        {
            if (pay != null)
                return pay.Createdby;
            else
                return null;
        }

        public string getDatecreated()
        {
            if (pay != null)
                return pay.Datecreated;
            else
                return null;
        }

    }
}
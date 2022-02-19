using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.MODELE
{
    public class ModeleExamen
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codePatient;
        private string descriptionEx;
        private string resultat;
        private string createdby;
        private string datecreated;

        public ModeleExamen(string codePatient, string descriptionEx, string resultat, string createdby, string datecreated)
        {
            this.codePatient = codePatient;
            this.descriptionEx = descriptionEx;
            this.resultat = resultat;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModeleExamen(): this(null, null, null, null, null)
        {

        }
        public string CodePatient
        {
            get { return this.codePatient; }
            set { this.codePatient= value; }
        }
        public string DescriptionEx
        {
            get { return this.descriptionEx; }
            set { this.descriptionEx = value; }
        }
        public string Resultat
        {
            get { return this.resultat; }
            set { this.resultat = value; }
        }
        public string Createdby
        {
            get { return this.createdby; }
            set { this.createdby = value; }
        }
        public string Datecreated
        {
            get { return this.datecreated; }
            set { this.datecreated = value; }
        }

        public void AjouterExamen()
        {
            
            string req = string.Format("INSERT INTO tbexamen VALUES('{0}','{1}','{2}','{3}','{4}')", codePatient, descriptionEx, resultat, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ModifierExamen()
        {
            
            string Req = string.Format("UPDATE tbexamen SET descriptionE='{1}',ResultatE='{2}', createdby='{3}',datecreated='{4}' where codePatient='{0}'", codePatient, descriptionEx, resultat, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}
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
    public class ModeleRDV
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string num;
        private string codePatient;
        private string codeMedecin;
        private string date;
        private string heure;
        private string createdby;
        private string datecreated;

        public ModeleRDV(string codePatient, string codeMedecin, string date, string heure, string createdby, string datecreated)
        {
            this.codePatient = codePatient;
            this.codeMedecin = codeMedecin;
            this.date = date;
            this.heure = heure;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleRDV():this(null, null, null, null, null, null) 
        { }

        public string CodePatient
        {
            get { return this.codePatient; }
            set { this.codePatient = value; }
        }

        public string CodeMedecin
        {
            get { return this.CodeMedecin; }
            set { this.CodeMedecin = value; }
        }

        public string Date
        {
            get { return this.date;}
            set { this.date = value; }
        }

        public string Heure
        {
            get { return this.heure; }
            set { this.heure = value; }
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

        public void CreerRDV()
        {
            string req = string.Format("INSERT INTO tbrendez_vous VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",codePatient, codeMedecin, date, heure, createdby, datecreated);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(req, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ModifierRDV()
        {
            string Req = string.Format("UPDATE tbrendez_vous SET codeMedecin'{1}',date='{2}', heure='{3}',createby='{4}' where codepers='{0}'",num, codeMedecin, date, heure, createdby);
            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ListerRDV()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbrendez_vous");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbrendez_vous");
            con.Close();

            return data;
        }

        public DataSet ListerRDV1(string codePatient)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbrendez_vous     where codePatient='{0}'", codePatient);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbrendez_vous");
            con.Close();

            return data;
        }

    }
}
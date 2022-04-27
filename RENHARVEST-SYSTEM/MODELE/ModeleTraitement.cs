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
    public class ModeleTraitement
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string numT;
        private string codePatient;
        private string codeMedecin;
        private string durer;
        private string prevention;
        //private string numOrdo;
        private string createdby;
        private string datecreated;

        public ModeleTraitement(string numT, string codePatient, string codeMedecin, string durer, string prevention, string createdby, string datecreated)
        {
            this.numT = numT;
            this.codePatient = codePatient;
            this.codeMedecin = codeMedecin;
            this.durer = durer;
            this.prevention = prevention;
            //this.numOrdo = numOrdo;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModeleTraitement() : this( null,null, null, null, null, null, null)
        {

        }
        public string NumT
        {
            get { return this.numT; }
            set { this.numT = value; }
        }
        public string CodePatient
        {
            get { return this.codePatient; }
            set { this.codePatient = value; }
        }
        public string CodeMedecin
        {
            get { return this.codeMedecin; }
            set { this.codeMedecin = value; }
        }
        public string Durer
        {
            get { return this.durer; }
            set { this.durer = value; }
        }
        
        public string Prevention
        {
            get { return this.prevention; }
            set { this.prevention = value; }
        }
        //public string NumOrdo
        //{
        //    get { return this.numOrdo; }
        //    set { this.numOrdo = value; }
        //}
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

        public void AjouterTraitement()
        {

            string req = string.Format("INSERT INTO tbtraitement VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", numT, codePatient, codeMedecin, durer, prevention, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string CodeTraitement()
        {
            string nombre;
            string trait;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbtraitement", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombre = Convert.ToString(count.ToString());
            }
            else
            {
                nombre= "0";
            }
            con.Close();

            trait = "TR" + nombre;
            return trait;
        }
        public void ModifierTraitemtent()
        {

            string Req = string.Format("UPDATE tbtraitement SET durer='{1}', prevention='{2}', createdby='{3}',datecreated='{4}' where numT='{0}'", numT, codePatient, durer, prevention, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool Recherchetraitement(string codePatient, string codeMedecin, string datecreated)
        {
            string chReq = string.Format("SELECT * FROM tbtraitement WHERE  codePatient='{0}' AND codeMedecin='{1}' AND datecreated='{2}'", codePatient, codeMedecin, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            bool trouve = false;

            //try
            //{
            con.Open();
            cmd = new SqlCommand(chReq, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                numT = reader[0].ToString();
                codePatient = reader[1].ToString();
                codeMedecin = reader[2].ToString();
                durer = reader[3].ToString();
                prevention = reader[4].ToString();
                createdby = reader[5].ToString();
                datecreated = reader[6].ToString();
                trouve = true;
            }

            reader.Close();
            con.Close();
            return trouve;
            //  }
            // catch (Exception)
            // {
            //     return trouve;
            //}
        }
            public DataSet ListeTraitement(string codePatient, string codeMedecin, string datecreated)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbtraitement where codePatient='{0}' AND codeMedecin='{1}' AND datecreation='{2}' ORDER BY datecreated DESC", codePatient, codeMedecin, datecreated);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbtraitement");
            con.Close();

            return data;
        }



    }
}
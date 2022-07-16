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
    public class ModeleMotifCons
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string numMotif;
        private string description;
        private string createdby;
        private string datecreated;

        public ModeleMotifCons(string numMotif, string description, string createdby, string datecreated)
        {
            this.numMotif = numMotif;
            this.description = description;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModeleMotifCons() : this(null, null, null, null)
        { }
        public string NumMotif
        {
            get { return this.numMotif; }
            set { this.numMotif = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
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
        public void AjouterMotifCons()
        {
            //string typeAction = "Insertion";
            string req = string.Format("INSERT INTO tbmotifCons VALUES ('{0}','{1}','{2}','{3}')", numMotif, description, createdby, datecreated);
            //string req1 = string.Format("INSERT INTO tbhisPaiement VALUES ('{0}','{1)','{2}','{3}','{4}','{5}','{6}','{7}')", codepatient, montantA, montantP, balance, modeP, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            //SqlCommand cmd1 = null;

            con.Open();
            cmd = new SqlCommand(req, con);
            cmd.ExecuteNonQuery();
            //cmd1 = new SqlCommand(req, con);
            //cmd1.ExecuteNonQuery();
            con.Close();
        }
        public string numMotifCons(string description)
        {
            string nombreService;
            string codeSer;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbmotifCons", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreService = Convert.ToString(count.ToString());
            }
            else
            {
                nombreService = "0";
            }
            con.Close();

            codeSer = description.Substring(0, 3) + nombreService;
            return codeSer;
        }
        public bool RechercheMotifCons(string numMotif)
        {
            string chReq = string.Format("SELECT * FROM tbmotifCons WHERE  numMotif='{0}'", numMotif);

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
                numMotif = reader[0].ToString();
                description = reader[1].ToString();
                createdby = reader[2].ToString();
                datecreated = reader[3].ToString();
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
        public void ModifierMotifCons()
        {
            //string typeAction = "Modification";
            string Req = string.Format("UPDATE tbmotifCons SET description='{1}' WHERE numMotif='{0}'", numMotif, description);
            //string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteMotifCons(string numMotif)
        {
            //string typeAction = "Modification";
            string Req = string.Format("DELETE FROM tbmotifCons where numMotif='{0}'", numMotif);
            //string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerMotifCons()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbmotifCons ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbmotifCons");
            con.Close();

            return data;
        }
        public DataSet ListerMotifConsD(string description)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbmotifCons WHERE description='{0}'",description);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbmotifCons");
            con.Close();

            return data;
        }




    }
}
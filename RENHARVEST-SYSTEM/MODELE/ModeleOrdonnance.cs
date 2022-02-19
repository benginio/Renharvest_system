using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.MODELE
{
    public class ModeleOrdonnance
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string numOrd;
        private string createdby;
        private string datecreated;

        public ModeleOrdonnance(string numOrd, string createdby, string datecreated)
        {
            this.numOrd = numOrd;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleOrdonnance(): this(null, null, null) 
        { }

        public string NumOrd
        {
            get { return this.numOrd; }
            set { this.numOrd = value; }
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

        public void AjouterOrdonnance()
        {
            string Req = string.Format("INSERT INTO tbordonnance VALUES('{0}','{1}','{2}')", numOrd, createdby, datecreated);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
        }
        public string NumOrdo()
        {
            string nombreP;
            string numOrdo;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbordonnance", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreP = Convert.ToString(count.ToString());
            }
            else
            {
                nombreP= "0";
            }
            con.Close();

            numOrdo =nombreP;
            return numOrdo;
        }
        public bool RechercherOrdonnance(string numOrd)
        {
            string chReq = string.Format("SELECT * FROM tbordonnance WHERE  numOrd='{0}'", numOrd);

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
               
                numOrd = reader[0].ToString();
                createdby = reader[1].ToString();
                datecreated = reader[2].ToString();
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
        public void ModifierOrdonnance()
        {
            string Req = string.Format("UPDATE tbordonnance SET createdby='{1}', datecreated='{2}' WHERE numOrd='{0}'", numOrd, createdby, datecreated);
            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);

            cmd.ExecuteNonQuery();
            con.Close();



        }
        public DataSet ListerOrdonnance(string createdby, string codePatient)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbordonnance where createdby='{0}'", createdby);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbordonnance");
            con.Close();

            return data;
        }





    }
}
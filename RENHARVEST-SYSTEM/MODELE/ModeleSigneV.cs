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
    public class ModeleSigneV
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string code;
        private string codePatient;
        private string poids;
        private string temperature;
        private string tensionA;
        private string taille;
        private string pouls;
        private string createdby;
        private string datecreated;

        public ModeleSigneV(string code, string codePatient, string poids, string temperature, string tensionA, string taille, string pouls, string createdby, string datecreated)
        {
            this.code = code;
            this.codePatient = codePatient;
            this.poids = poids;
            this.temperature = temperature;
            this.tensionA = tensionA;
            this.taille = taille;
            this.pouls = pouls;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleSigneV() : this(null, null, null, null, null, null, null, null, null) {}

        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }
        public string Codepatient
        {
            get { return this.codePatient; }
            set { this.codePatient = value; }
        }

        public string Poids
        {
            get { return this.poids; }
            set { this.poids = value; }
        }

        public string Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; }
        }

        public string TensionA
        {
            get { return this.tensionA; }
            set { this.tensionA = value; }
        }
        public string Taille
        {
            get { return this.taille; }
            set { this.taille = value; }
        }
        public string Pouls
        {
            get { return this.pouls; }
            set { this.pouls = value; }
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

        public void AjouterSigneV()
        {
            //string typeAction = "Insertion";
            string Req = string.Format("INSERT INTO tbsigneV VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", code, codePatient, poids, temperature, tensionA, taille, pouls, createdby, datecreated);
            //string Req1 = string.Format("INSERT INTO tbhisSigneV VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", code, codePatient, poids, temperature, tensionA, taille, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
           // SqlCommand cmd1 = null;
            con.Open();

            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            //cmd1 = new SqlCommand(Req1, con);
            //cmd1.ExecuteNonQuery();

            con.Close();

        }

        public string CodeSigneV()
        {
            string nombrePatient;
            string sign;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbsigneV", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombrePatient = Convert.ToString(count.ToString());
            }
            else
            {
                nombrePatient = "0";
            }
            con.Close();

            sign = "SV"+nombrePatient;
            return sign;
        }
        public void ModifierSigneV()
        {
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbsigneV SET poids='{1}', temperature='{2}', tensionA='{3}', taille='{4}', pouls='{5}' where codesigneV='{0}'", code, poids, temperature, tensionA, taille, pouls);
            //string Req1 = string.Format("INSERT INTO tbhisSigneV VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",code,codePatient, poids, temperature, tensionA, taille, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            //SqlCommand cmd1 = new SqlCommand(Req1, con);

            cmd.ExecuteNonQuery();
           // cmd1.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteSigneV(string code)
        {
            string Req = string.Format("DELETE FROM tbsigneV WHERE codesigneV='{0}'", code);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            con.Open();

            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            con.Close();

        }
        public bool RechercheSigneV(string code)
        {
            string chReq = string.Format("SELECT * FROM tbsigneV WHERE  codesigneV='{0}'", code);

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
                code = reader[0].ToString();
                codePatient = reader[1].ToString();
                poids = reader[2].ToString();
                temperature = reader[3].ToString();
                tensionA = reader[4].ToString();
                taille = reader[5].ToString();
                pouls = reader[6].ToString();
                createdby = reader[7].ToString();
                datecreated = reader[8].ToString();
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
        public bool RechercheSigneVPatient(string codePatient,string datecreated)
        {
            string chReq = string.Format("SELECT * FROM tbsigneV WHERE  codePatient='{0}' AND datecreated='{1}' ORDER BY datecreated DESC", codePatient, datecreated);

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
                code = reader[0].ToString();
                codePatient = reader[1].ToString();
                poids = reader[2].ToString();
                temperature = reader[3].ToString();
                tensionA = reader[4].ToString();
                taille = reader[5].ToString();
                pouls = reader[6].ToString();
                createdby = reader[7].ToString();
                datecreated = reader[8].ToString();
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

        public DataSet ListerSigneV()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbsigneV  ORDER BY datecreated DESC ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbsigneV");
            con.Close();

            return data;
        }

        public DataSet ListerSigne(string codePatient)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbsigneV WHERE codePatient='{0}' order by datecreated desc", codePatient);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbsigneV");
            con.Close();

            return data;
        }

    }
}
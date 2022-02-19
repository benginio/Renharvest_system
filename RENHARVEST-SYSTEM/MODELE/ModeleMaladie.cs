using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.MODELE
{
    public class ModeleMaladie
    {
        
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codeMalad;
        private string nomMalad;
        private string detail;
        private string createdby;
        private string datecreated;

        public ModeleMaladie(string codeMalad, string nomMalad, string detail, string createdby, string datecreated)
        {
            this.codeMalad = codeMalad;
            this.nomMalad = nomMalad;
            this.detail = detail;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleMaladie() : this(null, null, null, null, null)
        { }

        public string CodeMalad
        {
            get { return this.codeMalad; }
            set { this.codeMalad = value; }
        }
        public string NomMalad
        {
            get { return this.nomMalad; }
            set { this.nomMalad = value; }
        }
        public string Detail
        {
            get { return this.detail; }
            set { this.detail = value; }
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

        public void AjouterMaladie()
        {
            string typeAction = "Insertion";
            string Req = string.Format("INSERT INTO tbmaladie VALUES('{0}','{1}','{2}','{3}','{4}')", codeMalad, nomMalad, detail, createdby, datecreated);
            string Req1 = string.Format("INSERT INTO tbhisMaladie VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", codeMalad, nomMalad, detail, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            SqlCommand cmd1 = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            cmd1 = new SqlCommand(Req1, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        public string CodeMaladie(string nomMalad)
        {
            string nombreMalad;
            string codeMalad;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbmaladie", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreMalad = Convert.ToString(count.ToString());
            }
            else
            {
                nombreMalad = "0";
            }
            con.Close();

            codeMalad = nomMalad.Substring(0, 2) + nombreMalad;
            return codeMalad;
        }
        public bool RechercheMalad(string codeMalad)
        {
            string chReq = string.Format("SELECT * FROM tbmaladie WHERE  codeMalad='{0}'", codeMalad);

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
                codeMalad = reader[0].ToString();
                nomMalad = reader[1].ToString();
                detail = reader[2].ToString();
                createdby = reader[3].ToString();
                datecreated = reader[4].ToString();
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
        public void ModifierMaladie()
        {
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbmaladie SET nomMalad='{1}',detail='{2}', createdby='{3}', datecreated='{4}' WHERE codeMalad='{0}'", codeMalad, nomMalad, detail, createdby, datecreated);
            string Req1 = string.Format("INSERT INTO tbhismaladie VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", codeMalad, nomMalad, detail, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            SqlCommand cmd1 = new SqlCommand(Req1, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();



        }
        public void DeleteM(string codeMed)
        {

            string Req = string.Format("DELETE FROM tbmaladie WHERE codeMalad='{0}'", codeMed);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerMaladie()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbmaladie order by datecreated desc");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbmaladie");
            con.Close();

            return data;
        }
        public DataSet ListerhisMaladie()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbhismaladie order by datecreated desc");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbhismaladie");
            con.Close();

            return data;
        }
        public DataSet ListerMaladieN(string nomMalad)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbmaladie  WHERE nomMalad='{0}'", nomMalad);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbmaladie");
            con.Close();

            return data;
        }







        }
    }
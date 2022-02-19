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
    public class ModelePrescription
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string id;
        private string numOrdo;
        private string codeMedic;
        private string nbrFois;
        private string nbrFoisP;
        private string quant;
        private string form;
        private string codePatient;
        private string createdby;
        private string datecreated;

        public ModelePrescription(string id, string numOrdo, string codeMedic, string nbrFois, string nbrFoisP, string quant, string form, string codePatient, string createdby, string datecreated)
        {
            this.id = id;
            this.numOrdo = numOrdo;
            this.codeMedic = codeMedic;
            this.nbrFois = nbrFois;
            this.nbrFois = nbrFoisP;
            this.quant = quant;
            this.form = form;
            this.codePatient = codePatient;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModelePrescription(): this(null,null,null, null, null, null, null, null, null, null)
        {

        }
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string NumOrdo
        {
            get { return this.numOrdo; }
            set { this.numOrdo= value; }
        }
        public string CodeMedic
        {
            get { return this.codeMedic; }
            set { this.codeMedic= value; }
        }
        public string NbrFois
        {
            get { return this.nbrFois; }
            set { this.nbrFois = value; }
        }
        public string NbrFoisP
        {
            get { return this.nbrFoisP; }
            set { this.nbrFoisP = value; }
        }
        public string Quant
        {
            get { return this.quant; }
            set { this.quant = value; }
        }
        public string Form
        {
            get { return this.form; }
            set { this.form = value; }
        }
        public string CodePatient
        {
            get { return this.codePatient; }
            set { this.codePatient = value; }
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
        
        public void AjouterPrescription()
        {
            string Req = string.Format("INSERT INTO tbprescription VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", numOrdo, codeMedic, nbrFois, nbrFoisP, quant, form, codePatient, createdby, datecreated);            
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
        }
        public bool Rechercheprescription(string id)
        {
            string chReq = string.Format("SELECT * FROM tbprescription WHERE  id='{0}'", id);

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
                id= reader[0].ToString();
                numOrdo = reader[1].ToString();
                codeMedic = reader[2].ToString();
                nbrFois= reader[3].ToString();
                nbrFoisP = reader[4].ToString();
                quant = reader[5].ToString();
                form = reader[6].ToString();
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
        public void ModifierPrescription()
        {
            string Req = string.Format("UPDATE tbprescription SET numOrd='{1}',codeMedic='{2}', nbrFois='{3}', nbrFoisP='{4}', quant='{5}', form='{6}',   createdby='{7}', datecreated='{8}' WHERE id='{0}'", id, numOrdo, codeMedic, nbrFois, nbrFoisP, quant, form, createdby, datecreated);
            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            
            cmd.ExecuteNonQuery();
            con.Close();



        }
        public DataSet ListerPrescription(string createdby, string codePatient, string datecreated)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePrescription where createdby='{0}' AND codePers='{1}' AND datecreated='{2}'", createdby, codePatient, datecreated);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePrescription");
            con.Close();

            return data;
        }
        public DataSet ListerPrescription1(string createdby, string codePatient)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT distinct datecreated FROM V_listePrescription where createdby='{0}' AND codePers='{1}' ", createdby, codePatient);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePrescription");
            con.Close();

            return data;
        }
      
        public string lastdate(string createdby, string codePatient)
        {
            //string last;
            //string lastDate;
            string command = string.Format("SELECT datecreated FROM V_listePrescription  where numOrd=(SELECT max(numOrd) FROM V_listePrescription) AND createdby='{0}' AND codePers='{1}' ", createdby, codePatient);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(command, con);

            con.Open();
            String date = Convert.ToString(cmd.ExecuteScalar());
            //if (data != null)
            //{
            //    last = Convert.ToString(date.ToString());
            //}
           
            con.Close();

            return date;
        }



    }

}
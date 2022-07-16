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
        private string numOrdo;
        private string codeMedic;
        private string nbrFois;
        private string nbrFoisP;
        private string quant;
        private string form;
        private string createdby;
        private string datecreated;

        public ModelePrescription( string numOrdo, string codeMedic, string nbrFois, string nbrFoisP, string quant, string form, string createdby, string datecreated)
        {
            this.numOrdo = numOrdo;
            this.codeMedic = codeMedic;
            this.nbrFois = nbrFois;
            this.nbrFois = nbrFoisP;
            this.quant = quant;
            this.form = form;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModelePrescription(): this(null, null, null, null, null, null, null, null)
        {

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
            string Req = string.Format("INSERT INTO tbprescription VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", numOrdo, codeMedic, nbrFois, nbrFoisP, quant, form, createdby, datecreated);            
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
        }
        public string numPrescription()
        {
            string nombreP;
            string numOrdo;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbtraitement", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreP = Convert.ToString(count.ToString());
            }
            else
            {
                nombreP = "0";
            }
            con.Close();

            numOrdo = "Tr"+nombreP;
            return numOrdo;
        }
        public bool Rechercheprescription(string id)
        {
            string chReq = string.Format("SELECT * FROM tbprescription WHERE  numOrdo='{0}'", numOrdo);

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
                
                codeMedic = reader[0].ToString();
                nbrFois= reader[1].ToString();
                quant = reader[2].ToString();
                form = reader[3].ToString();
                createdby = reader[4].ToString();
                datecreated = reader[5].ToString();
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
            string Req = string.Format("UPDATE tbprescription SET numOrd='{1}',codeMedic='{2}', nbrFois='{3}', quant='{4}', form='{5}',   createdby='{7}', datecreated='{8}' WHERE id='{0}'", numOrdo, codeMedic, nbrFois, quant, form, createdby, datecreated);
            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            
            cmd.ExecuteNonQuery();
            con.Close();



        }
        public DataSet ListerPrescription(string codeMedecin, string codePatient, string datecreated)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePrescription where codeMedecin='{0}' AND codePatient='{1}' AND datecreated='{2}'", codeMedecin, codePatient, datecreated);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePrescription");
            con.Close();

            return data;
        }
        public DataSet ListerPrescriptionAll(string codeMedecin, string codePatient)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePrescription where codeMedecin='{0}' AND codePatient='{1}' ", codeMedecin, codePatient);

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
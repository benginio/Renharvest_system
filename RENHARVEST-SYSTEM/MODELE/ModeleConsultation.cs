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
    public class ModeleConsultation
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codepatient;
        private string codemedecin;
        //private string motif;
        private string age;
        private string signe;
        private string symptomes;
        private string histoire;
        private string detail;
        private string comment;
        private string createdby;
        private string datecreated;

        public ModeleConsultation(string codepatient, string codemedecin, string age, string signe, string symptomes, string histoire, string detail, string comment, string createdby, string datecreated)
        {
            this.codepatient = codepatient;
            this.codemedecin = codemedecin;
            //this.motif = motif;
            this.age = age;
            this.signe = signe;
            this.symptomes = symptomes;
            this.histoire = histoire;
            this.detail = detail;
            this.comment = comment;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleConsultation(): this(null,  null, null, null, null, null, null, null, null, null) 
        { }

        public string Codepatient
        {
            get { return this.codepatient; }
            set { this.codepatient = value; }
        }

        public string Codemedecin
        {
            get { return this.codemedecin; }
            set { this.codemedecin = value; }
        }
        public string Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        //public string Motif
        //{
        //    get { return this.motif; }
        //    set { this.motif = value; }
        //}
        public string Signe
        {
            get { return this.signe; }
            set { this.signe = value; }
        }
        public string Symptomes
        {
            get { return this.symptomes; }
            set { this.symptomes = value; }
        }
        public string Histoire
        {
            get { return this.histoire; }
            set { this.histoire = value; }
        }

        public string Detail
        { 
            get { return this.detail; }
            set { this.detail = value; }
        }
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
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

        public void AjouterConsultation()
        {
            string Req = string.Format("INSERT INTO tbconsultation VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", codepatient, codemedecin, age, signe, symptomes, histoire, detail, comment, createdby, datecreated);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd= null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ListerConsultation(string codemedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_consultation WHERE codemedecin='{0}' ", codemedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_consultation");
            con.Close();

            return data;
        }
        public DataSet ListerConsultationPM(string codepatient, string codemedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbconsultation WHERE codePatient='{0}' AND codemedecin='{1}'", codepatient, codemedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbconsultation");
            con.Close();

            return data;
        }
        public DataSet ListerConsultation()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbconsultation ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbconsultation");
            con.Close();

            return data;
        }

        //public bool RechercheConsultation(string codePatient)
        //{
        //    string chReq = string.Format("SELECT * FROM V_consultation WHERE  codepers='{0}'", codePatient);

        //    SqlConnection con = new SqlConnection(chcon);
        //    SqlCommand cmd = null;

        //    bool trouve = false;

        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand(chReq, con);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            codePatient = reader[0].ToString();
        //            codemedecin = reader[1].ToString();
        //            dateC = reader[2].ToString();
        //            createdby = reader[3].ToString();
        //            datecreated = reader[4].ToString();
        //            trouve = true;
        //        }

        //        reader.Close();
        //        con.Close();
        //        return trouve;
        //    }
        //    catch (Exception)
        //    {
        //        return trouve;
        //    }

        //}






    }
}
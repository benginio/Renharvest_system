using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.MODELE
{
    public class ModeleConsultation
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codecons;
        private string codepatient;
        private string codemedecin;
        private string motif;
        private string age;
        private string signe;
        private string symptomes;
        private string histoire;
        private string detail;
        private string comment;
        private string createdby;
        private string datecreated;
        private string heurecreated;

        public ModeleConsultation(string codecons, string codepatient, string codemedecin, string motif, string age, string signe, string symptomes, string histoire, string detail, string comment, string createdby, string datecreated, string heurecreated)
        {
            this.codecons = codecons;
            this.codepatient = codepatient;
            this.codemedecin = codemedecin;
            this.motif = motif;
            this.age = age;
            this.signe = signe;
            this.symptomes = symptomes;
            this.histoire = histoire;
            this.detail = detail;
            this.comment = comment;
            this.createdby = createdby;
            this.datecreated = datecreated;
            this.heurecreated = heurecreated;
        }

        public ModeleConsultation() : this(null,null,null, null, null, null, null, null, null, null, null, null, null)
        { }

        public string Codecons
        {
            get { return this.codecons; }
            set { this.codecons = value; }
        }
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
        public string Motif
        {
            get { return this.motif; }
            set { this.motif = value; }
        }
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
        public string Heurecreated
        {
            get { return this.heurecreated; }
            set { this.heurecreated = value; }
        }

        public void AjouterConsultation()
        {
            string Req = string.Format("INSERT INTO tbconsultation VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",codecons, codepatient, codemedecin, motif, age, signe, symptomes, histoire, detail, comment, createdby, datecreated, heurecreated);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string Codeconsu()
        {
            string nombrecons;
            string codecons;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbconsultation", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombrecons = Convert.ToString(count.ToString());
            }
            else
            {
                nombrecons = "0";
            }
            con.Close();

            codecons = "00"+ nombrecons;
            return codecons;
        }
        public DataSet ListerConsultationPaMe(string codepatient, string codemedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbconsultation WHERE codePatient='{0}' AND codemedecin='{1}' ", codepatient, codemedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbconsultation");
            con.Close();

            return data;
        }
        public DataSet ListerConsultation(string codemedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbconsultation WHERE codemedecin='{0}' ORDER BY datecreated DESC ", codemedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbconsultation");
            con.Close();

            return data;
        }
        public DataSet ListerConsultationAll(string codemedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_consultation WHERE codemedecin='{0}' ORDER BY datecreated DESC ", codemedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_consultation");
            con.Close();

            return data;
        }
        public DataSet ListerConsultationPM(string codepatient, string codemedecin, string datecreated)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbconsultation WHERE codePatient='{0}' AND codemedecin='{1}' AND datecreated='{2}' ORDER BY datecreated DESC", codepatient, codemedecin, datecreated);

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
        
        public bool RechercheConsultationD(string codepatient, string codemedecin, string datecreated)
        {
            string chReq = string.Format("SELECT * FROM tbconsultation WHERE  codePatient='{0}' AND codemedecin='{1}' AND datecreated='{2}'", codepatient, codemedecin, datecreated);

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
                codecons = reader[0].ToString();
                codepatient = reader[1].ToString();
                codemedecin = reader[2].ToString();
                age = reader[3].ToString();
                signe = reader[4].ToString();
                motif= reader[5].ToString();
                symptomes = reader[6].ToString();
                histoire = reader[7].ToString();
                detail = reader[8].ToString();
                comment = reader[9].ToString();
                createdby = reader[10].ToString();
                datecreated = reader[11].ToString();
                heurecreated = reader[12].ToString();
                trouve = true;
            }

            reader.Close();
            con.Close();
            return trouve;
            //}
            //catch (Exception)
            //{
            //    return trouve;
            //}

        }
        public string nbrConstoDay(string codemedecin)
        {
            string nombreCon;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM tbconsultation WHERE  codemedecin='{0}' AND datecreated=CONVERT(DATE,GETDATE())", codemedecin);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreCon = Convert.ToString(count.ToString());
            }
            else
            {
                nombreCon = "0";
            }
            con.Close();

            nbrtoday = nombreCon;
            return nbrtoday;
        }
        public string nbrConstoDayall()
        {
            string nombreCon;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM tbconsultation WHERE datecreated=CONVERT(DATE,GETDATE())");
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreCon = Convert.ToString(count.ToString());
            }
            else
            {
                nombreCon = "0";
            }
            con.Close();

            nbrtoday = nombreCon;
            return nbrtoday;
        }
        public string nbrConstoMonthMineur(string mon)
        {
            string nombreCon;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM tbconsultation WHERE  MONTH(datecreated)=MONTH('{0}') and age<18", mon);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreCon = Convert.ToString(count.ToString());
            }
            else
            {
                nombreCon = "0";
            }
            con.Close();

            nbrtoday = nombreCon;
            return nbrtoday;
        }
        public string nbrConstoMonthMageure(string mon)
        {
            string nombreCon;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM tbconsultation WHERE  MONTH(datecreated)=MONTH('{0}') and age>18", mon);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreCon = Convert.ToString(count.ToString());
            }
            else
            {
                nombreCon = "0";
            }
            con.Close();

            nbrtoday = nombreCon;
            return nbrtoday;
        }
        public string nbrConstoMonth(string mon)
        {
            string nombreCon;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM tbconsultation WHERE  MONTH(datecreated)=MONTH('{0}')", mon);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreCon = Convert.ToString(count.ToString());
            }
            else
            {
                nombreCon = "0";
            }
            con.Close();

            nbrtoday = nombreCon;
            return nbrtoday;
        }
        public DataSet compConsult(string mon)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT codeMalad, nomMalad, COUNT(*) 'nbr fois' FROM V_consRecently where MONTH(datecreated)=MONTH('{0}') GROUP BY codeMalad, nomMalad",mon);
            //and  MONTH(tbconsultation.datecreated)=MONTH('{0}')
            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_consRecently");
            con.Close();

            return data;
        }


    }
}
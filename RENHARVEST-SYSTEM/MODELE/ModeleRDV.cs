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
        private string motifRDV;
        private string date;
        private string heure;
        private string createdby;
        private string datecreated;

        public ModeleRDV(string codePatient, string codeMedecin, string motifRDV, string date, string heure, string createdby, string datecreated)
        {
            this.codePatient = codePatient;
            this.codeMedecin = codeMedecin;
            this.motifRDV = motifRDV;
            this.date = date;
            this.heure = heure;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleRDV():this(null,null, null, null, null, null, null) 
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
        public string MotifRDV
        {
            get { return this.motifRDV; }
            set { this.motifRDV = value; }
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
           // string typeAction = "Insertion";
            string req = string.Format("INSERT INTO tbrendez_vous VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, motifRDV, date, heure, createdby, datecreated);
           // string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

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

        public void ModifierRDV()
        {
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbrendez_vous SET codeMedecin='{1}', motifRDV='{2}',date='{3}', heure='{4}',createby='{5}' where codepers='{0}'",num, codeMedecin, motifRDV, date, heure, createdby);
            string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AnnulerRDV(string codePatient, string codeMedecin, string createdby, string datecreated)
        {
            string typeAction = "Annulation";
            string Req = string.Format("DELETE FROM tbrendez_vous where codepers='{0}' AND codeMedecin='{1}'", codePatient, codeMedecin);
            string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //public DataSet ListerRDV()
        //{
        //    SqlDataAdapter adapter;
        //    SqlConnection con;

        //    con = new SqlConnection(chcon);
        //    string command = string.Format("SELECT * FROM tbrendez_vous");

        //    con.Open();
        //    adapter = new SqlDataAdapter(command, con);
        //    SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
        //    data = new DataSet();

        //    adapter.Fill(data, "tbrendez_vous");
        //    con.Close();

        //    return data;
        //}
        public string nbrRDVtoDay(string codeMedecin)
        {
            string nombreRDV;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM V_listeRDV WHERE codeMedecin='{0}' AND daterdv=CONVERT(DATE, GETDATE())", codeMedecin);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreRDV = Convert.ToString(count.ToString());
            }
            else
            {
                nombreRDV = "0";
            }
            con.Close();

            nbrtoday =  nombreRDV;
            return nbrtoday;
        }
        public DataSet ListerRDV1(string codePatient, string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV where codePatient='{0}' AND codeMedecin='{1}'", codePatient, codeMedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeRDV");
            con.Close();

            return data;
        }
        public DataSet ListerRDVnow(string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV where codeMedecin='{0}' AND daterdv=CONVERT(DATE, GETDATE())", codeMedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeRDV");
            con.Close();

            return data;
        }
        public DataSet ListerRDV3(string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV where codeMedecin='{0}' ", codeMedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeRDV");
            con.Close();

            return data;
        }

    }
}
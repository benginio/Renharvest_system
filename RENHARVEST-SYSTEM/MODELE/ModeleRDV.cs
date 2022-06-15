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

        public ModeleRDV(string num, string codePatient, string codeMedecin, string motifRDV, string date, string heure, string createdby, string datecreated)
        {
            this.num = num;
            this.codePatient = codePatient;
            this.codeMedecin = codeMedecin;
            this.motifRDV = motifRDV;
            this.date = date;
            this.heure = heure;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleRDV():this(null,null,null, null, null, null, null, null) 
        { }

        public string Num
        {
            get { return this.num; }
            set { this.num = value; }
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
        public string numrdv()
        {
            string nombrePatient;
            string codePatient;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbrendez_vous", con);

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

            codePatient = "00" + nombrePatient;
            return codePatient;
        }
        public void CreerRDV()
        {
           // string typeAction = "Insertion";
            string req = string.Format("INSERT INTO tbrendez_vous VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", num, codePatient, codeMedecin, motifRDV, date, heure, createdby, datecreated);
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
            //string typeAction = "Modification";
            string Req = string.Format("UPDATE tbrendez_vous SET codeMedecin='{1}', motifRDV='{2}',daterdv='{3}', heure='{4}' where id='{0}'",num, codeMedecin, motifRDV, date, heure);
            //string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string verifierrdv(string codeMedecin, string date, string heure)
        {
            string nombrePatient;
            string codePatient;
            string Req = string.Format("SELECT COUNT(*) FROM tbrendez_vous WHERE codeMedecin='{0}' AND daterdv='{1}' AND heure='{2}'",codeMedecin,date,heure);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(Req, con);

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

            codePatient =nombrePatient;
            return codePatient;
        }
        public bool Rechercherrdv(string num)
        {
            string chReq = string.Format("SELECT * FROM tbrendez_vous WHERE  id='{0}'", num);

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
                num = reader[0].ToString();
                codePatient= reader[1].ToString();
                codeMedecin = reader[2].ToString();
                motifRDV = reader[3].ToString();
                date = reader[4].ToString();
                heure = reader[5].ToString();
                createdby = reader[6].ToString();
                datecreated = reader[7].ToString();
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
        public string nbrRDVtoDay1()
        {
            string nombreRDV;
            string nbrtoday;
            string Req = string.Format("SELECT COUNT(*) FROM V_listeRDV WHERE daterdv=CONVERT(DATE, GETDATE())");
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

            nbrtoday = nombreRDV;
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
        public DataSet ListerRDVN(string nom, string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV  where nomP='{0}' AND codeMedecin='{1}'", nom, codeMedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeRDV");
            con.Close();

            return data;
        }
        public DataSet ListerRDVP(string prenom, string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV  where prenomP='{0}' AND codeMedecin='{1}'", prenom, codeMedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeRDV");
            con.Close();

            return data;
        }
        public DataSet ListerRDVD(string date, string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV  where daterdv='{0}' AND codeMedecin='{1}'", date, codeMedecin);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeRDV");
            con.Close();

            return data;
        }
        public DataSet ListerRDVI(string id, string codeMedecin)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeRDV  where id='{0}' AND codemedecin='{1}'", id, codeMedecin);

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
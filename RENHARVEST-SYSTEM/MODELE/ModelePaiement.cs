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
    public class ModelePaiement
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codePaiement;
        private string codepatient;
        private string codeService;
        private string montantA;
        private string montantP;
        private string balance;
        private string modeP;
        private string createdby;
        private string datecreated;

        public ModelePaiement(string codePaiement, string codepatient, string codeService, string montantA, string montantP, string balance, string modeP, string createdby, string datecreated)
        {
            this.codePaiement = codePaiement;
            this.codepatient = codepatient;
            this.codeService = codeService;
            this.montantA = montantA;
            this.montantP = montantP;
            this.balance = balance;
            this.modeP = modeP;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModelePaiement() :this(null, null, null, null,null, null, null, null, null)
        { }
        public string CodePaiement
        {
            get { return this.codePaiement; }
            set { this.codePaiement = value; }
        }
        public string Codepatient
        {
            get { return this.codepatient; }
            set { this.codepatient = value; }
        }
        public string CodeService
        {
            get { return this.codeService; }
            set { this.codeService = value; }
        }
        public string MontantA
        {
            get { return this.montantA; }
            set { this.montantA = value; }
        }
        public string MontantP
        {
            get { return this.montantP; }
            set { this.montantP = value; }
        }
        public string Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
        public string ModeP
        {
            get { return this.modeP; }
            set { this.modeP = value; }
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

        public void AjouterPaiement()
        {
            //string typeAction = "Insertion";
            string req = string.Format("INSERT INTO tbpaiement VALUES ('{0}','{1)','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",codePaiement, codepatient, codeService, montantA, montantP, balance, modeP, createdby, datecreated);
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
        public string NumPaiement()
        {
            string nombrePaiement;
            string codePaie;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbpaiement", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombrePaiement = Convert.ToString(count.ToString());
            }
            else
            {
                nombrePaiement = "0";
            }
            con.Close();

            codePaie = "P" + nombrePaiement;
            return codePaie;
        }
        public bool RecherchePaiement(string id)
        {
            string chReq = string.Format("SELECT * FROM tbpaiement WHERE  codesigneV='{0}'", id);

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
                id = reader[0].ToString();
                codepatient = reader[1].ToString();
                montantA = reader[2].ToString();
                montantP = reader[3].ToString();
                balance = reader[4].ToString();
                modeP = reader[5].ToString();
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

        public DataSet ListerPaiment()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbpaiement ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbpaiement");
            con.Close();

            return data;
        }

        public DataSet ListerPaiementP(string codePatient)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbpaiement WHERE codePatient='{0}'", codePatient);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbpaiement");
            con.Close();

            return data;
        }

    }
}
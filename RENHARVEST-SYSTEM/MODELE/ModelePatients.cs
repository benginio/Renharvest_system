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
    public class ModelePatients
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codePatient;
        private string nomP;
        private string prenomP;
        private string sexe;
        private string dateNaiss;
        private string adresse;
        private string phone;
        private string email;
        private string job;
        private string g_s;
        private string p_Respon;
        private string lienARespon;
        private string typeP;
        private string createdby;
        private string datecreated;

        public ModelePatients(string codePatient, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string job, string g_s, string p_Respon, string lienARespon, string typeP, string createdby, string datecreated)
        {
            this.codePatient = codePatient;
            this.nomP = nomP;
            this.prenomP = prenomP;
            this.sexe = sexe;
            this.dateNaiss = dateNaiss;
            this.adresse = adresse;
            this.phone = phone;
            this.email = email;
            this.job = job;
            this.g_s = g_s;
            this.p_Respon = p_Respon;
            this.lienARespon = lienARespon;
            this.typeP = typeP;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

    public ModelePatients() :this(null, null,null, null,null,null,null, null, null, null, null, null, null, null, null)
        { }

    public string CodePatient
        {
            get { return this.codePatient; }
            set { this.codePatient = value; }
        }

        public string NomP
        {
            get { return this.nomP; }
            set { this.nomP = value; }
        }

        public string PrenomP
        {
            get { return this.prenomP; }
            set { this.prenomP = value; }
        }

        public string Sexe
        {
            get { return this.sexe; }
            set { this.sexe = value; }
        }

        public string DataNaiss
        {
            get { return this.dateNaiss; }
            set { this.dateNaiss = value; }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Job
        {
            get { return this.job; }
            set { this.job = value; }
        }

        public string G_S
        {
            get { return this.g_s; }
            set { this.g_s = value; }
        }

        public string P_Respon
        {
            get { return this.p_Respon; }
            set { this.p_Respon = value; }
        }

        public string LienArespon
        {
            get { return this.lienARespon; }
            set { this.lienARespon = value; }
        }

        public string TypeP
        {
            get { return this.typeP; }
            set { this.typeP= value; }
        }

        public string Createdby
        {
            get { return this.createdby; }
            set { this.createdby= value; }
        }

        public string Datecreated
        {
            get { return this.datecreated; }
            set { this.datecreated = value; }
        }

       
        public void AjouterPatient()
        {
            string Req = string.Format("INSERT INTO tbpersonne VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", codePatient, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, job, g_s, p_Respon, lienARespon, typeP, createdby, datecreated);
            string Req2 = string.Format("INSERT INTO tbpatient VALUES ('{0}'",codePatient);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            string Req1 = string.Format("INSERT INTO tbadresse VALUES ('{0}')",adresse);

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd = new SqlCommand(Req1, con);
            cmd = new SqlCommand(Req2, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public string Codepatient(string nomP, string prenomP)
        {
              string nombrePatient;
              string codePatient;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbpatient", con);

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

            codePatient = nomP.Substring(0, 2) + prenomP.Substring(0, 2) + nombrePatient;
            return codePatient;
        }

        public DataSet ListerPatient()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbpatient");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbpatient");
            con.Close();

            return data;
        }




    }
}
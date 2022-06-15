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
    public class ModeleService
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codeService;
        private string description;
        private string prix;
        private string createdby;
        private string datecreated;

         public ModeleService(string codeService, string description, string prix, string createdby, string datecreated)
        {
            this.codeService = codeService;
            this.description = description;
            this.prix = prix;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModeleService() : this( null, null, null, null, null)
        { }
        public string CodeService
        {
            get { return this.codeService; }
            set { this.codeService = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public string Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
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
        public void AjouterService()
        {
            //string typeAction = "Insertion";
            string req = string.Format("INSERT INTO tbservice VALUES ('{0}','{1)','{2}','{3}','{4}')", codeService,description, prix, createdby, datecreated);
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
        public string NumService()
        {
            string nombreService;
            string codeSer;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbservice", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreService = Convert.ToString(count.ToString());
            }
            else
            {
               nombreService = "0";
            }
            con.Close();

            codeSer = "Ser" + nombreService;
            return codeSer;
        }
        public bool RechercheService(string codeService)
        {
            string chReq = string.Format("SELECT * FROM tbservice WHERE  codeService='{0}'", codeService);

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
                codeService = reader[0].ToString();
                description = reader[1].ToString();
                prix = reader[2].ToString();
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
        public void ModifierService()
        {
            //string typeAction = "Modification";
            string Req = string.Format("UPDATE tbservice SET description='{1}', prix='{2}'where codeService='{0}'", codeService, description, prix);
            //string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteService(string codeService)
        {
            //string typeAction = "Modification";
            string Req = string.Format("DELETE * FROM tbservice where codeService='{0}'", codeService);
            //string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerService()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbservice ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbservice");
            con.Close();

            return data;
        }




    }
}
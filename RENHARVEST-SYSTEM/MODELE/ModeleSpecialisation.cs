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
    public class ModeleSpecialisation
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codeSpecial;
        private string description;
        private string createdby;
        private string datecreated;

        public ModeleSpecialisation(string codeSpecial, string description, string createdby, string datecreated)
        {
            this.codeSpecial = codeSpecial;
            this.description = description;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }
        public ModeleSpecialisation() : this( null, null, null, null)
        { }
        public string CodeSpecial
        {
            get { return this.codeSpecial; }
            set { this.codeSpecial = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
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
        public void AjouterSpecial()
        {
            //string typeAction = "Insertion";
            string req = string.Format("INSERT INTO tbspecialisation VALUES ('{0}','{1)','{2}','{3}','{4}')", codeSpecial, description,createdby, datecreated);
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
        public string NumSpecial()
        {
            string nombreSpecial;
            string codeSpe;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbspecialisation", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreSpecial = Convert.ToString(count.ToString());
            }
            else
            {
               nombreSpecial = "0";
            }
            con.Close();

            codeSpe = "Spe" + nombreSpecial;
            return codeSpe;
        }
        public bool RechercheSpecial(string codeSpecial)
        {
            string chReq = string.Format("SELECT * FROM tbspecialisation WHERE  codeSpecial='{0}'", codeSpecial);

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
                codeSpecial = reader[0].ToString();
                description = reader[1].ToString();
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
        public void ModifierSpecial()
        {
            //string typeAction = "Modification";
            string Req = string.Format("UPDATE tbservice SET description='{1}' where codeService='{0}'", codeSpecial, description);
            //string req1 = string.Format("INSERT INTO tbhisRDV VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", codePatient, codeMedecin, date, heure, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerSpecial()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbspecialisation ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbspecialisation");
            con.Close();

            return data;
        }




    }
}
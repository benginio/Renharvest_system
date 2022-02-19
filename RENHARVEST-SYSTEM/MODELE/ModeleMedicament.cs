using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;
using System.Configuration;
using System.Data.SqlClient;

namespace RENHARVEST_SYSTEM.MODELE
{
    public class ModeleMedicament
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codeMedic;
        private string nomM;
        private string dosage;
        private string createdby;
        private string datecreated;

        public ModeleMedicament(string codemedeic, string nomM, string dosage, string createdby, string datecreated)
        {
            this.codeMedic = codemedeic;
            this.nomM = nomM;
            this.dosage = dosage;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

        public ModeleMedicament() : this(null, null, null, null, null)
        { }

        public string CodeMedic
        {
            get { return this.codeMedic; }
            set { this.codeMedic = value; }
        }
        public string NomM
        {
            get { return this.nomM; }
            set { this.nomM = value; }
        }
        public string Dosage
        {
            get { return this.dosage; }
            set { this.dosage = value; }
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

        public void AjouterMedicament()
        {
            string typeAction = "Insertion";
            string Req = string.Format("INSERT INTO tbmedicament VALUES('{0}','{1}','{2}','{3}','{4}')", codeMedic, nomM, dosage, createdby, datecreated);
            string Req1 = string.Format("INSERT INTO tbhisMedicament VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", codeMedic, nomM, dosage, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            SqlCommand cmd1 = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            cmd1 = new SqlCommand(Req1, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        public string CodeMedicament(string nomM)
        {
            string nombreMedic;
            string codemedic;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbmedicament", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreMedic = Convert.ToString(count.ToString());
            }
            else
            {
                nombreMedic = "0";
            }
            con.Close();

            codemedic = nomM.Substring(0, 2) + nombreMedic;
            return codemedic;
        }
        public bool RechercheMedicament(string codeMedic)
        {
            string chReq = string.Format("SELECT * FROM tbmedicament WHERE  codeMed='{0}'", codeMedic);

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
                nomM = reader[1].ToString();
                dosage = reader[2].ToString();
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
        public void ModifierMedicament()
        {
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbmedicament SET nomM='{1}',dosage='{2}', createdby='{3}', datecreated='{4}' WHERE codeMed='{0}'", codeMedic, nomM, dosage, createdby, datecreated);
            string Req1 = string.Format("INSERT INTO tbhisMedicament VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", codeMedic, nomM, dosage, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            SqlCommand cmd1 = new SqlCommand(Req1, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();



        }
        public void DeleteM(string codeMed)
        {
            
            string Req = string.Format("DELETE FROM tbmedicament WHERE codeMed='{0}'", codeMed);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerMedicament()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbmedicament order by datecreated desc");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbmedicament");
            con.Close();

            return data;
        }
        public DataSet ListerhisMedicament()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbhismedicament order by datecreated desc");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbhismedicament");
            con.Close();

            return data;
        }
        public DataSet ListerMedicamentN(string nomM)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbmedicament  WHERE nomM='{0}'", nomM);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbmedicament");
            con.Close();

            return data;
        }




    }
}
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
    public class ModeleAntecedent
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codePatient;
        private string codeMedecin;
        private string typeAntecedent;
        private string descriptionAnt;
        private string dateOperation;
        private string createdby;
        private string datecreated;

        public ModeleAntecedent(string codePatient, string codeMedecin, string typeAntecedent, string descriptionAnt, string dateOperation, string createdby, string datecreated)
        {
            this.codePatient = codePatient;
            this.codeMedecin = codeMedecin;
            this.typeAntecedent = typeAntecedent;
            this.descriptionAnt = descriptionAnt;
            this.dateOperation = dateOperation;
            this.createdby = createdby;
            this.datecreated = datecreated;

        }
        public ModeleAntecedent() : this(null, null, null, null, null, null, null)
        {

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
        public string TypeAntecedent
        {
            get { return this.typeAntecedent; }
            set { this.typeAntecedent = value; }
        }
        public string DescriptionAnt
        {
            get { return this.descriptionAnt; }
            set { this.descriptionAnt = value; }
        }
        public string DateOperation
        {
            get { return this.dateOperation; }
            set { this.dateOperation = value; }
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

        public void AjouterAntecedent()
        {
            string Req = string.Format("INSERT INTO tbantecedent (codePatient,codeMedecin,typeAntecedent, descriptionAnt, dateOperation, createdby,datecreated) VALUES ('" + codePatient + "','" + codeMedecin + "', '" + typeAntecedent + "','" + descriptionAnt + "','" + dateOperation + "', '" + createdby + "', '" + datecreated + "')"); 
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //public string CodeAnt()
        //{
        //    string nombre;
        //    string Ant;
        //    SqlConnection con = new SqlConnection(chcon);
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbantecedent", con);

        //    con.Open();
        //    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
        //    if (count > 0)
        //    {
        //        nombre = Convert.ToString(count.ToString());
        //    }
        //    else
        //    {
        //        nombre = "0";
        //    }
        //    con.Close();

        //    Ant = "Ant" + nombre;
        //    return Ant;
        //}
        public void DeleteAntecedent(string descriptionAnt, string typeAntecedent)
        {
            string Req = string.Format("DELETE FROM tbantecedent WHERE descriptionAnt='{0}' And typeAntecedent='{1}'",descriptionAnt,typeAntecedent);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerAntecedent(string codePatient, string codeMedecin, string typeAntecedent)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbantecedent where codePatient='{0}' AND codeMedecin='{1}' AND typeAntecedent='{2}' ORDER BY datecreated DESC", codePatient, codeMedecin, typeAntecedent);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbantecedent");
            con.Close();

            return data;
        }
        public DataSet ListerAntecedentinfo(string codePatient, string codeMedecin, string typeAntecedent, string datec)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbantecedent where codePatient='{0}' AND codeMedecin='{1}' AND typeAntecedent='{2}' AND datecreated='{3}' ORDER BY datecreated DESC", codePatient, codeMedecin, typeAntecedent, datec);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbantecedent");
            con.Close();

            return data;
        }

        


    }
}
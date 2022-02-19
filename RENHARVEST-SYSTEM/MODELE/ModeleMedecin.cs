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
    public class ModeleMedecin
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codeMedecin;
        private string nomP;
        private string prenomP;
        private string sexe;
        private string dateNaiss;
        private string adresse;
        private string phone;
        private string email;
        private string matricule;
        private string job;
        private string g_s;
        private string special;
        private string dateEmbauch;
        private string typeP="Medecin";
        private string createdby;
        private string datecreated;
        private string pseudo;
        private string password;
        private string status;

        public ModeleMedecin(string codeMedecin, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string special, string dateEmbauch, string typeP, string pseudo, string password, string status, string createdby, string datecreated)
        {
            this.codeMedecin = codeMedecin;
            this.nomP = nomP;
            this.prenomP = prenomP;
            this.sexe = sexe;
            this.dateNaiss = dateNaiss;
            this.adresse = adresse;
            this.phone = phone;
            this.email = email;
            this.matricule = matricule;
            this.job = job;
            this.g_s = g_s;
            this.special = special;
            this.dateEmbauch = dateEmbauch;
            this.typeP = typeP;
            this.pseudo = pseudo;
            this.password = password;
            this.createdby = createdby;
            this.status = status;
            this.datecreated = datecreated;
        }

        public ModeleMedecin() : this(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null)
        { }
        public string CodeMedecin
        {
            get { return this.codeMedecin; }
            set { this.codeMedecin = value; }
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

        public string Matricule
        {
            get { return this.matricule; }
            set { this.matricule = value; }
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

        public string Special
        {
            get { return this.special; }
            set { this.special = value; }
        }

        public string DateEmbauch
        {
            get { return this.dateEmbauch; }
            set { this.dateEmbauch = value; }
        }

        public string TypeP
        {
            get { return this.typeP; }
            set { this.typeP = value; }
        }

        public string Pseudo
        {
            get { return this.pseudo; }
            set { this.pseudo = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
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


        public void CreerMedecin()
        {
            string typeAction = "Insertion";
            string Req = string.Format("INSERT INTO tbpersonne VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, createdby, datecreated);
            string Req2 = string.Format("INSERT INTO tbmedecin (codeMedecin,codepers, specialisation, createdby,datecreated) VALUES ('" + codeMedecin + "','" + codeMedecin + "', '"+special+"', '" + createdby + "', '" + datecreated + "')");
            string Req3 = string.Format("INSERT INTO tbutilisateur (codepers,status,pseudo,password, dateEmbauch, createdby,datecreated) VALUES ('" + codeMedecin + "', '" + status + "','" + pseudo + "', '" + password + "', '" + dateEmbauch + "', '" + createdby + "', '" + datecreated + "')");
            string Req4 = string.Format("INSERT INTO tbhisUser VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, pseudo, password, dateEmbauch, typeAction, createdby, datecreated);
            string Req5 = string.Format("INSERT INTO tbhisMedecin VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, special, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            SqlCommand cmd3 = null;
            SqlCommand cmd4 = null;
            SqlCommand cmd5 = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            cmd2 = new SqlCommand(Req2, con);
            cmd2.ExecuteNonQuery();

            cmd3 = new SqlCommand(Req3, con);
            cmd3.ExecuteNonQuery();

            cmd4 = new SqlCommand(Req4, con);
            cmd4.ExecuteNonQuery();

            cmd5 = new SqlCommand(Req5, con);
            cmd5.ExecuteNonQuery();
            con.Close();
        }


        public string CodeMedecins(string nomP, string prenomP)
        {
            string nombreMedecin;
            string codeMedecin;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbmedecin", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreMedecin = Convert.ToString(count.ToString());
            }
            else
            {
                nombreMedecin = "0";
            }
            con.Close();

            codeMedecin = nomP.Substring(0, 2) + prenomP.Substring(0, 2) + nombreMedecin;
            return codeMedecin;
        }

        //public string CodeMedecins1(string nomP, string prenomP)
        //{
        //    string nombreUser;
        //    string codeUser;
        //    SqlConnection con = new SqlConnection(chcon);
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbutilisateur", con);

        //    con.Open();
        //    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
        //    if (count > 0)
        //    {
        //        nombreUser = Convert.ToString(count.ToString());
        //    }
        //    else
        //    {
        //        nombreUser = "0";
        //    }
        //    con.Close();

        //    codeUser = "DH"+nomP.Substring(0, 2) + prenomP.Substring(0, 2) + nombreUser;
        //    return codeUser;
        //}

        public void ModifierMedecin()
        {
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbpersonne SET nomP='{1}', prenomP='{2}', sexe='{3}',dateNaiss='{4}', adresse='{5}',  telephone='{6}', email='{7}', matricule='{8}', job='{9}', gps='{10}' where codepers='{0}'", codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s);
            string Req1 = string.Format("UPDATE tbmedecin SET specialisation='{1}', createdby='{2}' WHERE codeMedecin='{0}' ", codeMedecin, special , createdby);
            string Req5 = string.Format("INSERT INTO tbhisMedecin VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", codeMedecin, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, special, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            SqlCommand cmd1 = new SqlCommand(Req1, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        public bool RechercherMedecin(string codeMedecin)
        {
            string chReq = string.Format("SELECT * FROM V_listeMedecin WHERE  codepers='{0}'", codeMedecin);

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
                codeMedecin = reader[0].ToString();
                nomP = reader[1].ToString();
                prenomP = reader[2].ToString();
                sexe = reader[3].ToString();
                dateNaiss = reader[4].ToString();
                adresse = reader[5].ToString();
                phone = reader[6].ToString();
                email = reader[7].ToString();
                matricule = reader[8].ToString();
                job = reader[9].ToString();
                g_s = reader[10].ToString();
                special = reader[11].ToString();
                typeP = reader[12].ToString();
                createdby = reader[13].ToString();
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
        public DataSet ListerMedecin()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeMedecin ORDER BY datecreated DESC");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeMedecin");
            con.Close();

            return data;
        }
        public DataSet ListerhisMedecin()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbhisMedecin  ORDER BY datecreated DESC");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbhisMedecin");
            con.Close();

            return data;
        }

        public DataSet ListerMedecinP(string prenomP)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeMedecin where prenomP='{0}'", prenomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeMedecin");
            con.Close();

            return data;
        }

        public DataSet ListerMedecinN(string nomP)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeMedecin where nomP='{0}'", nomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeMedecin");
            con.Close();

            return data;
        }

        public DataSet ListerMedecinM(string matricule)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeMedecin where matricule='{0}'", matricule);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeMedecin");
            con.Close();

            return data;
        }



    }
}
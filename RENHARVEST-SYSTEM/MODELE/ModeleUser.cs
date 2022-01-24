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
    public class ModeleUser
    {
        string chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
        private DataSet data;
        private string codeUser;
        private string nomP;
        private string prenomP;
        private string sexe;
        private string dateNaiss;
        private string adresse;
        private string phone;
        private string email;
        private string g_s;
        private string pseudo;
        private string password;
        private string typeP;
        private string createdby;
        private string datecreated;
        private string status;

        public ModeleUser(string codeUser, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string g_s, string pseudo, string password, string typeP, string createdby, string datecreated, string status )
        {
            this.codeUser = codeUser;
            this.nomP = nomP;
            this.prenomP = prenomP;
            this.sexe = sexe;
            this.dateNaiss = dateNaiss;
            this.adresse = adresse;
            this.phone = phone;
            this.email = email;
            this.g_s = g_s;
            this.pseudo = pseudo;
            this.password = password;
            this.typeP = typeP;
            this.createdby = createdby;
            this.datecreated = datecreated;
            this.status = status;
        }

        public ModeleUser() : this(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null)
        { }
        public string CodePatient
        {
            get { return this.codeUser; }
            set { this.codeUser = value; }
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


        public string G_S
        {
            get { return this.g_s; }
            set { this.g_s = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Pseudo
        {
            get { return this.pseudo; }
            set { this.pseudo = value; }
        }

        public string TypeP
        {
            get { return this.typeP; }
            set { this.typeP = value; }
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
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public void CreerUser()
        {
            string Req = string.Format("INSERT INTO tbpersonne VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, g_s, typeP, createdby, datecreated);
            string Req2 = string.Format("INSERT INTO tbutilisateur (codepers,pseudo, password,status,createdby,datecreated) VALUES ('" + codeUser + "','" + pseudo + "', '" + password + "', '" + createdby + "', '" + datecreated + "')");
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            cmd2 = new SqlCommand(Req2, con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

     

        public bool LoginUser(string pseudo, string password)
        {
            string chReq = string.Format("select * from tbutilisateur where  pseudo='{0}' and password='{1}'", pseudo, password);

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

               // nomP = reader[1].ToString();
               // prenomP = reader[2].ToString();
               // sexe=reader[3].ToString();
               // dateNaiss=reader[4].ToString();
               // adresse=reader[5].ToString();
               // phone = reader[6].ToString();
               // email = reader[7].ToString();
               // g_s=reader[8].ToString();
                pseudo = reader[1].ToString();
               // email = reader[10].ToString();
                password = reader[2].ToString();
               // datecreated = reader[12].ToString();

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

        public void ModifierUser()
        {
            string Req = string.Format("UPDATE tbpersonne SET nomP'{1}',prenomP='{2}', sexe='{3}',dateNaiss='{4}', adresse='{5}',  telephone='{6}', email='{7}', job='{8}', gps='{9}', persResp='{10}', lienApersResp='{11}' where codepers='{0}'", codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, g_s, typeP, createdby);
            string Req1 = string.Format("UPDATE tbutilisateur SET pseudo='{1}', password='{2}', status='{3}',createdby='{4}' WHERE codeMedecin='{0}' ", pseudo, password, status, createdby);
            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            SqlCommand cmd1 = new SqlCommand(Req1, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerUser()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbutilisateur");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbutilisateur");
            con.Close();

            return data;
        }

        public DataSet ListerUser1(string nom, string prenom)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbutilisateur where nomP='{0}', prenomP='{1}'", nomP, prenomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbutilisateur");
            con.Close();

            return data;
        }



    }
}
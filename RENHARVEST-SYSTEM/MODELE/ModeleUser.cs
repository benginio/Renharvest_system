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
        private string matricule;
        private string job;
        private string g_s;
        private string pseudo;
        private string password;
        private string typeP;
        private string dateEmbauch;
        private string createdby;
        private string datecreated;
        private string status;

        public ModeleUser(string codeUser, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string pseudo, string password, string typeP, string dateEmbauch, string createdby, string datecreated, string status )
        {
            this.codeUser = codeUser;
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
            this.pseudo = pseudo;
            this.password = password;
            this.typeP = typeP;
            this.dateEmbauch = dateEmbauch;
            this.createdby = createdby;
            this.datecreated = datecreated;
            this.status = status;
        }

        public ModeleUser() : this(null,null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null)
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
        public string DateEmbauch
        {
            get { return this.dateEmbauch; }
            set { this.dateEmbauch = value; }
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
            string typeAction = "Insertion";
            string Req = string.Format("INSERT INTO tbpersonne VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, createdby, datecreated);
            string Req2 = string.Format("INSERT INTO tbutilisateur (codepers,pseudo, password,status,dateEmbauch,createdby,datecreated) VALUES ('" + codeUser + "','" + pseudo + "', '" + password + "', '" + status+ "','" + dateEmbauch + "', '" + createdby + "', '" + datecreated + "')");
            string Req3 = string.Format("INSERT INTO tbhisUser VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, pseudo, password, dateEmbauch, typeAction, createdby, datecreated);
            
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            SqlCommand cmd3 = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            cmd2 = new SqlCommand(Req2, con);
            cmd2.ExecuteNonQuery();

            cmd3 = new SqlCommand(Req3, con);
            cmd3.ExecuteNonQuery();
            con.Close();
        }
        public string CodeUSER(string nomP, string prenomP)
        {
            string nombreUser;
            string codeUSER;
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbutilisateur", con);

            con.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                nombreUser = Convert.ToString(count.ToString());
            }
            else
            {
                nombreUser = "0";
            }
            con.Close();

            codeUSER = nomP.Substring(0, 2) + prenomP.Substring(0, 2) + nombreUser;
            return codeUSER;
        }



        public bool LoginUser(string pseudo, string password)
        {
            string chReq = string.Format("select * from V_login where  pseudo='{0}' and password='{1}'", pseudo, password);

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

                codeUser = reader[0].ToString();
                typeP = reader[1].ToString();
                status = reader[2].ToString();
                pseudo = reader[3].ToString();
                // email = reader[10].ToString();
                // datecreated = reader[12].ToString();
                // sexe=reader[3].ToString();
                // dateNaiss=reader[4].ToString();
                // adresse=reader[5].ToString();
                // phone = reader[6].ToString();
                // email = reader[7].ToString();
                // g_s=reader[8].ToString();

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
        public bool RechercheUser(string codeUser)
        {
            string chReq = string.Format("select * from V_listeUtilisateur where  codepers='{0}'", codeUser);

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

                codeUser = reader[0].ToString();
                nomP = reader[1].ToString();
                prenomP = reader[2].ToString();
                sexe = reader[3].ToString();
                dateNaiss = reader[4].ToString();
                adresse=reader[5].ToString();
                phone = reader[6].ToString();
                email = reader[7].ToString();
                matricule = reader[8].ToString();
                job = reader[9].ToString();
                g_s = reader[10].ToString();
                typeP = reader[11].ToString();
                status = reader[12].ToString();
                pseudo = reader[13].ToString();
                password= reader[14].ToString();
                dateEmbauch = reader[15].ToString();
                createdby= reader[16].ToString();
                datecreated = reader[17].ToString();



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
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbpersonne SET nomP'{1}',prenomP='{2}', sexe='{3}',dateNaiss='{4}', adresse='{5}',  telephone='{6}', email='{7}', matricule='{8}', job='{9}', gps='{10}', typeP='{11}', createdby='{12}' where codepers='{0}'", codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, createdby);
            string Req1 = string.Format("UPDATE tbutilisateur SET pseudo='{1}', password='{2}', status='{3}', dateEmbauch='{4}', createdby='{5}' WHERE codeUser='{0}' ", codeUser, pseudo, password, status, dateEmbauch, createdby);
            string Req3 = string.Format("INSERT INTO tbhisUser VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", codeUser, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, pseudo, password, dateEmbauch, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            SqlCommand cmd1 = new SqlCommand(Req1, con);
            SqlCommand cmd2 = new SqlCommand(Req3, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        public DataSet ListerUser()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeUtilisateur");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeUtilisateur");
            con.Close();

            return data;
        }

        public DataSet ListerUserN(string nom)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeUtilisateur where nomP='{0}'", nomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeUtilisateur");
            con.Close();

            return data;
        }
        public DataSet ListerUserP(string prenom)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeUtilisateur where prenomP='{0}'", prenomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeUtilisateur");
            con.Close();

            return data;
        }
        public DataSet ListerUserM(string matricule)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeUtilisateur where matricule='{0}'", matricule);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeUtilisateur");
            con.Close();

            return data;
        }
        public DataSet ListerUserS(string pseudo)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listeUtilisateur where pseudo='{0}'", pseudo);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listeUtilisateur");
            con.Close();

            return data;
        }



    }
}
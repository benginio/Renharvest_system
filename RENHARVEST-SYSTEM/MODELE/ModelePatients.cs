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
        private string matricule;
        private string job;
        private string g_s;
        private string p_Respon;
        private string lienARespon;
        private string typeP = "Patient";
        private string adresseResp;
        private string phoneResp;
        private string createdby;
        private string datecreated;

        public ModelePatients(string codePatient, string nomP, string prenomP, string sexe, string dateNaiss, string adresse, string phone, string email, string matricule, string job, string g_s, string p_Respon, string lienARespon, string adresseResp, string phoneResp, string typeP, string createdby, string datecreated)
        {
            this.codePatient = codePatient;
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
            this.p_Respon = p_Respon;
            this.lienARespon = lienARespon;
            this.adresseResp = adresseResp;
            this.phoneResp = phoneResp;
            this.typeP = typeP;
            this.createdby = createdby;
            this.datecreated = datecreated;
        }

    public ModelePatients() :this(null, null, null, null, null,null, null,null,null,null, null, null, null, null, null, null, null, null)
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
        public string AdresseResp
        {
            get { return this.adresseResp; }
            set { this.adresseResp = value; }
        }
        public string PhoneResp
        {
            get { return this.phoneResp; }
            set { this.phoneResp = value; }
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

       
        public void CreerPatient()
        {
            //string typeAction = "Insertion";
            string Req = string.Format("INSERT INTO tbpersonne VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", codePatient, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, typeP, createdby, datecreated);
            string Req2 = string.Format("INSERT INTO tbpatient (codePatient,codepers,persResp,LienApersResp,adresseResp,phoneResp,createdby,datecreated) VALUES ('" + codePatient + "','" + codePatient+ "','"+p_Respon+"', '"+lienARespon+ "','" + adresseResp + "','" + phoneResp + "', '" + createdby+"', '"+datecreated+"')");
            //string Req3 = string.Format("INSERT INTO tbhisPatient VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')", codePatient, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, p_Respon, lienARespon, typeP, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            //SqlCommand cmd3 = null;

            con.Open();
            cmd = new SqlCommand(Req, con);
            cmd.ExecuteNonQuery();

            cmd2 = new SqlCommand(Req2, con);
            cmd2.ExecuteNonQuery();

            //cmd3 = new SqlCommand(Req3, con);
            //cmd3.ExecuteNonQuery();

            
            con.Close();
        }
        

        public string Codepatient(string nomP, string prenomP)
        {
              
            try
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
            catch
            {
                return codePatient;
            }

        }
        public string Age(string dateNaiss, string codePatient)
        {
            string ages = "";
            string R = string.Format("SELECT DATEDIFF(YEAR, datenaiss, GETDATE()) FROM tbpersonne WHERE codepers='{0}'", codePatient);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(R, con);

            con.Open();
            Int32 annee = Convert.ToInt32(cmd.ExecuteScalar());
            if (annee > 0)
            {
                ages = Convert.ToString(annee.ToString());
            }
            con.Close();
            return ages;
        }

        public bool RecherchePatient(string codePatient)
        {
            string chReq = string.Format("SELECT * FROM V_listePatient WHERE  codepers='{0}'", codePatient);

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
                codePatient = reader[0].ToString();
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
                p_Respon = reader[11].ToString();
                lienARespon = reader[12].ToString();
                typeP = reader[13].ToString();
                createdby = reader[14].ToString();
                datecreated = reader[15].ToString();
                adresseResp= reader[16].ToString();
                phoneResp= reader[17].ToString();
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
        public void ModifierPatient()
        {
            string typeAction = "Modification";
            string Req = string.Format("UPDATE tbpersonne SET nomP='{1}', prenomP='{2}', sexe='{3}', dateNaiss='{4}', adresse='{5}',  telephone='{6}', email='{7}', matricule='{8}', job='{9}', gps='{10}' where codepers='{0}'", codePatient, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s);
            string Req1 = string.Format("UPDATE tbpatient SET persResp='{1}', LienApersResp='{2}', adresseResp='{3}', phoneResp='{4}',createdby='{5}' WHERE codePatient='{0}' ",codePatient, p_Respon, lienARespon,adresseResp,phoneResp, createdby);
            //string Requ = string.Format("INSERT INTO tbhisPatient VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')", codePatient, nomP, prenomP, sexe, dateNaiss, adresse, phone, email, matricule, job, g_s, p_Respon, lienARespon, typeP, typeAction, createdby, datecreated);

            SqlConnection con = new SqlConnection(chcon);


            con.Open();
            SqlCommand cmd = new SqlCommand(Req, con);
            SqlCommand cmd1 = new SqlCommand(Req1, con);
            //SqlCommand cmd2 = new SqlCommand(Requ, con);

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            //cmd2.ExecuteNonQuery();
            con.Close();



        }
        public DataSet ListerPatient()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient ORDER BY datecreated DESC ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient"); 
            con.Close();

            return data;
        }
        public DataSet ListerhisPatient()
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM tbhisPatient ORDER BY datecreated DESC ");

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "tbhisPatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientN(string nomP)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient     where nomP='{0}'", nomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientNS(string nomP, string sexe)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient     where nomP='{0}' AND sexe='{1}'", nomP, sexe);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientP(string prenomP)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient     where prenomP='{0}'", prenomP);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientPS(string prenomP, string sexe)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient     where prenomP='{0}' AND sexe='{1}'", prenomP,sexe);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientS(string sexe)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient     where sexe='{0}'", sexe);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientage(string age1, string age2)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("select * from V_listePatient WHERE DATEDIFF(YEAR, datenaiss, GETDATE()) BETWEEN '{0}' and '{1}'", age1,age2);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public DataSet ListerPatientM(string matricule)
        {
            SqlDataAdapter adapter;
            SqlConnection con;

            con = new SqlConnection(chcon);
            string command = string.Format("SELECT * FROM V_listePatient  where matricule='{0}'", matricule);

            con.Open();
            adapter = new SqlDataAdapter(command, con);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(adapter);
            data = new DataSet();

            adapter.Fill(data, "V_listePatient");
            con.Close();

            return data;
        }
        public string nbrePersonne()
        {
            string nbr = "";
            string R = string.Format("SELECT count(*) FROM tbpatient");
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(R, con);

            con.Open();
            Int32 annee = Convert.ToInt32(cmd.ExecuteScalar());
            if (annee > 0)
            {
                nbr = Convert.ToString(annee.ToString());
            }
            else
            {
                nbr = "0";
            }
            con.Close();
            return nbr;
        }
        public string nbrePatientToday()
        {
            
            string nbr = "";
            string R = string.Format("SELECT count(*) FROM tbpatient where  datecreated=CONVERT(DATE, GETDATE())");
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(R, con);

            con.Open();
            Int32 annee = Convert.ToInt32(cmd.ExecuteScalar());
            if (annee > 0)
            {
                nbr = Convert.ToString(annee.ToString());
            }
            else
            {
                nbr = "0";
            }
            con.Close();
            return nbr;
        }
        public string nbrRDVfille()
        {
            string nombreRDV;
            string nbrtoday;
            string s = "Feminin";
            string Req = string.Format("SELECT COUNT(sexe) FROM V_listePatient WHERE sexe='{0}' GROUP BY sexe", s);
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
        public string nbrRDVgarc()
        {
            string nombreRDV;
            string nbrtoday;
            string s = "Masculin";
            string Req = string.Format("SELECT COUNT(sexe) FROM V_listePatient WHERE sexe='{0}' GROUP BY sexe", s);
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
        public string verifierMatri(string matricule)
        {
            string nbr = "";
            string R = string.Format("SELECT count(*) FROM tbpersonne where matricule='{0}'",matricule);
            SqlConnection con = new SqlConnection(chcon);
            SqlCommand cmd = new SqlCommand(R, con);

            con.Open();
            Int32 nbrMatri = Convert.ToInt32(cmd.ExecuteScalar());
            if (nbrMatri > 0)
            {
                nbr = Convert.ToString(nbrMatri.ToString());
            }
            else
            {
                nbr = "0";
            }
            con.Close();
            return nbr;
        }



    }
}
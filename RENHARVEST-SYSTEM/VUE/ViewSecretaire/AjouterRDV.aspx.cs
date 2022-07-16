using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;
using System.Data;

namespace RENHARVEST_SYSTEM.VUE.ViewSecretaire
{
    public partial class AjouterRDV : System.Web.UI.Page
    {
        private ControlleurRDV rdv = new ControlleurRDV();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        public string chcon;
        public SqlConnection con;
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["pseudo"] != null)
                {

                    tusername.Text = Session["pseudo"].ToString();
                    Username1.Text = Session["pseudo"].ToString();
                    Afficher();
                    getSpecialisation();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }
        void Afficher()
        {
            magride.DataSource = patient.GetListerPatient();
            magride.DataBind();
        }
        void AfficheP()
        {
            magride.DataSource = patient.GetListerPatientP(tsearch.Text);
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = patient.GetListerPatientN(tsearch.Text);
            magride.DataBind();
        }
        void AfficherM()
        {
            magride.DataSource = patient.GetListerPatientM(tsearch.Text);
            magride.DataBind();
        }
        void Vider()
        {
            tmotif.Text = "";
            tdate.Text = "";
            theure.Text = "";
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(tdate.Text);
            string check = rdv.verifierrdv(dropMedecin.Text, tdate.Text, theure.Text);
            if (check.Equals("0"))
            {

                if (d.Date < DateTime.Now.Date)
                {
                    string msg1 = "Swal.fire('Oopss!','vous avez choisir une date passer!','warning')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg1, true);
                    tdate.Text = "";
                    theure.Text = "";
                }
                else
                {
                    string num = rdv.Coderdv();
                    rdv.CreerRDV(num, Label1.Text, dropMedecin.Text, tmotif.Text, tdate.Text, theure.Text, "Active", tusername.Text, datecreated);
                    string msg = "Swal.fire('Sucess!','Enregistrement  reusir!','success')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                    Afficher();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "viewprof1()", true);
                    Vider();
                }
            }
            else
            {
                string msg2 = "Swal.fire('Oopss!','Vous avez deja une RDV a cette Date!','warning')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg2, true);
            }
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterRDV.aspx");
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();

            bool find = patient.Recherchepatient(codepers);
            Label1.Text = codepers;

            Labe1.Text = patient.getNomP();
            Label2.Text = patient.getPrenomP();
        }

        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("ModifierPatient.aspx");
            }
            else
            {
                if (DDtrier.Text.Equals("Prenom"))
                {
                    AfficheP();

                }
                else if (DDtrier.Text.Equals("Nom"))
                {
                    AfficherN();
                }
                else
                {
                    AfficherM();
                }
            }
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterRDV.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        public void connection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Open();

        }

        void getSpecialisation()
        {
            connection();
            SqlCommand com = new SqlCommand("select codepers, (specialisation+'_'+nomP+' '+prenomP) as th from V_listeMedecin ORDER BY specialisation ASC", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            dropMedecin.DataTextField = ds.Tables[0].Columns["th"].ToString(); // text field name of table dispalyed in dropdown
                                                                                        // 
            dropMedecin.DataValueField = ds.Tables[0].Columns["codepers"].ToString();
            // to retrive specific  textfield name   
            dropMedecin.DataSource = ds.Tables[0];     //assigning datasource to the dropdownlist  
            dropMedecin.DataBind();  //binding dropdownlist  
        }

    }
}
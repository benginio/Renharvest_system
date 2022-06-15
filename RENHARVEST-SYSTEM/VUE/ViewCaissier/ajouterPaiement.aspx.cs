using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;
using Stripe;

namespace RENHARVEST_SYSTEM.VUE.ViewCaissier
{
    public partial class ajouterPaiement : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurUser us = new ControlleurUser();
        private ControlleurPaiement pay = new ControlleurPaiement();
        private ControlleurService Ser = new ControlleurService();
        public string chcon;
        public SqlConnection con;
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["codeUser"] != null)
                {
                    Afficher();

                    my = Session["codeUser"].ToString();
                    bool find = us.RechercherUser(my);
                    tusername.Text = us.getPseudo();
                    Username1.Text = us.getPseudo();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
            
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {

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
        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("addPaiement.aspx");
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
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();
            Session["codepers"] = codepers;
            bool find = patient.Recherchepatient(codepers);
            lblnom.Text = patient.getNomP().ToUpper() + " " + patient.getPrenomP();
            ddService();
         
        }

         

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("ajouterPaiement.aspx");
        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            string codePaiement = pay.CodePaiement();
            pay.AjouterPaiement(codePaiement, Session["codepers"].ToString(), ddservice.Text, tprix.Text, montantP.Text, balance.Text, ddmodeP.Text, tusername.Text, tdatenow.Text);
        }
        public void connection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Open();

        }
       
        void ddService()
        {
            connection();
            SqlCommand com = new SqlCommand("select codeService, description from tbservice ORDER BY description ASC", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            ddservice.DataTextField = ds.Tables[0].Columns["description"].ToString(); // text field name of table dispalyed in dropdown
                                                                                      // 
            ddservice.DataValueField = ds.Tables[0].Columns["description"].ToString();
            Session["service"]= ds.Tables[0].Columns["codeService"].ToString();
            // to retrive specific  textfield name   
            ddservice.DataSource = ds.Tables[0];     //assigning datasource to the dropdownlist  
            ddservice.DataBind();  //binding dropdownlist  
        }

        protected void ddservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool find = Ser.RechercherService(Session["service"].ToString());
            tprix.Text = Ser.getPrix();
        }
    }
}
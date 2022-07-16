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

namespace RENHARVEST_SYSTEM.VUE.ViewAdmin
{
    public partial class plannigMedecin : System.Web.UI.Page
    {
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
            magride.DataSource = medecin.GetListerMedecin();
            magride.DataBind();
        }
        void AfficheP()
        {
            magride.DataSource = medecin.GetListerMedecinP(tsearch.Text);
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = medecin.GetListerMedecinN(tsearch.Text);
            magride.DataBind();
        }
        void AfficherS()
        {
            magride.DataSource = medecin.GetListerMedecinS(ddspecial.Text);
            magride.DataBind();
        }
        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("planningMedecin.aspx");
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
                    Response.Redirect("planningMedecin.aspx");
                }
            }
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();

            Session["codeMedecins"] = codepers;
            Response.Redirect("planningMedecin1.aspx");
        }

        protected void DDtrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDtrier.Text.Equals("Specialisation"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "viewprof()", true);
            }
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
            SqlCommand com = new SqlCommand("select description from tbspecialisation ORDER BY description ASC", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            ddspecial.DataTextField = ds.Tables[0].Columns["description"].ToString(); // text field name of table dispalyed in dropdown
                                                                             // 
            ddspecial.DataValueField = ds.Tables[0].Columns["description"].ToString();
            // to retrive specific  textfield name   
            ddspecial.DataSource = ds.Tables[0];     //assigning datasource to the dropdownlist  
            ddspecial.DataBind();  //binding dropdownlist  
        }
        protected void ddspecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherS();
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}
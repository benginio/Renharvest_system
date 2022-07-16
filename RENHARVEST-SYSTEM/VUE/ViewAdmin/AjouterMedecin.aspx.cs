using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;
using System.Data.SqlClient;
using System.Configuration;

namespace RENHARVEST_SYSTEM.VUE.ViewAdmin
{
    public partial class AjouterMedecin : System.Web.UI.Page
    {
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Medecin";
        string codemedecin;
        public string chcon;
        public SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["pseudo"] != null)
                {
                    tusername.Text = Session["pseudo"].ToString();
                    Username1.Text = Session["pseudo"].ToString();
                    ddspecialisation();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        public void connection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Open();

        }
        void ddspecialisation()
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
        public void AjouteMedecin()
        {
            string status = "Actif";
            codemedecin = medecin.CodeMedecin(tnomp.Text, tprenomp.Text);
            medecin.CreerMedecin(codemedecin, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, ddspecial.Text, tdateEmbauch.Text, ttypeP, tpseudo.Text, tpass.Text, status, tusername.Text, tdatenow.Text);
            ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Enregistrement effectuer avec success!','success')", true);

            Vider();
        }
        void Vider()
        {
            codemedecin = "";
            tnomp.Text = "";
            tprenomp.Text = "";
            ddsexe.Text = "";
            tdatenaiss.Text = "";
            tadresse.Text = "";
            tphone.Text = "";
            temail.Text = "";
            tmatricule.Text = "";
            tjob.Text = "";
            ddspecial.Text = "";
            tdateEmbauch.Text = "";
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            AjouteMedecin();
            tcode.Text = codemedecin;
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
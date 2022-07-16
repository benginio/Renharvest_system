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

namespace RENHARVEST_SYSTEM.VUE.ViewSecretaire
{
    public partial class ModifierRDV : System.Web.UI.Page
    {
        private ControlleurRDV rdv = new ControlleurRDV();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
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
                    Afficher();
                    getSpecialisation();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        void Afficher()
        {
            magride.DataSource = rdv.GetListerRDV();
            magride.DataBind();
        }
        void Afficheid()
        {
            magride.DataSource = rdv.GetListerRDVIall(tsearch.Text);
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = rdv.GetListerRDVNall(tsearch.Text);
            magride.DataBind();
        }
        void AfficherP()
        {
            magride.DataSource = rdv.GetListerRDVPall(tsearch.Text);
            magride.DataBind();
        }
        void AfficherD()
        {
            magride.DataSource = rdv.GetListerRDVDall(tsearch.Text);
            magride.DataBind();
        }
        protected void tbnsearch_Click(object sender, EventArgs e)
        {

            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("ModifierRDV.aspx");
            }
            else
            {
                if (DDtrier.Text.Equals("Id RDV"))
                {
                    Afficheid();

                }
                else if (DDtrier.Text.Equals("Nom Patient"))
                {
                    AfficherN();
                }
                else if (DDtrier.Text.Equals("Prenom Patient"))
                {
                    AfficherP();
                }
                else
                {
                    AfficherD();
                }
            }
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifierRDV.aspx");
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
                }
                else
                {
                    rdv.Modifierrdv(Session["numrdv"].ToString(), null, dropMedecin.Text, tmotif.Text, tdate.Text, theure.Text, null, null, null);
                    ClientScript.RegisterClientScriptBlock(GetType(), "id", "up();", true);
                    string msg = "Swal.fire('Sucess!','Modification reusir!','success')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                    Afficher();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "viewprof1()", true);
                }
            }
            else
            {
                string msg2 = "Swal.fire('Oopss!','Vous avez deja une RDV a cette Date!','warning')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg2, true);
            }
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifierRDV.aspx");
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string coderdv = magride.DataKeys[row.RowIndex].Values[0].ToString();
            Session["numrdv"] = coderdv;
            bool find = rdv.Rechercherdv(coderdv);
            tmotif.Text = rdv.getMotifRDV();
            tdate.Text = rdv.getDate();
            theure.Text = rdv.getHeure();
            Label1.Text = rdv.getCodePatient();
            string codeMed = rdv.getCodeMedecin();
            bool find2 = medecin.Recherchemedecin(codeMed);
            //dropMedecin.Text = medecin.getSpecial() + "_" + medecin.getNomP() + " " + medecin.getPrenomP();
            Label3.Text= medecin.getSpecial() + "_" + medecin.getNomP() + " " + medecin.getPrenomP();
            bool find1 = patient.Recherchepatient(Label1.Text);
            Labe1.Text = patient.getNomP();
            Label2.Text = patient.getPrenomP();
        }

        protected void DDtrier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
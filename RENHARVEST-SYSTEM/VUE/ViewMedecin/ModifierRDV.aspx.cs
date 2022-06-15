using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class ModifierRDV : System.Web.UI.Page
    {
        private ControlleurRDV rdv = new ControlleurRDV();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
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
                    bool find = medecin.Recherchemedecin(my);
                    tusername.Text = "Dr." + medecin.getPrenomP();
                    Username1.Text = "Dr." + medecin.getPrenomP();
                    tspecial.Text = "Dr." + medecin.getPrenomP();
                    Label3.Text = my;

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
            magride.DataSource = rdv.GetListerRDV3(Session["codeUser"].ToString());
            magride.DataBind();
        }
        void Afficheid()
        {
            magride.DataSource = rdv.GetListerRDVI(tsearch.Text,Session["codeUser"].ToString());
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = rdv.GetListerRDVN(tbnsearch.Text, Session["codeUser"].ToString());
            magride.DataBind();
        }
        void AfficherP()
        {
            magride.DataSource = rdv.GetListerRDVP(tbnsearch.Text, Session["codeUser"].ToString());
            magride.DataBind();
        }
        void AfficherD()
        {
            magride.DataSource = rdv.GetListerRDVD(tbnsearch.Text, Session["codeUser"].ToString());
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

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            rdv.Modifierrdv(Session["numrdv"].ToString(), null, Session["codeUser"].ToString(),tmotif.Text,tdate.Text,theure.Text,null,null);
            ClientScript.RegisterClientScriptBlock(GetType(), "id", "up();", true);
            string msg = "Swal.fire('Sucess!','Modification reusir!','success')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
            Afficher();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "viewprof1()", true);

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
            tspecial.Text = tusername.Text;
            Label1.Text = rdv.getCodePatient();
            Label3.Text = rdv.getCodeMedecin();

            bool find1 = patient.Recherchepatient(Label1.Text);
            Labe1.Text = patient.getNomP();
            Label2.Text = patient.getPrenomP();
        }
    }
}
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
    public partial class AnnulerRDV : System.Web.UI.Page
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

                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }
        void Afficher()
        {
            magride.DataSource = rdv.GetListerRDV3(Session["codeUser"].ToString());
            magride.DataBind();
        }
        void Afficheid()
        {
            magride.DataSource = rdv.GetListerRDVI(tsearch.Text, Session["codeUser"].ToString());
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
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
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
                else if (DDtrier.Text.Equals("Nom"))
                {
                    AfficherN();
                }
                else if (DDtrier.Text.Equals("Prenom"))
                {
                    AfficherP();
                }
                else
                {
                    AfficherD();
                }
            }
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string coderdv = magride.DataKeys[row.RowIndex].Values[0].ToString();
        }
    }
}
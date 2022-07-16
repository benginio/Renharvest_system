using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewSecretaire
{
    public partial class ListeRDV : System.Web.UI.Page
    {
        private ControlleurRDV rdv = new ControlleurRDV();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
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
            gridlistRDV.DataSource = rdv.GetListerRDV3(Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }
        void Afficheid()
        {
            gridlistRDV.DataSource = rdv.GetListerRDVI(tsearch.Text, Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }
        void AfficherN()
        {
            gridlistRDV.DataSource = rdv.GetListerRDVN(tsearch.Text, Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }
        void AfficherP()
        {
            gridlistRDV.DataSource = rdv.GetListerRDVP(tsearch.Text, Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }
        void AfficherD()
        {
            gridlistRDV.DataSource = rdv.GetListerRDVD(tsearch.Text, Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }
        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("ListeRDV.aspx");
            }
            else
            {
                if (DDtrier.Text.Equals("Id RDV"))
                {
                    Afficheid();

                }
                else if (DDtrier.Text.Equals("Prenom Patient"))
                {
                    AfficherP();
                }
                else if (DDtrier.Text.Equals("Nom Patient"))
                {
                    AfficherN();
                }
                else if(DDtrier.Text.Equals("Date RDV"))
                {
                    AfficherD();
                }
                else
                {
                    Afficher();
                }
            }
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string coderdv = gridlistRDV.DataKeys[row.RowIndex].Values[0].ToString();

            rdv.cancelrdv(coderdv, null, null, null, null, null, "Inactive", null, null);
            Afficher();
        }

        protected void DDtrier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
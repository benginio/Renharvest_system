using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewInfirmiere
{
    public partial class AjouterSigneV : System.Web.UI.Page
    {
        private ControlleurSigneV sign = new ControlleurSigneV();
        private ControlleurPatients patient = new ControlleurPatients();
        string datecreated = DateTime.Now.ToString("MM/dd/yyyy");
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
                Response.Redirect("AjouterSigneV.aspx");
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
            Response.Redirect("AjouterSigneV.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        void SigneV()
        {
            magridSign.DataSource = sign.GetListerSigne(Session["codePatien"].ToString());
            magridSign.DataBind();
        }
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();
            Session["codePatien"] = codepers;
            magridSign.DataSource = sign.GetListerSigne(codepers);
            magridSign.DataBind();

        }
        void Vider()
        {
            tpoid.Text = "";
            ttemp.Text = "";
            tta.Text = "";
            ttaille.Text = "";
        }
        protected void btnsavesign_Click(object sender, EventArgs e)
        {
            string code = sign.CodeSigneV();
            sign.AjouterSigneV(code, Session["codePatien"].ToString(), tpoid.Text, ttemp.Text, tta.Text, ttaille.Text, tmotif.Text, tusername.Text, datecreated);
            SigneV();
            Vider();
        }

        protected void btnretour_Click(object sender, EventArgs e)
        {

        }

        

        protected void btnedit_Click(object sender, EventArgs e)
        {
            LinkButton btn2 = sender as LinkButton;
            GridViewRow row = btn2.NamingContainer as GridViewRow;
            string codepers = magridSign.DataKeys[row.RowIndex].Values[0].ToString();
            Session["codesigneV"] = codepers;
            sign.RechercheSigneV(codepers);
            tpoid.Text = sign.getPoids();
            ttemp.Text=sign.getTemperature();
            tta.Text = sign.getTensionA();
            ttaille.Text = sign.getTaille();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            sign.ModifierSigneV(Session["codesigneV"].ToString(), Session["codePatien"].ToString(), tpoid.Text, ttemp.Text, tta.Text, ttaille.Text, tmotif.Text, tusername.Text, tdatenow.Text);
            SigneV();
            Vider();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Vider();
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {

            LinkButton btn1 = sender as LinkButton;
            GridViewRow row = btn1.NamingContainer as GridViewRow;
            string codesigneV = magridSign.DataKeys[row.RowIndex].Values[0].ToString();
            t.Text = codesigneV;
            sign.DeleteSigneV(codesigneV);
            SigneV();

        }
    }
}
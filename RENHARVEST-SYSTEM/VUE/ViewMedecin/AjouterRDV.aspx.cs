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
    public partial class AjouterRDV : System.Web.UI.Page
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
                Afficher();
                if (Session["codeUser"] != null)
                {


                    my = Session["codeUser"].ToString();
                    bool find = medecin.Recherchemedecin(my);
                    tusername.Text = "Dr." + medecin.getPrenomP();
                    Username1.Text = "Dr." + medecin.getPrenomP();
                    tspecial.Text= "Dr." + medecin.getPrenomP();
                    Label3.Text = my;

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

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            rdv.CreerRDV(Label1.Text, Label3.Text, tmotif.Text, tdate.Text, theure.Text, tusername.Text, datecreated);
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterRDV.aspx");
        }
    }
}
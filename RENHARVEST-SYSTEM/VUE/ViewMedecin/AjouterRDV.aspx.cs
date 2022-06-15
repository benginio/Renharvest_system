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
        string dateSys = DateTime.Now.ToString("MM/dd/yyyy");
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
        void Vider()
        {
            tmotif.Text="";
            tdate.Text = "";
            theure.Text = "";
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(tdate.Text);
            string check = rdv.verifierrdv(Label3.Text,tdate.Text, theure.Text);
            if (check.Equals("0"))
            {

                if (d.Date < DateTime.Now.Date)
                {
                    string msg1 = "Swal.fire('Oopss!','vous avez choisir une date passer!','warning')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg1, true);
                }
                else
                {
                    string num = rdv.Coderdv();
                    rdv.CreerRDV(num, Label1.Text, Label3.Text, tmotif.Text, tdate.Text, theure.Text, tusername.Text, datecreated);
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

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterRDV.aspx");
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            tmotif.Text = "";
            tdate.Text = "";
            Response.Redirect("AjouterRDV.aspx");
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
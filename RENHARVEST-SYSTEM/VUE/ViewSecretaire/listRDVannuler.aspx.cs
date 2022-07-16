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
    public partial class AnnulerRDV : System.Web.UI.Page
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
        void Afficher()
        {
            magride.DataSource = rdv.GetListerRDVCancelall();
            magride.DataBind();
        }
        void Afficheid()
        {
            magride.DataSource = rdv.GetListerRDVICancelall(tsearch.Text);
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
                Response.Redirect("listRDVannuler.aspx");
            }
            else
            {
                if (DDtrier.Text.Equals("Id RDV"))
                {
                    Afficheid();

                }
                else if (DDtrier.Text.Equals("Nom patient"))
                {
                    magride.DataSource = rdv.GetListerRDVNCancelall(tsearch.Text);
                    magride.DataBind();
                }
                else if (DDtrier.Text.Equals("Prenom patient"))
                {
                    magride.DataSource = rdv.GetListerRDVPCancelall(tsearch.Text);
                    magride.DataBind();
                }
                else
                {
                    magride.DataSource = rdv.GetListerRDVDCancelall(tsearch.Text);
                    magride.DataBind();
                }
            }
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string coderdv = magride.DataKeys[row.RowIndex].Values[0].ToString();

            rdv.DeleteRDVall(coderdv);
            Afficher();
        }

        protected void btnreturn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string coderdv = magride.DataKeys[row.RowIndex].Values[0].ToString();
            Session["coderdv"] = coderdv;
            bool find = rdv.Rechercherdv(coderdv);
            tmotif.Text = rdv.getMotifRDV();
            tdate.Text = rdv.getDate();
            theure.Text = rdv.getHeure();
            Label1.Text = rdv.getCodePatient();
            string codeMed = rdv.getCodeMedecin();
            bool find2 = medecin.Recherchemedecin(codeMed);
            dropMedecin.Text = medecin.getSpecial() + "_" + medecin.getNomP() + " " + medecin.getPrenomP();
            bool find1 = patient.Recherchepatient(Label1.Text);
            Labe1.Text = patient.getNomP();
            Label2.Text = patient.getPrenomP();
            
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("listRDVannuler.aspx");
        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(tdate.Text);
            string check = rdv.verifierrdv(Label3.Text, tdate.Text, theure.Text);
            if (check.Equals("0"))
            {

                if (d.Date < DateTime.Now.Date)
                {
                    string msg1 = "Swal.fire('Oopss!','vous avez choisir une date passer!','warning')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg1, true);
                }
                else
                {
                    rdv.Modifierrdv(Session["coderdv"].ToString(), null, dropMedecin.Text, tmotif.Text, tdate.Text, theure.Text, null, null, null);
                    string msg = "Swal.fire('Sucess!','Modification reusir!','success')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                    rdv.cancelrdv(Session["coderdv"].ToString(), null, null, null, null, null, "Active", null, null);
                    Afficher();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "viewprof1()", true);
                }
            }else
                {
                    string msg2 = "Swal.fire('Oopss!','Vous avez deja une RDV a cette Date!','warning')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg2, true);
                }

            }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("listRDVannuler.aspx");
        }

        protected void DDtrier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
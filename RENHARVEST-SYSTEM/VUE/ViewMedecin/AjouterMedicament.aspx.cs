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
    public partial class AjouterMedicament : System.Web.UI.Page
    {
        private ControlleurMedicament med = new ControlleurMedicament();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                
                if (Session["codeUser"] != null)
                {
                    tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                    ListMed();
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

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        public void ListMed()
        {
            magrid.DataSource = med.GetListerMedicament();
            magrid.DataBind();
        }
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMed = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            bool find = med.RechercheMedicament(codeMed);
            tcodeM.Text = codeMed;
            tnomM.Text = med.getNomM();
            tdosage.Text = med.getDosage();

        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMed = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            med.DeleteM(codeMed);
            ListMed();
        }

        protected void btnajouter_Click(object sender, EventArgs e)
        {
            string codeMed = med.CodeMedicament(tnomM.Text);
            med.AjouterMedicament(codeMed,tnomM.Text,tdosage.Text,Session["pseudo"].ToString(),datecreated);
            ListMed();
            Vider();
        }

        protected void btnmodif_Click(object sender, EventArgs e)
        {
            med.ModifierMedicament(tcodeM.Text, tnomM.Text, tdosage.Text, Session["pseudo"].ToString(), datecreated);
            ListMed();
            Vider();
        }
        void Vider()
        {
            tnomM.Text = "";
            tdosage.Text = "";
            tcodeM.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Vider();
        }

        protected void tnomM_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnomM.Text))
            {
                string codeMed = med.CodeMedicament(tnomM.Text);
                tcodeM.Text = codeMed;
            }
        }
    }
}
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
    public partial class AjouterMaladie : System.Web.UI.Page
    {
        private ControlleurMaladie malad = new ControlleurMaladie();
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
            magrid.DataSource = malad.GetListerMaladie();
            magrid.DataBind();
        }
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMalad = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            bool find = malad.RechercheMaladie(codeMalad);
            tcodeM.Text = codeMalad;
            tnomM.Text = malad.getNomMalad();
            tdetail.Text = malad.getDetail();

        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMalad = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            malad.DeleteM(codeMalad);
            ListMed();
        }

        protected void btnajouter_Click(object sender, EventArgs e)
        {
            string codeMed = malad.CodeMaladie(tnomM.Text);
            malad.AjouterMaladie(codeMed, tnomM.Text, tdetail.Text, Session["pseudo"].ToString(), datecreated);
            ListMed();
            Vider();
        }

        protected void btnmodif_Click(object sender, EventArgs e)
        {
           
            malad.ModifierMaladie(tcodeM.Text, tnomM.Text, tdetail.Text, Session["pseudo"].ToString(), datecreated);
            ListMed();
            Vider();
        }
        void Vider()
        {
            tnomM.Text = "";
            tdetail.Text = "";
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
                string codemalad = malad.CodeMaladie(tnomM.Text);
                tcodeM.Text = codemalad;
            }
        }

    }
}

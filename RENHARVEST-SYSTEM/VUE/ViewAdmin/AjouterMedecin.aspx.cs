using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewAdmin
{
    public partial class AjouterMedecin : System.Web.UI.Page
    {
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Medecin";
        string codemedecin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["pseudo"] != null)
                {
                    tusername.Text = Session["pseudo"].ToString();
                    Username1.Text = Session["pseudo"].ToString();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }
        public void AjouteMedecin()
        {
            string status = "Actif";
            codemedecin = medecin.CodeMedecin(tnomp.Text, tprenomp.Text);
            medecin.CreerMedecin(codemedecin, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, ddspecial.Text, tdateEmbauch.Text, ttypeP, tpseudo.Text, tpass.Text, status, tusername.Text, tdatenow.Text);
        }
        void Vider()
        {
            codemedecin = "";
            tnomp.Text = "";
            tprenomp.Text = "";
            ddsexe.Text = "";
            tdatenaiss.Text = "";
            tadresse.Text = "";
            tphone.Text = "";
            temail.Text = "";
            tmatricule.Text = "";
            tjob.Text = "";
            ddspecial.Text = "";
            tdateEmbauch.Text = "";
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            AjouteMedecin();
            tcode.Text = codemedecin;
        }
    }
}
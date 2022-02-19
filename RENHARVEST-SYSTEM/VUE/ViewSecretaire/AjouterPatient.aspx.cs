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

namespace RENHARVEST_SYSTEM.VUE.ViewSecretaire
{
    public partial class AjouterPatient : System.Web.UI.Page
    {

        private ControlleurPatients patient = new ControlleurPatients();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Patient";
        string codepatient;
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

        public void CreerPatient()
        {
             codepatient = patient.Codepatient(tnomp.Text, tprenomp.Text);
             patient.CreerPatient(codepatient, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, tp_respon.Text, ddlienp.Text, ttypeP, tusername.Text, datecreated);
        }
        void Vider()
        {
            codepatient = "";
            tnomp.Text = "";
            tprenomp.Text = "";
            ddsexe.Text = "";
            tdatenaiss.Text = "";
            tadresse.Text = "";
            tphone.Text = "";
            temail.Text = "";
            tmatricule.Text = "";
            tjob.Text = "";
            ddg_s.Text = "";
            tp_respon.Text = "";
            ddlienp.Text = "";
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            CreerPatient();
            tcodep.Text = codepatient;
            Vider();
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListePatient.aspx");
        }
    }
}
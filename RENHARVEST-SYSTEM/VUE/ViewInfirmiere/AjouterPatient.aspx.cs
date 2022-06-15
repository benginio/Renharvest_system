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

namespace RENHARVEST_SYSTEM.VUE.ViewInfirmiere
{
    public partial class AjouterPatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurUser us = new ControlleurUser();

        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Patient";
        string codepatient;
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                //if (Session["codeUser"] != null)
                //{


                //    my = Session["codeUser"].ToString();
                //    bool find = us.RechercherUser(my);
                //    tusername.Text = us.getPseudo();
                //    Username1.Text = us.getPseudo();
                //}
                //else
                //{
                //    Response.Redirect("../Login.aspx");
                //}
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

        protected void btnlogout_Click(object sender, EventArgs e)
        {

        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            CreerPatient();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "pop();", true);
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "pop()", true);
            Vider();
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Vider();
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListePatient.aspx");
        }
    }
}
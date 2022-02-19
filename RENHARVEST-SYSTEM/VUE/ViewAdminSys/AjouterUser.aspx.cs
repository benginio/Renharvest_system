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

namespace RENHARVEST_SYSTEM.VUE.ViewAdminSys
{
    public partial class AjouterUser : System.Web.UI.Page
    {
        private ControlleurUser us = new ControlleurUser();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
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

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        void Vider()
        {
            tnomp.Text = "";
            tprenomp.Text = "";
            ddsexe.Text = "";
            tdatenaiss.Text = "";
            tadresse.Text = "";
            tphone.Text = "";
            temail.Text = "";
            tmatricule.Text = "";
            tjob.Text = "";
            ddtypeuser.Text = "";
            tdateEmbauch.Text = "";
        }
        void Enregistrer()
        {
           string codeUser = us.CodeUSER(tnomp.Text, tprenomp.Text);
            us.CreerUser(codeUser, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, tpseudo.Text, tpass.Text, ddtypeuser.Text, tdateEmbauch.Text, tusername.Text, tdatenow.Text, ddstatus.Text);

        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            Enregistrer();
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {

        }
    }
}
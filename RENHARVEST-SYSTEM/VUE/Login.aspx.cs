using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE
{
    public partial class Login : System.Web.UI.Page
    {
        private ControlleurUser us = new ControlleurUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        void connecter()
        {
            if((tuser.Text.Equals("admin") || tuser.Text.Equals("Admin") || tuser.Text.Equals("ADMIN")) && tpass.Text.Equals("admin"))
            {
                Session["pseudo"] = tuser.Text;
                    Response.Redirect("ViewAdminSys/Accueil.aspx");
                    Session.RemoveAll();
            }
            
           bool find = us.LoginUser(tuser.Text, tpass.Text);
            string codeUser = us.getCodeUser();
            if (!find)
            {
                // errormsg.Text = "mot de pass ou pass est incorrect!!";
            }
            else
            {
                
                if (us.getTypeP().Equals("Medecin"))
                {
                    Session["pseudo"] = tuser.Text;
                    Session["codeUser"] = codeUser;
                    Response.Redirect("ViewMedecin/Accueil.aspx");
                    Session.RemoveAll();
                }
                else if (us.getTypeP().Equals("Administrateur"))
                {
                    Session["pseudo"] = tuser.Text;
                    Session["codeUser"] = codeUser;
                    Response.Redirect("ViewAdmin/Accueil.aspx");
                    Session.RemoveAll();
                }
                else if (us.getTypeP().Equals("Infirmier(e)"))
                {
                    Session["pseudo"] = tuser.Text;
                    Session["codeUser"] = codeUser;
                    Response.Redirect("ViewInfirmiere/Accueil.aspx");
                    Session.RemoveAll();
                }
                else if (us.getTypeP().Equals("Caissier(e)"))
                {
                    Session["pseudo"] = tuser.Text;
                    Session["codeUser"] = codeUser;
                    Response.Redirect("ViewCaissier/Accueil.aspx");
                    Session.RemoveAll();
                }
                else 
                {
                    Session["pseudo"] = tuser.Text;
                    Session["codeUser"] = codeUser;
                    Response.Redirect("ViewSecretaire/Accueil.aspx");
                    Session.RemoveAll();
                }
                
                    
                
            }

        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            connecter();
        }
    }
}
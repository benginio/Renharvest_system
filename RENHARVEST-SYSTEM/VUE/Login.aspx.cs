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
            
           bool find = us.LoginUser(tuser.Text, tpass.Text);
            if (!find)
            {
              // errormsg.Text = "mot de pass ou pass est incorrect!!";
           }
            else
            {
                Session["pseudo"] = tuser.Text;
                Response.Redirect("ViewAdmin/Accueil.aspx");
                Session.RemoveAll();
           }

        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            connecter();
        }
    }
}
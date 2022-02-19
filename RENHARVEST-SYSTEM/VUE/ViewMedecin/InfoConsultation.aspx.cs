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
    public partial class InfoConsultation : System.Web.UI.Page
    {
        private ControlleurMedecin medecin = new ControlleurMedecin();
        private Login log = new Login();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                //if (Session["codeUser"] != null)
                //{


                //    my = Session["codeUser"].ToString();
                //    bool find = medecin.Recherchemedecin(my);
                //    tusername.Text = "Dr." + Session["pseudo"].ToString();
                //    Username1.Text = "Dr." + Session["pseudo"].ToString();
                //}
                //else
                //{
                //    Response.Redirect("../Login.aspx");
                //}
            }
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
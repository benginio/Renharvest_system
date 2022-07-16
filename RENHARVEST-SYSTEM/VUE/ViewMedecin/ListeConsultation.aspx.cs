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
    public partial class ListeConsultation : System.Web.UI.Page
    {
        private ControlleurConsultation cons = new ControlleurConsultation();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");

                if (Session["codeUser"] != null)
                {

                    listeCons();
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
            Response.Redirect("../Login.aspx");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            
        }
        void listeCons()
        {
            
            magride.DataSource= cons.getListerConsAll(Session["codeUser"].ToString());
            magride.DataBind();
        }
        protected void tbnsearch_Click(object sender, EventArgs e)
        {

        }

       
    }
}
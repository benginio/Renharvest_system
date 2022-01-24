using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewAdmin
{
    public partial class ListeMedecin : System.Web.UI.Page
    {
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                Afficher();

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

        void Afficher()
        {
            magride.DataSource = medecin.GetListerMedecin();
            magride.DataBind();
        }


    }
}
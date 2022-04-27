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
    public partial class ListeRDV : System.Web.UI.Page
    {
        private ControlleurRDV rdv = new ControlleurRDV();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
               
                if (Session["codeUser"] != null)
                {

                    my = Session["codeUser"].ToString();
                    bool find = medecin.Recherchemedecin(my);
                    tusername.Text = "Dr." + medecin.getPrenomP();
                    Username1.Text = "Dr." + medecin.getPrenomP();

                    Afficher();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }
        void Afficher()
        {
            gridlistRDV.DataSource = rdv.GetListerRDV3(Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {

        }
    }
}
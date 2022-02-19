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

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class ListePatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                Afficher();

                if (Session["codeUser"] != null)
                {

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

        void Afficher()
        {
            magride.DataSource = patient.GetListerPatient();
            magride.DataBind();
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
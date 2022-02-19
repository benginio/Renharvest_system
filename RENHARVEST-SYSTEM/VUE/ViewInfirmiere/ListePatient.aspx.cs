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
    public partial class ListePatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurUser us = new ControlleurUser();

        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["codeUser"] != null)
                {
                    Afficher();

                    my = Session["codeUser"].ToString();
                    bool find = us.RechercherUser(my);
                    tusername.Text = us.getPseudo();
                    Username1.Text = us.getPseudo();
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
        void Afficher()
        {
            magride.DataSource = patient.GetListerPatient();
            magride.DataBind();
        }


    }
}
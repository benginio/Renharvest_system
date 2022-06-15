using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewAdminSys
{
    public partial class addservice : System.Web.UI.Page
    {
        private ControlleurMedecin medecin = new ControlleurMedecin();
        private ControlleurService ser = new ControlleurService();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["pseudo"] != null)
                {


                    //my = Session["codeUser"].ToString();
                    //bool find = medecin.Recherchemedecin(my);
                    tusername.Text = Session["pseudo"].ToString();
                    Username1.Text = Session["pseudo"].ToString();

                    ListSer();
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
        public void ListSer()
        {
            magrid.DataSource = ser.GetListerService();
            magrid.DataBind();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Vider();
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeSer = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            ser.DeleteService(codeSer);
            ListSer();
        }
        void Vider()
        {
            tdescript.Text = "";
            tprix.Text = "";
            tcodeS.Text = "";
        }
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeService = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            bool find = ser.RechercherService(codeService);
            tdescript.Text = ser.getDescription();
            tprix.Text = ser.getPrix();
        }

        protected void tdescript_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tdescript.Text))
            {
                string codeservice = ser.CodeServices();
                tcodeS.Text = codeservice;
            }
        }

        protected void btnajouter_Click(object sender, EventArgs e)
        {
            ser.AjouterService(tcodeS.Text, tdescript.Text, tprix.Text, Session["pseudo"].ToString(), datecreated);
            ListSer();
            Vider();
        }

        protected void btnmodif_Click(object sender, EventArgs e)
        {
            ser.ModifierService(tcodeS.Text, tdescript.Text, tprix.Text, Session["pseudo"].ToString(), datecreated);
            ListSer();
            Vider();
        }


    }
}
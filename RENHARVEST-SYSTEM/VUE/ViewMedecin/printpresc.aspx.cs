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
    public partial class printpresc : System.Web.UI.Page
    {
        private ControlleurTraitement traitement = new ControlleurTraitement();
        private ControlleurPrescription pres = new ControlleurPrescription();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        private ControlleurPatients patient = new ControlleurPatients();
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{

            //    tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
            //    if (Session["codeUser"] != null)
            //    {
            //        my = Session["codeUser"].ToString();
            //        bool find = medecin.Recherchemedecin(my);
            //        tusername.Text = "Dr." + Session["pseudo"].ToString();
            //        Username1.Text = "Dr." + Session["pseudo"].ToString();
            //        Infopatient();
            //        InfoMedecin();
            //        Listetraitement();
            //    }
            //    else
            //    {
            //        Response.Redirect("../Login.aspx");
            //    }
            //}
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        void Listetraitement()
        {
            bool find1 = traitement.Recherchetraitement(Session["codePatien"].ToString(), Session["codeUser"].ToString(), Session["datecreated"].ToString());
           tprevention .Text = traitement.getPrevention();
           tdurer.Text = traitement.getDurer();

            GridOrdonance.DataSource = pres.getListerPrescription(Session["codeUser"].ToString(), Session["codePatien"].ToString(), Session["datecreated"].ToString());
            GridOrdonance.DataBind();

        }
        void Infopatient()
        {
            bool find1 = patient.Recherchepatient(Session["codePatien"].ToString());
            tinfopatient.Text = patient.getNomP().ToUpper() + " " + patient.getPrenomP();
            tdate.Text = Session["datecreated"].ToString();
        }
        void InfoMedecin()
        {
            bool find = medecin.Recherchemedecin(Session["codeUser"].ToString());
            tprestataire.Text = medecin.getNomP().ToUpper() + " " + medecin.getPrenomP();
            tspecial.Text = medecin.getSpecial();
        }
        protected void btninfocons_Click(object sender, EventArgs e)
        {
            Response.Redirect("InfoConsultation.aspx");
        }
    }
}
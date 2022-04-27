using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class SignV : System.Web.UI.Page
    {
        private ControlleurPrescription pres = new ControlleurPrescription();
        private ControlleurSigneV sign = new ControlleurSigneV();
        private ControlleurMedicament med = new ControlleurMedicament();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        public string chcon;
        public SqlConnection con;
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        string age = "";
        string numOr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["codeUser"] != null)
                {
                   
                    my = Session["codeUser"].ToString();
                    medecin.Recherchemedecin(my);
                    tusername.Text = "Dr." + Session["pseudo"].ToString();
                    Username1.Text = "Dr." + Session["pseudo"].ToString();

                    bool find1 = patient.Recherchepatient(Session["codePatien"].ToString());
                    lnom.Text = patient.getNomP();
                    lprenom.Text = patient.getPrenomP();
                    age = patient.Age(Session["codePatien"].ToString(), patient.getDateNaiss()) + " Ans";
                    lage.Text = age;
                    Info();
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
            magridSign.DataSource = sign.GetListerSigne(Session["codePatien"].ToString());
            magridSign.DataBind();
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterConsultation.aspx");
        }
        void Info()
        {
            bool find1 = patient.Recherchepatient(Session["codePatien"].ToString());
            lblcode.Text = Session["codePatien"].ToString();
            lblnom.Text = patient.getNomP();
            lblprenom.Text = patient.getPrenomP();
            lblsexe.Text = patient.getSexe();
            lbldatenaiss.Text = patient.getDateNaiss();
            lblmatricule.Text = patient.getMatricule();
            lbljob.Text = patient.getJob();
            lbladresse.Text = patient.getAdresse();
            lblphone.Text = patient.getPhone();
            lblemail.Text = patient.getEmail();
            lbllienR.Text = patient.getLienARespon();
            lblpersR.Text = patient.getP_Respon();
            lbldatecreated.Text = tdatenow.Text;
            lblgps.Text = patient.getG_S();

        }

        protected void btnretour_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignV.aspx");
        }

        protected void btnsavesign_Click(object sender, EventArgs e)
        {
            string code = sign.CodeSigneV();
            sign.AjouterSigneV(code, Session["codePatien"].ToString(),tpoid.Text,ttemp.Text,tta.Text,ttaille.Text,null,tusername.Text,tdatenow.Text);
            //Response.Redirect("SignV.aspx");
        }
    }
}
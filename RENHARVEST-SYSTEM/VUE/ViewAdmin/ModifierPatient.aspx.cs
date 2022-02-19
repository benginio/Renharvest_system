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
    public partial class ModifierPatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
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
            magride.DataSource = patient.GetListerPatient();
            magride.DataBind();
        }
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();

            bool find = patient.Recherchepatient(codepers);
            Label1.Text = codepers;
            tnomp.Text = patient.getNomP();
            tprenomp.Text = patient.getPrenomP();
            ddsexe.Text = patient.getSexe();
            tdatenaiss.Text = patient.getDateNaiss();
            tadresse.Text = patient.getAdresse();
            tphone.Text = patient.getPhone();
            temail.Text = patient.getEmail();
            tmatricule.Text = patient.getMatricule();
            tjob.Text = patient.getJob();
            ddg_s.Text = patient.getG_S();
            tp_respon.Text = patient.getP_Respon();
            ddlienp.Text = patient.getLienARespon();

            Labe1.Text= patient.getNomP();
            Label2.Text= patient.getPrenomP();

        }
        void AfficheP()
        {
            magride.DataSource = patient.GetListerPatientP(tsearch.Text);
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = patient.GetListerPatientN(tsearch.Text);
            magride.DataBind();
        }
        void AfficherM()
        {
            magride.DataSource = patient.GetListerPatientM(tsearch.Text);
            magride.DataBind();
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            string code = Label1.Text;
            string type="";
            string date="";
            patient.ModifierPatient(code, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, tp_respon.Text, ddlienp.Text, type, tusername.Text, date);
        }

        protected void tbnsearch_Click(object sender, EventArgs e)
        {

            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("ModifierPatient.aspx");
            }
            else
            {
                if (DDtrier.Text.Equals("Prenom"))
                {
                    AfficheP();

                }
                else if (DDtrier.Text.Equals("Nom"))
                {
                    AfficherN();
                }
                else
                {
                    AfficherM();
                }
            }

        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifierPatient.aspx");
        }
    }
}
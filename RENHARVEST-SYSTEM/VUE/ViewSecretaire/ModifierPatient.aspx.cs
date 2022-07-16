using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewSecretaire
{
    public partial class ModifierPatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        public string matri = "";
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
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();
            Label1.Text = codepers;
            bool find = patient.Recherchepatient(codepers);
            tnomp.Text = patient.getNomP();
            tprenomp.Text = patient.getPrenomP();
            ddsexe.Text = patient.getSexe();
            tdatenaiss.Text = patient.getDateNaiss();
            DateTime d = Convert.ToDateTime(tdatenaiss.Text);
            tage.Text = Convert.ToString(DateTime.Now.Year - d.Year) + "  Ans";
            tadresse.Text = patient.getAdresse();
            tphone.Text = patient.getPhone();
            temail.Text = patient.getEmail();
            tmatricule.Text = patient.getMatricule();
            matri = patient.getMatricule();
            tjob.Text = patient.getJob();
            ddg_s.Text = patient.getG_S();
            tp_respon.Text = patient.getP_Respon();
            ddlienp.Text = patient.getLienARespon();
            Labe1.Text = patient.getNomP();
            Label2.Text = patient.getPrenomP();
            taddressResp.Text = patient.getAdresseResp();
            tphoneResp.Text = patient.getPhoneResp();
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
        void Vider()
        {
            //  codepatient = "";
            tnomp.Text = "";
            tprenomp.Text = "";
            tdatenaiss.Text = "";
            tadresse.Text = "";
            tphone.Text = "";
            temail.Text = "";
            tmatricule.Text = "";
            tjob.Text = "";
            tp_respon.Text = "";
            ddlienp.Text = "";
            Label1.Text = "";
            taddressResp.Text = "";
            tphoneResp.Text = "";

        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {

            string code = Label1.Text;
            DateTime d = Convert.ToDateTime(tdatenaiss.Text);
            if (d.Date > DateTime.Now.Date)
            {
                tdatenaiss.Text = "";
                string msg = "Swal.fire('Oopss!','La date de naissance est superieure a aujourdhui!','warning')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
            }
            else
            {
                patient.ModifierPatient(code, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, tp_respon.Text, ddlienp.Text, taddressResp.Text, tphoneResp.Text, null, tusername.Text, null);

                Vider();
                string msg = "Swal.fire('Sucess!','Modification reusir!','success')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                Afficher();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "viewprof1()", true);
            }
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifierPatient.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }

        protected void tmatricule_TextChanged(object sender, EventArgs e)
        {
            string mat = patient.verifierMatri(tmatricule.Text);
            if (mat.Equals("0"))
            {

            }
            else if (tmatricule.Text.Equals(matri))
            {

            }
            else
            {
                tmatricule.Text = "";
                string msg = "Swal.fire('Oopss!','Cet Matricule a deja ete utiliser!','warning')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);

            }

        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifierPatient.aspx");
        }
    }
}
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
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class AjouterPatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Patient";
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
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        public void CreerPatient()
        {
                patient.CreerPatient(tcodep.Text, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, tp_respon.Text, ddlienp.Text, taddressResp.Text, tphoneResp.Text, ttypeP, tusername.Text, datecreated);
                
         }
        void Vider()
        {
            tcodep.Text = "";
            tnomp.Text = "";
            tprenomp.Text = "";
            ddsexe.Text = "";
            tdatenaiss.Text = "";
            tadresse.Text = "";
            tphone.Text = "";
            temail.Text = "";
            tmatricule.Text = "";
            tjob.Text = "";
            ddg_s.Text = "";
            tp_respon.Text = "";
            ddlienp.Text = "";
            taddressResp.Text = "";
            tphoneResp.Text = "";
            
            
        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(tdatenaiss.Text);
            if (d.Date > DateTime.Now.Date)
            {

                tdatenaiss.Text = "";
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Oopss!','La date de naissance est superieure a aujourdhui!','warning')", true);

            }
            else
            {

                CreerPatient();
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Enregistrement reusir!','success')", true);
                if (!string.IsNullOrEmpty(temail.Text))
                {
                    email();
                }
                Vider();
            }

        }
        void email()
        {
            //using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], temail.Text))
            //{
            //    mm.Subject = "DOUBLE HARVEST (Double les Recoltes)";
            //    mm.Body = "Bienvenue a lHopital double harvest";
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = ConfigurationManager.AppSettings["Host"];
            //    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
            //    NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"], ConfigurationManager.AppSettings["SMTPpassword"]);
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            //    smtp.Send(mm);
            //    ClientScript.RegisterClientScriptBlock(GetType(), "id1", "Swal.fire('Sucess!','email send!','success')", true);
            //}
        }
        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListePatient.aspx");
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Vider();
        }

        protected void tdatenaiss_TextChanged(object sender, EventArgs e)
        {
            DateTime d = Convert.ToDateTime(tdatenaiss.Text);

            tage.Text =Convert.ToString( DateTime.Now.Year - d.Year)+"  Ans";
        }

        protected void tmatricule_TextChanged(object sender, EventArgs e)
        {
            string mat = patient.verifierMatri(tmatricule.Text);
            if (mat.Equals("0"))
            {

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Oopss!','Cet Matricule a deja ete utiliser!','warning')", true);
                tmatricule.Text = "";
            }


        }

        protected void tprenomp_TextChanged(object sender, EventArgs e)
        {
            tcodep.Text = patient.Codepatient(tnomp.Text, tprenomp.Text);
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
        }
    }
}
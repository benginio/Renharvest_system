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
    public partial class AjouterPatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Patient";
        string codepatient;
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
            DateTime d = Convert.ToDateTime(tdatenaiss.Text);
            if (d.Date > DateTime.Now.Date)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Oopss!','La date de naissance est superieure a aujourd'hui!','warning')", true);
                tdatenaiss.Text = "";

            }
            else { 
                codepatient = patient.Codepatient(tnomp.Text, tprenomp.Text);
                patient.CreerPatient(codepatient, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, tp_respon.Text, ddlienp.Text, ttypeP, tusername.Text, datecreated);
                }
            }
        void Vider()
        {
            codepatient = "";
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
            
        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            CreerPatient();
            ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Enregistrement reusir!','success')", true);
            Vider();

        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListePatient.aspx");
        }

        protected void btnannuler_Click(object sender, EventArgs e)
        {
            Vider();
        }
    }
}
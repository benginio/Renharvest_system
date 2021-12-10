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

namespace RENHARVEST_SYSTEM.VUE
{
    public partial class AjouterPatient : System.Web.UI.Page
    {

        private ControlleurPatients patient = new ControlleurPatients();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string ttypeP = "Patient";
        string codepatient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
            }
        }

        public void CreerPatient()
        {
             codepatient = patient.Codepatient(tnomp.Text, tprenomp.Text);
             patient.CreerPatient(codepatient, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tjob.Text, ddg_s.Text, tp_respon.Text, ddlienp.Text, ttypeP, tusername.Text, datecreated);
        }

        protected void btnvalider_Click(object sender, EventArgs e)
        {
            CreerPatient();
            tcodep.Text = codepatient;
        }
    }
}
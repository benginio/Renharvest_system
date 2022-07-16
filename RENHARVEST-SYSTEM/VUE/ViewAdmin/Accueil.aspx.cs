using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE
{
    public partial class Accueil : System.Web.UI.Page
    {
        private ControlleurUser user = new ControlleurUser();
        private ControlleurConsultation cons = new ControlleurConsultation();
        private Login log = new Login();
        private  ControlleurPatients patient = new ControlleurPatients();

        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                if (Session["pseudo"] != null)
                {
                    tusername.Text = Session["pseudo"].ToString();
                    Username1.Text = Session["pseudo"].ToString();

                    nbrPers.Text = patient.nombrePers();
                    lblNbrinscription.Text = patient.nombrePatientToday();
                    lbluser.Text = user.nombreUtilsateur();
                    lblconsultation.Text = cons.nbrConsTodayall();

                    nbfille.Text = patient.nbrRDVfille();
                    nbgarc.Text = patient.nbrRDVgarc();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        public static List<Genre> GetChartData()
        {
            DataTable dt = new DataTable();
            string constring = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT sexe, COUNT(*) AS Total  FROM tbpersonne GROUP BY sexe", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            List<Genre> dataList = new List<Genre>();
            foreach (DataRow dtrow in dt.Rows)
            {
                Genre details = new Genre();
                details.GenDesc= dtrow[0].ToString();
                details.NbrGen = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }

        public class Genre
        {
            public int NbrGen { get; set; }
            public string GenDesc { get; set; }

        }

        }
}
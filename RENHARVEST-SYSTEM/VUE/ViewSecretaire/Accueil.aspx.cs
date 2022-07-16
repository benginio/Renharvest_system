using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewSecretaire
{
    public partial class Accueil : System.Web.UI.Page
    {
        private static ControlleurMedecin medecin = new ControlleurMedecin();
        private static ControlleurRDV rdv = new ControlleurRDV();
        private static ControlleurPatients patient = new ControlleurPatients();
        private static bool find1;
        private static bool find2;
        private Login log = new Login();
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

                    nbrRDV.Text = rdv.nbrRDVtoDay1();
                    nbrrdvcancel.Text = rdv.nbrRDVtoDay1Cancel();
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
        [WebMethod]
        public static List<CalendarEvents> GetCalendarData()
        {
            //-- this is the webmethod that you will require to create to fetch data from database
            return GetCalendarDataFromDatabase();
        }
        private static List<CalendarEvents> GetCalendarDataFromDatabase()
        {

            List<CalendarEvents> CalendarList = new List<CalendarEvents>();
            string constring = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constring))
            {
                string strQuery = "Select * FROM tbrendez_vous ";

                using (SqlCommand cmd = new SqlCommand(strQuery, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        DataSet ds = new DataSet();
                        // ds = ClsDAL.QueryEngine(strQuery, "SlotMaster");
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        //dt = ds.Tables[0];

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            find1 = patient.Recherchepatient(dt.Rows[i]["codepatient"].ToString());
                            string patien = patient.getNomP() + " " + patient.getPrenomP();
                            find2 = medecin.Recherchemedecin(dt.Rows[i]["codemedecin"].ToString());
                            string medec = medecin.getNomP() + " " + medecin.getPrenomP() + "_" + medecin.getSpecial();
                            string codeStart = dt.Rows[i]["daterdv"] + " " + dt.Rows[i]["heure"];
                            CalendarEvents Calendar = new CalendarEvents();
                            Calendar.slotID = Convert.ToInt32(dt.Rows[i]["id"]);
                            Calendar.slotDate = Convert.ToDateTime(dt.Rows[i]["daterdv"]);
                            Calendar.slotDescription = dt.Rows[i]["motifRDV"].ToString();
                            Calendar.slotPatient = patien;
                            Calendar.slotMedecin = medec;
                            Calendar.slotStartTime = Convert.ToDateTime(codeStart);
                            Calendar.slotEndTime = Convert.ToDateTime(codeStart);


                            //if (Calendar.slotStatus == "ACTIVE")
                            //{
                            Calendar.color = "green";
                            //}
                            //else
                            //{
                            //    Calendar.color = "grey";
                            //}

                            CalendarList.Add(Calendar);
                        }
                    }
                }
            }
            return CalendarList;
        }


        public class CalendarEvents
        {
            public int slotID { get; set; }

            public DateTime slotStartTime { get; set; }

            public DateTime slotEndTime { get; set; }
            public DateTime slotDate { get; set; }
            public string EventDescription { get; set; }

            public string Title { get; set; }
            public string slotDescription { get; set; }
            public string slotStatus { get; set; }

            public int bookingID { get; set; }
            public bool AllDayEvent { get; set; }
            public string color { get; set; }
            public string slotPatient { get; set; }
            public string slotMedecin { get; set; }
        }
    }
}
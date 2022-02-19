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
    public partial class Prescription : System.Web.UI.Page
    {
        private ControlleurPrescription pres = new ControlleurPrescription();
        private ControlleurSigneV sign = new ControlleurSigneV();
        private ControlleurMedicament med = new ControlleurMedicament();
        private ControlleurOrdonnance ord = new ControlleurOrdonnance();
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
                    lblage1.Text = age;
                    Info();
                    Affichelastdate();
                    AfficheDate();
                    AddDefaultFirstRecord();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }
        void AfficheDate()
        {
            magriddate.DataSource = pres.getListerPrescription1(tusername.Text, Session["codePatien"].ToString());
            magriddate.DataBind();
        }
        void Affichelastdate()
        {
           string date= pres.Lastdate(tusername.Text, Session["codePatien"].ToString());
            magridlistp.DataSource = pres.getListerPrescription(tusername.Text, Session["codePatien"].ToString(), date);
            magridlistp.DataBind();

        }

        public void connection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Open();

        }
        private void AddDefaultFirstRecord()
        {

            //creating DataTable  
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tbprescription";
            //creating columns for DataTable  
            dt.Columns.Add(new DataColumn("codeMed", typeof(string)));
            dt.Columns.Add(new DataColumn("nbrFois", typeof(string)));
            dt.Columns.Add(new DataColumn("quant", typeof(string)));
            dt.Columns.Add(new DataColumn("form", typeof(string)));
            dt.Columns.Add(new DataColumn("numOrd", typeof(string)));
            dt.Columns.Add(new DataColumn("codePatient", typeof(string)));
            dt.Columns.Add(new DataColumn("createdby", typeof(string)));
            dt.Columns.Add(new DataColumn("datecreated", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["tbprescription"] = dt;
            magridPres.DataSource = dt;
            magridPres.DataBind();
        }
        private void AddNewRecordRowToGrid()
        {
            if (ViewState["tbprescription"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tbprescription"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    numOr = ord.NumOrdo();
                    bool find = medecin.Recherchemedecin(Session["codeUser"].ToString());
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                        //Creating new row and assigning values  
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["codeMed"] = tnomM.Text;
                        drCurrentRow["nbrFois"] = tnbrfois.Text;
                        drCurrentRow["quant"] = tquant.Text;
                        drCurrentRow["form"] = tform.Text;
                        drCurrentRow["numOrd"] = numOr;
                        drCurrentRow["codePatient"] = Session["codePatien"].ToString();
                        drCurrentRow["createdby"] = Session["pseudo"].ToString();
                        drCurrentRow["datecreated"] = tdatenow.Text;

                    }
                    //Removing initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //Added New Record to the DataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //storing DataTable to ViewState  
                    ViewState["tbprescription"] = dtCurrentTable;
                    //binding Gridview with New Row  
                    magridPres.DataSource = dtCurrentTable;
                    magridPres.DataBind();
                }
            }
        }
        private void BulkInsertToDataBase()
        {
            DataTable dttbprescription = (DataTable)ViewState["tbprescription"];
            connection();
            //creating object of SqlBulkCopy  
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name  
            objbulk.DestinationTableName = "tbprescription";
            //Mapping Table column  

            objbulk.ColumnMappings.Add("codeMed", "codeMed");
            objbulk.ColumnMappings.Add("nbrFois", "nbrFois");
            objbulk.ColumnMappings.Add("quant", "quant");
            objbulk.ColumnMappings.Add("form", "form");
            objbulk.ColumnMappings.Add("numOrd", "numOrd");
            objbulk.ColumnMappings.Add("codePatient", "codepers qq1");
            objbulk.ColumnMappings.Add("createdby", "createdby");
            objbulk.ColumnMappings.Add("datecreated", "datecreated");
            //inserting bulk Records into DataBase   
            objbulk.WriteToServer(dttbprescription);
            numOr = ord.NumOrdo();
            ord.AjourterOrdonnace(numOr, Session["pseudo"].ToString(), tdatenow.Text);
        }
        protected void Addpress_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
            tnomM.Text = "";
            tnbrfois.Text = "";
            tquant.Text = "";
            tform.Text = "";
        }
        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        protected void btnremove_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvrow = (GridViewRow)lb.NamingContainer;
            int rowID = gvrow.RowIndex;
            if (ViewState["tbprescription"] != null)
            {
                DataTable dt = (DataTable)ViewState["tbprescription"];
                if (dt.Rows.Count > 1)
                {
                    if (gvrow.RowIndex < dt.Rows.Count - 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }
                ViewState["tbprescription"] = dt;
                //binding Gridview with New Row  
                magridPres.DataSource = dt;
                magridPres.DataBind();
            }
            
        }


        protected void btnsavePresc_Click(object sender, EventArgs e)
        {
            BulkInsertToDataBase();
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
            lbldateP.Text = tdatenow.Text;
            lblgps.Text = patient.getG_S();
            lblpatien.Text = Session["codePatien"].ToString();

        }

        //protected void magriddate_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    //LinkButton btn = (LinkButton)e.CommandSource;
        //    //string date = Convert.ToString(btn.Attributes["datecreated"]);
        //    if (e.CommandName == "date")
        //    {
        //        string date = Convert.ToString(e.CommandArgument);
        //        magridlistp.DataSource = pres.getListerPrescription(Session["pseudo"].ToString(), Session["codePatien"].ToString(), date);
        //        magridlistp.DataBind();

        //    }
        //}

        protected void listeprescp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prescription.aspx");
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string date = magriddate.DataKeys[row.RowIndex].Values[0].ToString();
            magridlistp.DataSource = pres.getListerPrescription(tusername.Text, Session["codePatien"].ToString(), date);
            magridlistp.DataBind();
        }

        
    }
}
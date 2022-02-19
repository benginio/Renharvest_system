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
    public partial class AjouterConsultation1 : System.Web.UI.Page
    {
        private ControlleurPrescription pres = new ControlleurPrescription();
        private ControlleurSigneV sign = new ControlleurSigneV();
        private ControlleurMedicament med = new ControlleurMedicament();
        private ControlleurOrdonnance ord = new ControlleurOrdonnance();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        private ControlleurConsultation cons = new ControlleurConsultation();
        private ControlleurExamen exam = new ControlleurExamen();
        private ControlleurAntecedent ant = new ControlleurAntecedent();
        public string chcon;
        public SqlConnection con;
        string datecreated = DateTime.Now.ToString("MM/dd/yyyy");
        //string th= DateTime.Now.ToString("MM/dd/yyyy");
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
                    SigneV();
                    Info();
                    my = Session["codeUser"].ToString();
                        medecin.Recherchemedecin(my);
                    tusername.Text = "Dr." + Session["pseudo"].ToString();
                    Username1.Text = "Dr." + Session["pseudo"].ToString();

                    bool find1 = patient.Recherchepatient(Session["codePatien"].ToString());
                    lnom.Text = patient.getNomP();
                    lprenom.Text = patient.getPrenomP();
                    age = patient.Age(Session["codePatien"].ToString(), patient.getDateNaiss())+" Ans";
                     lage.Text = age;
                    lblage.Text = age;
                    lblage1.Text = age;
                    AddDefaultFirstRecord();
                    AddDefaultFirstRecordEx();
                    drop();
                    Maladie();
                    Listantfamille();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }
         
        //void Affiche()
        //{
        //    rptCons.DataSource = cons.getListerConsPM(Session["codePatien"].ToString(), Session["codeUser"].ToString());
        //    rptCons.DataBind();
        //}
       
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

        protected void btnsaveCons_Click(object sender, EventArgs e)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["tbexamen"];

            if (dtCurrentTable.Rows[0][2].ToString() !=null)
            {
                BulkInsertToDataBaseex();     
            }
            my = Session["codeUser"].ToString();
            bool find = medecin.Recherchemedecin(my);
            cons.AjouterConsultation(Session["codePatien"].ToString(), Session["codeUser"].ToString(), lage.Text, thistoire.Text, tsigne.Text, tsymp.Text, ddiag.Text, tcomment.Text, Session["pseudo"].ToString(), tdatenow.Text);
        }

        public void connection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Open();

        }
        void drop()
        {
            connection();
            SqlCommand com = new SqlCommand("select codeMed,(nomM+'_'+dosage) as th from tbmedicament ORDER BY nomM ASC", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            ddnomM.DataTextField = ds.Tables[0].Columns["th"].ToString(); // text field name of table dispalyed in dropdown
                                                                                 // 
            ddnomM.DataValueField = ds.Tables[0].Columns["codeMed"].ToString();
            // to retrive specific  textfield name   
            ddnomM.DataSource = ds.Tables[0];     //assigning datasource to the dropdownlist  
            ddnomM.DataBind();  //binding dropdownlist  
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

                        drCurrentRow["codeMed"] = ddnomM.Text;
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
        void SigneV()
        {
            bool find = sign.RechercheSigneVpatient(Session["codePatien"].ToString());
            tpoid.Text = sign.getPoids();
            ttemp.Text = sign.getTemperature();
            ttaille.Text = sign.getTaille();
            tta.Text = sign.getTensionA();
        }

        
        private void AddDefaultFirstRecordEx()
        {

            //creating DataTable  
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tbexamen";
            //creating columns for DataTable  
            dt.Columns.Add(new DataColumn("codePatient", typeof(string)));
            dt.Columns.Add(new DataColumn("descriptionE", typeof(string)));
            dt.Columns.Add(new DataColumn("resultatE", typeof(string)));
            dt.Columns.Add(new DataColumn("createdby", typeof(string)));
            dt.Columns.Add(new DataColumn("datecreated", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["tbexamen"] = dt;
            gridexamen.DataSource = dt;
            gridexamen.DataBind();
        }
        private void AddNewRecordRowToGridEx()
        {
            if (ViewState["tbexamen"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["tbexamen"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                   
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //Creating new row and assigning values  
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["codePatient"] = Session["codePatien"].ToString();
                        drCurrentRow["descriptionE"] = tdesc.Text;
                        drCurrentRow["resultatE"] =tresultat.Text;
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
                    ViewState["tbexamen"] = dtCurrentTable;
                    //binding Gridview with New Row  
                    gridexamen.DataSource = dtCurrentTable;
                    gridexamen.DataBind();
                }
            }
        }
        private void BulkInsertToDataBaseex()
        {
            DataTable dttbexamen = (DataTable)ViewState["examen"];
            connection();
            //creating object of SqlBulkCopy  
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name  
            objbulk.DestinationTableName = "tbexamen";
            //Mapping Table column  

            objbulk.ColumnMappings.Add("codePatient", "codePatient");
            objbulk.ColumnMappings.Add("descriptionE", "descriptionE");
            objbulk.ColumnMappings.Add("resultatE", "resultatE");
            objbulk.ColumnMappings.Add("createdby", "createdby");
            objbulk.ColumnMappings.Add("datecreated", "datecreated");
            //inserting bulk Records into DataBase   
            objbulk.WriteToServer(dttbexamen);
            
        }

        protected void btnaddEx_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGridEx();
            tdesc.Text = "";
            tresultat.Text = "";
        }

        protected void btnremoveEx_Click(object sender, EventArgs e)
        {

        }
        void Maladie()
        {
            connection();
            SqlCommand com = new SqlCommand("select codeMalad,nomMalad from tbmaladie ORDER BY nomMalad ASC", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            ddiag.DataTextField = ds.Tables[0].Columns["nomMalad"].ToString(); // text field name of table dispalyed in dropdown
                                                                          // 
            ddiag.DataValueField = ds.Tables[0].Columns["codeMalad"].ToString();
            // to retrive specific  textfield name   
            ddiag.DataSource = ds.Tables[0];     //assigning datasource to the dropdownlist  
            ddiag.DataBind();  //binding dropdownlist  
        }
        void Listantfamille()
        {
            Gridantfamille.DataSource = ant.getListeAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Familliaux");
            Gridantfamille.DataBind();
        }
        protected void btnantfamil_Click(object sender, EventArgs e)
        {
            string typeAntecedent = "Familliaux";
            if (tallergie.Text.Equals(""))
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, ddAntmalad.Text, null, Session["pseudo"].ToString(), datecreated);

            }
            else
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(),typeAntecedent,tallergie.Text,null, Session["pseudo"].ToString(), datecreated);
            }
        }

        protected void btnremoveAnt_Click(object sender, EventArgs e)
        {

        }
        void Listantpers()
        {
            Gridantfamille.DataSource = ant.getListeAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Personnels");
            Gridpers.DataBind();
        }
        protected void ddAntmalad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddAntmalad.Text.Equals("Allergies"))
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "", "Allerg();", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "Allerg()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "Allerg();", true);
                
            }
        }

        protected void btnantpers_Click(object sender, EventArgs e)
        {
            string typeAntecedent = "Personnels";
            if (!string.IsNullOrEmpty(tallergie1.Text))
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, tallergie1.Text, null, Session["pseudo"].ToString(), datecreated);

            }
            else if (!string.IsNullOrEmpty(tist.Text))
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, tist.Text, null, Session["pseudo"].ToString(), datecreated);
            }
            else
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, ddantpers.Text, null, Session["pseudo"].ToString(), datecreated);

            }
        }

        protected void btnremoveAntpers_Click(object sender, EventArgs e)
        {

        }

        protected void ddantpers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddantpers.Text.Equals("Allergies"))
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "", "Allerg();", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "Allerg1()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "Allerg();", true); 
            }
            if (ddantpers.Text.Equals("IST"))
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "", "Allerg();", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "Ist()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "Allerg();", true);
            }
        }
    }
}
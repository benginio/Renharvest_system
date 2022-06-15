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
    public partial class suividossier1 : System.Web.UI.Page
    {
        private ControlleurPrescription pres = new ControlleurPrescription();
        private ControlleurSigneV sign = new ControlleurSigneV();
        private ControlleurMedicament med = new ControlleurMedicament();
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        private ControlleurConsultation cons = new ControlleurConsultation();
        private ControlleurExamen exam = new ControlleurExamen();
        private ControlleurAntecedent ant = new ControlleurAntecedent();
        private ControlleurTraitement traitement = new ControlleurTraitement();
        public string chcon;
        public SqlConnection con;

        public string datecreate = DateTime.Now.ToString("MM/dd/yyyy");
        string my = "";
        string age = "";
        string numT;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                Session["heure"] = DateTime.Now.ToString("hh:mm:ss");
                Session["dateC"] = DateTime.Now.ToString("MM/dd/yyyy");
                if (Session["codeUser"] != null)
                {

                    //SigneV();
                    Info();
                    my = Session["codeUser"].ToString();
                    medecin.Recherchemedecin(my);
                    tusername.Text = "Dr." + Session["pseudo"].ToString();
                    Username1.Text = "Dr." + Session["pseudo"].ToString();

                    bool find1 = patient.Recherchepatient(Session["codePatien"].ToString());
                    lnom.Text = patient.getNomP();
                    lprenom.Text = patient.getPrenomP();
                    age = patient.Age(Session["codePatien"].ToString(), patient.getDateNaiss()) + " Ans";
                    lage.Text = age;
                    lblage.Text = age;
                    lblage1.Text = age;
                    AddDefaultFirstRecord();
                    AddDefaultFirstRecordEx();
                    drop();
                    Maladie();
                    Listantfamille();
                    Listantpers();
                    //ListOperation();
                    //ListSV();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
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
            lbldatecreated.Text = datecreate;
            lbldateP.Text = datecreate;
            lblgps.Text = patient.getG_S();
            lblpatien.Text = Session["codePatien"].ToString();

        }
        public void connection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Open();

        }
        public void deconnection()
        {
            //Stoting connection string   
            chcon = ConfigurationManager.ConnectionStrings["DBCONNECT"].ConnectionString;
            con = new SqlConnection(chcon);
            con.Close();

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
            Response.Redirect("suividossier.aspx");
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
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, ddAntmalad.Text, null, Session["pseudo"].ToString(), datecreate);
                Listantfamille();
            }
            else
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, tallergie.Text, null, Session["pseudo"].ToString(), datecreate);
                Listantfamille();
                tallergie.Text = "";
            }
        }
        void Listantpers()
        {

            Gridpers.DataSource = ant.getListeAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Personnels");
            Gridpers.DataBind();
        }
        protected void btnantpers_Click(object sender, EventArgs e)
        {
            string typeAntecedent = "Personnels";
            if (!string.IsNullOrEmpty(tallergie1.Text))
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, tallergie1.Text, null, Session["pseudo"].ToString(), datecreate);
                Listantpers();
                tallergie1.Text = "";
                tist.Text = "";
            }
            else if (!string.IsNullOrEmpty(tist.Text))
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, tist.Text, null, Session["pseudo"].ToString(), datecreate);
                Listantpers();
                tallergie1.Text = "";
                tist.Text = "";
            }
            else
            {
                ant.AjouterAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), typeAntecedent, ddantpers.Text, null, Session["pseudo"].ToString(), datecreate);
                Listantpers();
            }
        }

        protected void btnantoperation_Click(object sender, EventArgs e)
        {

        }
        void ListHabitudes()
        {
            Gridhabitude.DataSource = ant.getListeAntecedent(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Habitudes");
            Gridhabitude.DataBind();
        }
        protected void btnhabitude_Click(object sender, EventArgs e)
        {

        }

        protected void btnannulerSV_Click(object sender, EventArgs e)
        {

        }
        private void AddDefaultFirstRecordEx()
        {

            //creating DataTable  
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "tbexamen";
            //creating columns for DataTable  
            dt.Columns.Add(new DataColumn("codePatient", typeof(string)));
            dt.Columns.Add(new DataColumn("codeMedecin", typeof(string)));
            dt.Columns.Add(new DataColumn("descriptionE", typeof(string)));
            dt.Columns.Add(new DataColumn("resultatE", typeof(string)));
            dt.Columns.Add(new DataColumn("typeEx", typeof(string)));

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
                        drCurrentRow["codeMedecin"] = Session["codeUser"].ToString();
                        drCurrentRow["descriptionE"] = tdesc.Text;
                        drCurrentRow["resultatE"] = tresultat.Text;
                        drCurrentRow["typeEx"] = "Examen";
                        drCurrentRow["createdby"] = Session["pseudo"].ToString();
                        drCurrentRow["datecreated"] = Session["dateC"];

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
            DataTable dttbexamen = (DataTable)ViewState["tbexamen"];
            connection();
            //creating object of SqlBulkCopy  
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name  
            objbulk.DestinationTableName = "tbexamen";
            //Mapping Table column  

            objbulk.ColumnMappings.Add("codePatient", "codePatient");
            objbulk.ColumnMappings.Add("codeMedecin", "codeMedecin");
            objbulk.ColumnMappings.Add("descriptionE", "descriptionE");
            objbulk.ColumnMappings.Add("resultatE", "resultatE");
            objbulk.ColumnMappings.Add("typeEx", "typeEx");
            objbulk.ColumnMappings.Add("createdby", "createdby");
            objbulk.ColumnMappings.Add("datecreated", "datecreated");
            //inserting bulk Records into DataBase   
            objbulk.WriteToServer(dttbexamen);
            deconnection();

        }
        protected void btnaddEx_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGridEx();
            tdesc.Text = "";
            tresultat.Text = "";
        }

        protected void btnremove_Click(object sender, EventArgs e)
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

            dt.Columns.Add(new DataColumn("numT", typeof(string)));
            dt.Columns.Add(new DataColumn("codeMed", typeof(string)));
            dt.Columns.Add(new DataColumn("nbrFois", typeof(string)));
            dt.Columns.Add(new DataColumn("quant", typeof(string)));
            dt.Columns.Add(new DataColumn("form", typeof(string)));
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
                    // numOr = ord.NumOrdo();
                    numT = traitement.CodeTraitement();
                    Session["numT"] = numT;

                    //bool find = medecin.Recherchemedecin(Session["codeUser"].ToString());
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //Creating new row and assigning values  
                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["numT"] = numT;
                        drCurrentRow["codeMed"] = ddnomM.Text;
                        drCurrentRow["nbrFois"] = tnbrfois.Text;
                        drCurrentRow["quant"] = tquant.Text;
                        drCurrentRow["form"] = tform.Text;
                        drCurrentRow["createdby"] = Session["pseudo"].ToString();
                        drCurrentRow["datecreated"] = Session["dateC"].ToString();



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

            objbulk.ColumnMappings.Add("numT", "numT");
            objbulk.ColumnMappings.Add("codeMed", "codeMed");
            objbulk.ColumnMappings.Add("nbrFois", "nbrFois");
            objbulk.ColumnMappings.Add("quant", "quant");
            objbulk.ColumnMappings.Add("form", "form");
            objbulk.ColumnMappings.Add("createdby", "createdby");
            objbulk.ColumnMappings.Add("datecreated", "datecreated");
            //inserting bulk Records into DataBase   
            objbulk.WriteToServer(dttbprescription);
            deconnection();

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

        }

        protected void btnanuler_Click(object sender, EventArgs e)
        {

        }
    }
}
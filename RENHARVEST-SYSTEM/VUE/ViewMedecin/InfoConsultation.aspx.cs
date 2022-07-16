using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class InfoConsultation : System.Web.UI.Page
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
        private Login log = new Login();
        string datecreated = DateTime.Now.ToString("MM/dd/yyyy");
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
                    tusername.Text = "Dr." + Session["pseudo"].ToString();
                    Username1.Text = "Dr." + Session["pseudo"].ToString();
                    string age = patient.Age(Session["codePatien"].ToString(), patient.getDateNaiss()) + " Ans";
                    tage.Text = age;
                    InfoPatient();
                    InfoMedecin();
                    Listantecedent();
                    Listeexament();
                    Listeconsultation();
                    Listetraitement();
                    ListSV();
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
        void InfoPatient()
        {
            bool find1 = patient.Recherchepatient(Session["codePatien"].ToString());
            tnomP.Text = patient.getNomP();
            tprenomP.Text = patient.getPrenomP();
            tsexe.Text = patient.getSexe();
            tdatenaiss.Text = patient.getDateNaiss();
            tmatricule.Text = patient.getMatricule();
            tjob.Text = patient.getJob();
            tadresse.Text = patient.getAdresse();
            tphone.Text = patient.getPhone();
            temail.Text = patient.getEmail();
            tlienrespon.Text = patient.getLienARespon();
            tprespon.Text = patient.getP_Respon();
            tdatecreation.Text = Session["datecreated"].ToString();
            tgs.Text = patient.getG_S();
            lbltelrespon.Text = patient.getPhoneResp();

        }
        void InfoMedecin()
        {
            bool find = medecin.Recherchemedecin(Session["codeUser"].ToString());
            lblnomcomplet.Text = medecin.getNomP().ToUpper() + " " + medecin.getPrenomP();
            lblspecial.Text = medecin.getSpecial();
        }
        void Listantecedent()
        {
            Gridantfamille.DataSource = ant.getListeAntecedentinfo(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Familliaux", Session["datecreated"].ToString());
            Gridantfamille.DataBind();
            Gridantpers.DataSource = ant.getListeAntecedentinfo(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Personnels", Session["datecreated"].ToString());
            Gridantpers.DataBind();
            Gridhabitude.DataSource = ant.getListeAntecedentinfo(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Habitudes", Session["datecreated"].ToString());
            Gridhabitude.DataBind();
            Gridoperation.DataSource = ant.getListeAntecedentinfo(Session["codePatien"].ToString(), Session["codeUser"].ToString(), "Chirurgicaux", Session["datecreated"].ToString());
            Gridoperation.DataBind();

        }
        void Listeexament()
        {
            gridexamen.DataSource = exam.GetListeexamen(Session["codePatien"].ToString(), Session["codeUser"].ToString(), Session["datecreated"].ToString());
            gridexamen.DataBind();
        }
        void Listeconsultation()
        {
            //Gridconsultation.DataSource = cons.getListerConsPM(Session["codePatien"].ToString(), Session["codeUser"].ToString(), Session["datecreated"].ToString());
            //Gridconsultation.DataBind();
            bool find = cons.RechercheConsultationD(Session["codePatien"].ToString(), Session["codeUser"].ToString(), Session["datecreated"].ToString());
            
            lblagep.Text = cons.getAge();
            lblsigne.Text = cons.getSigne();
            lblmotif.Text = cons.getMotif();
            lblsymp.Text = cons.getSymptomes();
            lblhistoire.Text = cons.getHistoire();
            lbldiag.Text = cons.getDetail();
            lblcomment.Text = cons.getComment();
            lblheure.Text = cons.getHeurecreated();
            lblheuree.Text= cons.getHeurecreated();
            lbldcreated.Text = Session["datecreated"].ToString();
            
        }
        void Listetraitement()
        {
            bool find1 = traitement.Recherchetraitement(Session["codePatien"].ToString(), Session["codeUser"].ToString(), Session["datecreated"].ToString());
            lblprevention.Text = traitement.getPrevention();
            lbldurer.Text = traitement.getDurer();

            GridOrdonance.DataSource = pres.getListerPrescription(Session["codeUser"].ToString(), Session["codePatien"].ToString(), Session["datecreated"].ToString());
            GridOrdonance.DataBind();

        }
        void ListSV()
        {
            bool find = sign.RechercheSigneVpatient(Session["codePatien"].ToString(), Session["datecreated"].ToString());
            lblpoid.Text = sign.getPoids();
            lbltemp.Text = sign.getTemperature();
            lbltaille.Text = sign.getTaille();
            lblta.Text = sign.getTensionA();
            lblpouls.Text = sign.getPouls();

            bool find1 = cons.RechercheConsultationD(Session["codePatien"].ToString(), Session["codeUser"].ToString(), Session["datecreated"].ToString());
            lblage1.Text = cons.getAge();
        }

        protected void btnExportpdf_Click(object sender, EventArgs e)
        {
        
                Response.ContentType = "application/pdf";
                string FileName = "DHPatient" + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename="+FileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                fieldPdf.RenderControl(htmlTextWriter);
                StringReader stringReader = new StringReader(stringWriter.ToString());
                Document Doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(Doc);
                PdfWriter.GetInstance(Doc, Response.OutputStream);
                Doc.Open();
                htmlparser.Parse(stringReader);
                Doc.Close();
                Response.Write(Doc);
                Response.End();
                
            

    }
        public override void VerifyRenderingInServerForm(Control control) { }


    }
}
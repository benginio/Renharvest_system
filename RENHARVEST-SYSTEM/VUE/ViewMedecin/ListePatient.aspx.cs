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
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text;

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class ListePatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                Afficher();

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

        void Afficher()
        {
            magride.DataSource = patient.GetListerPatient();
            magride.DataBind();
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjouterPatient.aspx");
        }

        protected void ddsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddsearch.Text.Equals("Age"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "Searchage()", true);
            }else if (ddsearch.Text.Equals("Sexe"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "Searchsexe()", true);
            }
            else
            {
               ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "id", "Search()", true);
            }
        }

        protected void DDsexe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDsexe1.Text.Equals("Masculin"))
            {
                magride.DataSource = patient.GetListerPatientS("Masculin");
                magride.DataBind();
            }
            else if (DDsexe1.Text.Equals("Feminin"))
            {
                magride.DataSource = patient.GetListerPatientS("Feminin");
                magride.DataBind();
            }
            else
            {
                magride.DataSource = patient.GetListerPatient();
                magride.DataBind();
            }
        }

        protected void btnsearchage_Click(object sender, EventArgs e)
        {
            if(tagebebut.Text.Equals("") && tagefin.Text.Equals(""))
            {

            }
            else
            {
                magride.DataSource = patient.GetListerPatientage(tagebebut.Text,tagefin.Text);
                magride.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (ddsearch.Text.Equals("Prenom"))
            {
                if (DDsexe.Text.Equals("Masculin"))
                {
                    magride.DataSource = patient.GetListerPatientPS(tsearchNP.Text, "Masculin");
                    magride.DataBind();
                }
                else if (DDsexe.Text.Equals("Feminin"))
                {
                    magride.DataSource = patient.GetListerPatientPS(tsearchNP.Text, "Feminin");
                    magride.DataBind();
                }
                else
                {
                    magride.DataSource = patient.GetListerPatientP(tsearchNP.Text);
                    magride.DataBind();
                }
            }
            else if (ddsearch.Text.Equals("Nom"))
            {
                if (DDsexe.Text.Equals("Masculin"))
                {
                    magride.DataSource = patient.GetListerPatientNS(tsearchNP.Text, "Masculin");
                    magride.DataBind();
                }
                else if (DDsexe.Text.Equals("Feminin"))
                {
                    magride.DataSource = patient.GetListerPatientNS(tsearchNP.Text, "Feminin");
                    magride.DataBind();
                }
                else
                {
                    magride.DataSource = patient.GetListerPatientN(tsearchNP.Text);
                    magride.DataBind();
                }
            }
            else
            {
                magride.DataSource = patient.GetListerPatient();
                magride.DataBind();
            }
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            export.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(Doc);
            PdfWriter.GetInstance(Doc, Response.OutputStream);
            Doc.Open();
            htmlparser.Parse(stringReader);
            Doc.Close();
            Response.Write(Doc);
            Response.End();
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=DHlist.xlsx");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            magride.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control) { }
    }
}
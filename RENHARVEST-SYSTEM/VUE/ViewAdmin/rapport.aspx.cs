using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewAdmin
{
    public partial class rapport : System.Web.UI.Page
    {
        private ControlleurConsultation cons = new ControlleurConsultation();
        protected void Page_Load(object sender, EventArgs e)
        {
            magride.DataSource = cons.getcompConsult(DateTime.Now.ToString("MM/dd/yyyy"));
            magride.DataBind();
            lblmineur.Text = cons.nbrConsMineur(DateTime.Now.ToString("MM/dd/yyyy"));
            lbladult.Text = cons.nbrConsMageure(DateTime.Now.ToString("MM/dd/yyyy"));
            lbltotal.Text = cons.nbrConstot(DateTime.Now.ToString("MM/dd/yyyy"));
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            string FileName = "DHrapportMois" + DateTime.Now.ToString("MM/dd/yyyy") + ".pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
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
            export.DataBind();
        }
    }
}
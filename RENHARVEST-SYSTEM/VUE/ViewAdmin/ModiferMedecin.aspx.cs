using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;


namespace RENHARVEST_SYSTEM.VUE.ViewAdmin
{
    public partial class ModiferMedecin : System.Web.UI.Page
    {
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                Afficher();
                if (Session["pseudo"] != null)
                {
                    tusername.Text = Session["pseudo"].ToString();
                    Username1.Text = Session["pseudo"].ToString();
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }

            }
        }
        void Afficher()
        {
            magride.DataSource = medecin.GetListerMedecin();
            magride.DataBind();
        }
        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();

            bool find = medecin.Recherchemedecin(codepers);
            Label1.Text = codepers;
            tnomp.Text = medecin.getNomP();
            tprenomp.Text = medecin.getPrenomP();
            ddsexe.Text = medecin.getSexe();
            tdatenaiss.Text = medecin.getDateNaiss();
            tadresse.Text = medecin.getAdresse();
            tphone.Text = medecin.getPhone();
            temail.Text = medecin.getEmail();
            tmatricule.Text = medecin.getMatricule();
            tjob.Text = medecin.getJob();
            ddg_s.Text = medecin.getG_S();
            ddspecial.Text = medecin.getSpecial();
            tdateEmbauch.Text = medecin.getDateEmbauch();
            Labe1.Text = medecin.getNomP();
            Label2.Text = medecin.getPrenomP();

        }
        void AfficheP()
        {
            magride.DataSource = medecin.GetListerMedecinP(tsearch.Text);
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = medecin.GetListerMedecinN(tsearch.Text);
            magride.DataBind();
        }
        void AfficherM()
        {
            magride.DataSource = medecin.GetListerMedecinM(tsearch.Text);
            magride.DataBind();
        }
        protected void btnvalider_Click(object sender, EventArgs e)
        {
            string code = Label1.Text;
            medecin.ModifierMedecin(code, tnomp.Text, tprenomp.Text, ddsexe.Text, tdatenaiss.Text, tadresse.Text, tphone.Text, temail.Text, tmatricule.Text, tjob.Text, ddg_s.Text, ddspecial.Text, tdateEmbauch.Text, null, null, null, null, tusername.Text, tdatenow.Text);
        }

        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (DDtrier.Text.Equals("Prenom"))
            {
                AfficheP();

            }
            else if (DDtrier.Text.Equals("Nom"))
            {
                AfficherN();
            }
            else
            {
                AfficherM();
            }
        }

        protected void btnliste_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModiferMedecin.aspx");
        }

        protected void magride_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
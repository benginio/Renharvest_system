using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RENHARVEST_SYSTEM.CONTROLLEUR;
using RENHARVEST_SYSTEM.MODELE;
using RENHARVEST_SYSTEM.VUE;

namespace RENHARVEST_SYSTEM.VUE.ViewMedecin
{
    public partial class DossierPatient : System.Web.UI.Page
    {
        private ControlleurPatients patient = new ControlleurPatients();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        private ControlleurConsultation cons = new ControlleurConsultation();
        private ControlleurExamen exam = new ControlleurExamen();
        private ControlleurAntecedent ant = new ControlleurAntecedent();
        private ControlleurTraitement traitement = new ControlleurTraitement();
        private ControlleurPrescription pres = new ControlleurPrescription();
        private ControlleurSigneV sign = new ControlleurSigneV();
        private ControlleurMedicament med = new ControlleurMedicament();
        private ControlleurRDV rdv = new ControlleurRDV();
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");

                if (Session["codeUser"] != null)
                {
                    Afficher();
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
        void AfficheP()
        {
            magride.DataSource = patient.GetListerPatientP(tsearch.Text);
            magride.DataBind();
        }
        void AfficherN()
        {
            magride.DataSource = patient.GetListerPatientN(tsearch.Text);
            magride.DataBind();
        }
        void AfficherM()
        {
            magride.DataSource = patient.GetListerPatientM(tsearch.Text);
            magride.DataBind();
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
            Response.Redirect("DossierPatient.aspx");
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();
            Session["codPatien"] = codepers;
            Session["codePatien"] = codepers;//pour recuper le code dans infoPatient
            string age = patient.Age(Session["codPatien"].ToString(), patient.getDateNaiss()) + " Ans";
            tage.Text = age;
            InfoPatient();
            InfoMedecin();
            Listantecedent();
            ListSV();
            Listeexament();
            Listconsultation();
            ListeRDV();
            Listetraitement();
            Listeprescriptiont();
        }
        void InfoPatient()
        {
            bool find1 = patient.Recherchepatient(Session["codPatien"].ToString());
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
            tdatecreation.Text = patient.getDatecreated();
            tgs.Text = patient.getG_S();


        }
        void InfoMedecin()
        {
            bool find = medecin.Recherchemedecin(Session["codeUser"].ToString());
            lblnomcomplet.Text = medecin.getNomP().ToUpper() + " " + medecin.getPrenomP();
            lblspecial.Text = medecin.getSpecial();
        }
        void Listantecedent()
        {
            Gridantfamille.DataSource = ant.getListeAntecedent(Session["codPatien"].ToString(), Session["codeUser"].ToString(), "Familliaux");
            Gridantfamille.DataBind();
            Gridantpers.DataSource = ant.getListeAntecedent(Session["codPatien"].ToString(), Session["codeUser"].ToString(), "Personnels");
            Gridantpers.DataBind();
            Gridhabitude.DataSource = ant.getListeAntecedent(Session["codPatien"].ToString(), Session["codeUser"].ToString(), "Habitudes");
            Gridhabitude.DataBind();
            Gridoperation.DataSource = ant.getListeAntecedent(Session["codPatien"].ToString(), Session["codeUser"].ToString(), "Chirurgicaux");
            Gridoperation.DataBind();

        }
        void ListSV()
        {
            GridSV.DataSource = sign.GetListerSigne(Session["codPatien"].ToString());
            GridSV.DataBind();
        }
        void Listeexament()
        {
            gridexamen.DataSource = exam.GetListeexamenPM(Session["codPatien"].ToString(), Session["codeUser"].ToString());
            gridexamen.DataBind();
        }
        void Listconsultation()
        {
            Gridconsultation.DataSource = cons.getListerConsPaMe(Session["codPatien"].ToString(),Session["codeUser"].ToString());
            Gridconsultation.DataBind();
        }
        void Listetraitement()
        {

            Gridtraitement.DataSource = traitement.GetListeTraitementAll(Session["codePatien"].ToString(), Session["codeUser"].ToString());
            Gridtraitement.DataBind();

        }
        void Listeprescriptiont()
        {

            gridprescription.DataSource =pres.getListerPrescriptionAll(Session["codeUser"].ToString(), Session["codePatien"].ToString());
            gridprescription.DataBind();

        }
        void ListeRDV()
        {
            gridlistRDV.DataSource = rdv.GetListerRDV1(Session["codPatien"].ToString(), Session["codeUser"].ToString());
            gridlistRDV.DataBind();
        }
        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("ModifierPatient.aspx");
            }
            else
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
        }

        protected void btnSV_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string datecreated = GridSV.DataKeys[row.RowIndex].Values[0].ToString();
            Session["datecreated"] = datecreated;
            Response.Redirect("InfoConsultation.aspx");
        }

        protected void btnEx_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string datecreated = gridexamen.DataKeys[row.RowIndex].Values[0].ToString();
            Session["datecreated"] = datecreated;
            Response.Redirect("InfoConsultation.aspx");
        }

        protected void btnconsultation_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string datecreated = Gridconsultation.DataKeys[row.RowIndex].Values[0].ToString();
            Session["datecreated"] = datecreated;
            Response.Redirect("InfoConsultation.aspx");
        }

        protected void btntraitement_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string datecreated = Gridtraitement.DataKeys[row.RowIndex].Values[0].ToString();
            Session["datecreated"] = datecreated;
            Response.Redirect("InfoConsultation.aspx");
        }

        protected void btnordo_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string datecreated = gridprescription.DataKeys[row.RowIndex].Values[0].ToString();
            Session["datecreated"] = datecreated;
            Response.Redirect("printpresc.aspx");
        }
    }
}
﻿using System;
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
    public partial class AjouterConsultation : System.Web.UI.Page
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

        protected void btnliste_Click(object sender, EventArgs e)
        {

        }

        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
                Response.Redirect("AjouterConsultation.aspx");
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

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codepers = magride.DataKeys[row.RowIndex].Values[0].ToString();

            bool find = patient.Recherchepatient(codepers);
            Session["codePatien"] = codepers;
            Response.Redirect("AjouterConsultation1.aspx");
            Session.RemoveAll();
        }
    }
}
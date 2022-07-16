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
    public partial class ajouterMotifCons : System.Web.UI.Page
    {
        private ControlleurMotifCons motifC = new ControlleurMotifCons();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
        string my = "";
        public string numMotifCons = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                if (Session["codeUser"] != null)
                {
                    tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                    ListMotifCons();
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

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
        }
        public void ListMotifCons()
        {
            magrid.DataSource = motifC.GetListerMotifCons();
            magrid.DataBind();
        }
        public void ListMotifConsD()
        {
            magrid.DataSource = motifC.GetListerMotifConsD(tsearch.Text);
            magrid.DataBind();
        }
        protected void tnomM_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnumMotif.Text))
            {

            }
            else
            {
                if (!string.IsNullOrEmpty(tnomM.Text))
                {
                    numMotifCons = motifC.numMotifCons(tnomM.Text);
                    tnumMotif.Text = numMotifCons;
                }
            }
        }
        void Vider()
        {
            tnomM.Text = "";
            tnumMotif.Text = "";
        }
        protected void btnajouter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnumMotif.Text))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "Swal.fire('Oopss!','vous ne pouvez pas ajouter!','warning')", true);

            }
            else
            {
                motifC.AjouterMotifCons(tnumMotif.Text, tnomM.Text, tusername.Text, datecreated);
                ListMotifCons();
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Enregistrement reusir!','success')", true);
                Vider();
            }
        }

        protected void btnmodif_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnumMotif.Text))
            {
                motifC.ModifierMotifCons(tnumMotif.Text, tnomM.Text, null, null);
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Modification effectuer avec success!','success')", true);
                ListMotifCons();
                Vider();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "Swal.fire('Oopss!','veillez Selectionner ce que vous voulez modifier!','warning')", true);

            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Vider();
        }

        protected void btnbul_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMed = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            bool find = motifC.RechercherMotifCons(codeMed);
            tnumMotif.Text = codeMed;
            tnomM.Text = motifC.getDescription();
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMed = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            motifC.DeleteMotifCons(codeMed);
            ListMotifCons();
            Vider();
        }

        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals(""))
            {
            }
            else
            {
                ListMotifConsD();
            }
        }
    }
}
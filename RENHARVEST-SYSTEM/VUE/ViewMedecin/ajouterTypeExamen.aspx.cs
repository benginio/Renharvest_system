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
    public partial class ajouterTypeExamen : System.Web.UI.Page
    {
        private ControlleurTypeExamen typeEx = new ControlleurTypeExamen();
        private ControlleurMedecin medecin = new ControlleurMedecin();
        string datecreated = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
        string my = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                if (Session["codeUser"] != null)
                {
                    tdatenow.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");
                    ListTypeEx();
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
        public void ListTypeEx()
        {
            magrid.DataSource = typeEx.GetListerTypeEx();
            magrid.DataBind();
        }
        public void ListTypeExD()
        {
            magrid.DataSource = typeEx.GetListerTypeExD(tsearch.Text);
            magrid.DataBind();
        }
        protected void tnomM_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnumTypeEx.Text))
            {

            }
            else
            {
                if (!string.IsNullOrEmpty(tnomM.Text))
                {
                    string numTypeEx = typeEx.numExs(tnomM.Text);
                    tnumTypeEx.Text = numTypeEx;
                }
            }
        }
        void Vider()
        {
            tnomM.Text = "";
            tnumTypeEx.Text = "";
        }
        protected void btnajouter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnumTypeEx.Text))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "Swal.fire('Oopss!','vous ne pouvez pas ajouter!','warning')", true);

            }
            else
            {
                typeEx.AjouterTypeEx(tnumTypeEx.Text, tnomM.Text, tusername.Text, datecreated);
                ListTypeEx();
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Enregistrement reusir!','success')", true);
                Vider();
            }
        }

       
        protected void btnmodifi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tnumTypeEx.Text))
            {
                typeEx.ModifierTypeEx(tnumTypeEx.Text, tnomM.Text, null, null);
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Sucess!','Modification effectuer avec success!','success')", true);
                ListTypeEx();
                Vider();

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "id", "Swal.fire('Oopss!','veillez Selectionner ce que vous voulez modifier!','warning')", true);
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
            bool find = typeEx.RechercherTypeEx(codeMed);
            tnomM.Text = typeEx.getDescription();
            tnumTypeEx.Text = codeMed;
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string codeMed = magrid.DataKeys[row.RowIndex].Values[0].ToString();
            typeEx.DeleteTypeEx(codeMed);
            ListTypeEx();
            Vider();
        }

        protected void tbnsearch_Click(object sender, EventArgs e)
        {
            if (tsearch.Text.Equals("")) { 
            }
            else { 
                ListTypeExD();
            }
            
        }

        
    }
}
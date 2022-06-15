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
    public partial class rapport : System.Web.UI.Page
    {
        private ControlleurConsultation cons = new ControlleurConsultation();
        protected void Page_Load(object sender, EventArgs e)
        {
            magride.DataSource = cons.getcompConsult();
            magride.DataBind();
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {

        }
    }
}
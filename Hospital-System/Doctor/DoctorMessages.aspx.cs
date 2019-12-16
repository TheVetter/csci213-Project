using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System.Doctor
{
    public partial class DoctorMessages : System.Web.UI.Page
    {
        hsEntities dbcon = new hsEntities();
        private int DocPK = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon.MessagesTables.Load();
            if (Session.Count < 1)
            {
                Response.Redirect("~/Logon.aspx");
            }

            string p = "DocPK";
        }
    }
}
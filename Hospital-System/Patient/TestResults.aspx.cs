using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System.Patient
{
    public partial class TestResults : System.Web.UI.Page
    {

        hsEntities dbcon = new hsEntities();
        private int patPK = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count < 1)
            {
                Response.Redirect("~/Logon.aspx");
            }

            string p = "patPK";
            foreach (string s in Session)
            {
                if (s.Equals(p))
                {
                    patPK = Convert.ToInt32(Session[s].ToString());
                }
            }

            dbcon.TestsTables.Load();
            var testList = from x in dbcon.TestsTables.Local
                          where x.PatientID == patPK
                          select x;

            GridView1.DataSource = testList;
            GridView1.DataBind();

        }
    }
}
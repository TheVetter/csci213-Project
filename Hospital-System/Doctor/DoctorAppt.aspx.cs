using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System.Doctor
{
    public partial class DoctorAppt : System.Web.UI.Page
    {
        hsEntities dbcon = new hsEntities();
        private int DocPK = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon.AppointmentsTables.Load();
            if (Session.Count < 1)
            {
                Response.Redirect("~/Logon.aspx");
            }

            string p = "DocPK";

            foreach (string s in Session)
            {
                if (s.Equals(p))
                {
                    DocPK = Convert.ToInt32(Session[s].ToString());
                }
            }

            var appList = (from x in dbcon.AppointmentsTables.Local
                           where x.DoctorID == DocPK && (DateTime.Compare(x.Date, DateTime.Now) >= 0)
                           select x).ToList();

            GridView1.DataSource = appList;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(GridView1.SelectedIndex >= 0)
            {
                dbcon.AppointmentsTables.Load(); // load up the database

                // find the appointment based on the Appointment ID
                AppointmentsTable app = dbcon.AppointmentsTables.Find(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text)); // delete the item

                dbcon.AppointmentsTables.Remove(app); //remove the appointment
                dbcon.SaveChanges();// save the changes 
                GridView1.DataBind();  // update the gridview
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System.Patient
{
    public partial class PatientAppt : System.Web.UI.Page
    {
        hsEntities dbcon = new hsEntities();
        private int patPK = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dbcon.AppointmentsTables.Load();
            if(Session.Count < 1)
            {
                Response.Redirect("~/Logon.aspx");
            }

            string p = "patPK";
            //int patPK = 0 ;
            foreach (string s in Session)
            {
                if (s.Equals(p))
                {
                    patPK = Convert.ToInt32( Session[s].ToString());
                }
            }
            
            var appList = (from x in dbcon.AppointmentsTables.Local
                          where x.PatientID == patPK && (DateTime.Compare(x.Date, DateTime.Now)>= 0) 
                          select x).ToList();

            GridView1.DataSource = appList;
            GridView1.DataBind();

            update_Doctor_dropdown();
        }

        private void update_Doctor_dropdown()
        {
            dbcon.DoctorsTables.Load();

            var items = from x in dbcon.DoctorsTables.Local
                        where x.Department.Trim().StartsWith(DropDownList_Department.SelectedValue.Trim())
                        select new
                        {
                            Name = "Dr. " + x.FirstName.ToString() + " " + x.LastName.ToString(),
                            x.DoctorID
                        };

            DropDownList_doctor.DataTextField = "Name";
            DropDownList_doctor.DataValueField = "DoctorID";
            DropDownList_doctor.DataSource = items;
            DropDownList_doctor.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            AppointmentsTable app = new AppointmentsTable();

            app.DoctorID = Convert.ToInt32(DropDownList_doctor.SelectedValue);

            if (Calendar1.SelectedDate !=null)
                app.Date = Calendar1.SelectedDate;

            app.Time = TimeSpan.Parse(TextBox_time.Text, System.Globalization.CultureInfo.CurrentCulture);
            app.PatientID = patPK;
            app.Purpose = TextBox_purpose.Text.Trim();

            dbcon.AppointmentsTables.Add(app);
            dbcon.SaveChanges();
            GridView1.DataBind();
        }


        protected void DropDownList_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_Doctor_dropdown();
        }

        protected void OnRowDeleting(object sender, EventArgs e)
        {
            dbcon.AppointmentsTables.Load();
            AppointmentsTable delApp = (AppointmentsTable) GridView1.SelectedValue;

            dbcon.AppointmentsTables.Remove(delApp);
            GridView1.DeleteRow(GridView1.SelectedIndex);
            dbcon.SaveChanges();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
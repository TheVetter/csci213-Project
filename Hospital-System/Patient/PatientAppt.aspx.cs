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
            foreach (string s in Session)
            {
                if (s.Equals(p))
                {
                    patPK = Convert.ToInt32( Session[s].ToString());
                }
            }
            
            var appList = from x in dbcon.AppointmentsTables.Local
                          where x.PatientID == patPK && (DateTime.Compare(x.Date, DateTime.Now)>= 0) 
                          select x;

            GridView1.DataSource = appList;
            GridView1.DataBind();

            update_doctors_list();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if((DateTime.Compare(Calendar1.SelectedDate, DateTime.Now) < 0))
            {
                Label2.Text = "Error: please select date today or After " + Calendar1.SelectedDate.ToString();
            }

            if (TextBox_time.Text.Length == 0)
            {
                Label2.Text = "Error: please enter a time for the appointment";
            }

            if (TextBox_time.Text.Length > 0 &&
               DateTime.Compare(Calendar1.SelectedDate, DateTime.Now) >= 0)
            {
                dbcon.AppointmentsTables.Load();
                AppointmentsTable app = new AppointmentsTable();

                app.DoctorID = Convert.ToInt32(DropDownList_doctor.SelectedValue);
                app.Date = Calendar1.SelectedDate;
                app.Time = TimeSpan.Parse(TextBox_time.Text, System.Globalization.CultureInfo.CurrentCulture);
                app.PatientID = patPK;
                app.Purpose = TextBox_purpose.Text.Trim();


                int confilcts_pat = (from x in dbcon.AppointmentsTables.Local
                                    where x.PatientID == patPK && (DateTime.Compare(app.Date, x.Date) == 0)
                                    && TimeSpan.Compare(app.Time, x.Time) ==0
                                    select x).ToList().Count;

                int confilcts_Doc = (from x in dbcon.AppointmentsTables.Local
                                     where x.DoctorID == app.DoctorID && (DateTime.Compare(app.Date, x.Date) == 0)
                                     && TimeSpan.Compare(app.Time, x.Time) == 0
                                     select x).ToList().Count;

                if (confilcts_Doc > 0)
                {
                    Label2.Text = "Error: Doctor has conflict";
                }
                else if (confilcts_pat > 0)
                {
                    Label2.Text = "Error: Can't schedule 2 appointments at the same time";
                }
                else
                {
                    dbcon.AppointmentsTables.Add(app);
                    dbcon.SaveChanges();
                    GridView1.DataBind();
                    Label2.Text = "Appointment created!";
                }
            }
        }

        protected void Button_delete_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0)
            {
                dbcon.AppointmentsTables.Load(); // load up the database

                // find the appointment based on the Appointment ID
                AppointmentsTable app = dbcon.AppointmentsTables.Find(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text)); // delete the item

                dbcon.AppointmentsTables.Remove(app); //remove the appointment
                dbcon.SaveChanges();// save the changes 
                GridView1.DataBind();  // update the gridview
            }

        }

        protected void DropDownListDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_doctors_list();
        }

        protected void update_doctors_list()
        {
            dbcon.DoctorsTables.Load();

            var items = from x in dbcon.DoctorsTables.Local
                        where x.Department.Trim().StartsWith(DropDownListDepartment.SelectedValue.Trim())
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System.Patient
{
    public partial class PatientMessages : System.Web.UI.Page
    {
        hsEntities dbcon = new hsEntities();
        private int patPK = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session.Count < 1)
            {
                Response.Redirect("~/Logon.aspx");
            }

            //dropdownlist
            string p = "patPK";

            foreach (string s in Session)
            {
                if (s.Equals(p))
                {
                    patPK = Convert.ToInt32(Session[s].ToString());
                }
            }

            dbcon.MessagesTables.Load();
            dbcon.DoctorsTables.Load();
            dbcon.PatientsTables.Load();
            
            var items = from x in dbcon.DoctorsTables.Local
                        select new
                        {
                            Name = x.FirstName.ToString() + " " + x.LastName.ToString(),
                            x.DoctorID
                        };

            DropDownListDocs.DataTextField = "Name";
            DropDownListDocs.DataValueField = "DoctorID";
            DropDownListDocs.DataSource = items;
            DropDownListDocs.DataBind();

            //get pat username
            var patName = (from x in dbcon.PatientsTables.Local
                           where x.PatientID == patPK
                           select x).First().UserLoginName;

            //fill in inbox
            var inbox = from x in dbcon.MessagesTables.Local
                        where x.MessageTO == patName
                        select x;

            GridViewInbox.DataSource = inbox;
            GridViewInbox.DataBind();

            //fill in Sent Messages
            var sent = from x in dbcon.MessagesTables.Local
                       where x.MessageFROM == patName
                       select x;

            GridViewSent.DataSource = sent;
            GridViewSent.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dbcon.MessagesTables.Load();
            dbcon.DoctorsTables.Load();
            dbcon.PatientsTables.Load();

            MessagesTable mess = new MessagesTable();

            mess.MessageTO = (from x in dbcon.DoctorsTables.Local
                              where x.DoctorID == Convert.ToInt32(DropDownListDocs.SelectedValue)
                              select x).First().UserLoginName;
            mess.MessageFROM = (from x in dbcon.PatientsTables.Local
                                where x.PatientID == patPK
                                select x).First().UserLoginName;
            mess.Date = DateTime.Now;
            mess.Message = TextBox1.Text;

            if (!TextBox1.Text.Equals(""))
            {
                dbcon.MessagesTables.Add(mess);
                dbcon.SaveChanges();
                GridViewInbox.DataBind();

                TextBox1.Text = "";

                GridViewSent.DataBind();
            }
        }

 
        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (GridViewSent.SelectedIndex >= 0)
            {
                dbcon.MessagesTables.Load(); // load up the database

                // find the appointment based on the Appointment ID
                MessagesTable mess2 = dbcon.MessagesTables.Find(Convert.ToInt32(GridViewSent.SelectedRow.Cells[1].Text)); // delete the item

                dbcon.MessagesTables.Remove(mess2); //remove the appointment
                dbcon.SaveChanges();// save the changes 
                GridViewSent.DataBind();  // update the gridview
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (GridViewInbox.SelectedIndex >= 0)
            {
                dbcon.MessagesTables.Load(); // load up the database

                // find the appointment based on the Appointment ID
                MessagesTable mess1 = dbcon.MessagesTables.Find(Convert.ToInt32(GridViewInbox.SelectedRow.Cells[1].Text)); // delete the item

                dbcon.MessagesTables.Remove(mess1); //remove the appointment
                dbcon.SaveChanges();// save the changes 
                GridViewInbox.DataBind();  // update the gridview
            }
        }
    }
}
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
            dbcon.DoctorsTables.Load();

            if (Session.Count < 1)
            {
                Response.Redirect("~/Logon.aspx");
            }

            //dropdownlist
            string p = "DocPK";

            foreach (string s in Session)
            {
                if (s.Equals(p))
                {
                    DocPK = Convert.ToInt32(Session[s].ToString());
                }
            }

            dbcon.PatientsTables.Load();

            var items = from x in dbcon.PatientsTables.Local
                        where x.DoctorID == DocPK
                        select new
                        {
                            Name = x.FirstName.ToString() + " " + x.LastName.ToString(),
                            x.PatientID
                        };

            DropDownListPatients.DataTextField = "Name";
            DropDownListPatients.DataValueField = "PatientID";
            DropDownListPatients.DataSource = items;
            DropDownListPatients.DataBind();

            //get doc username
            var docName = (from x in dbcon.DoctorsTables.Local
                          where x.DoctorID == DocPK
                          select x).First().UserLoginName;

            //fill in inbox
            var inbox = from x in dbcon.MessagesTables.Local
                        where x.MessageTO == docName
                        select x;

            GridViewInbox.DataSource = inbox;
            GridViewInbox.DataBind();

            //fill in Sent Messages
            var sent = from x in dbcon.MessagesTables.Local
                        where x.MessageFROM == docName
                        select x;

            GridViewSent.DataSource = sent;
            GridViewSent.DataBind();

        }

        //send a message
        protected void Button1_Click(object sender, EventArgs e)
        {
            dbcon.MessagesTables.Load();
            dbcon.DoctorsTables.Load();
            dbcon.PatientsTables.Load();

            MessagesTable mess = new MessagesTable();

            mess.MessageTO = (from x in dbcon.PatientsTables.Local
                              where x.PatientID == Convert.ToInt32(DropDownListPatients.SelectedValue)
                              select x).First().UserLoginName;
            mess.MessageFROM = (from x in dbcon.DoctorsTables.Local
                                where x.DoctorID == DocPK
                                select x).First().UserLoginName;
            mess.Date = DateTime.Now;
            mess.Message = TextBox1.Text;

            dbcon.MessagesTables.Add(mess);
            dbcon.SaveChanges();
            GridViewInbox.DataBind();

            TextBox1.Text = "";

            GridViewSent.DataBind();
        }

        //delete for inbox
        protected void Button2_Click(object sender, EventArgs e)
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

        //delete for sent messages
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridViewSent.SelectedIndex >= 0)
            {
                dbcon.MessagesTables.Load(); // load up the database

                // find the appointment based on the MessageID
                MessagesTable mess2 = dbcon.MessagesTables.Find(Convert.ToInt32(GridViewSent.SelectedRow.Cells[1].Text)); // delete the item

                dbcon.MessagesTables.Remove(mess2); //remove the message
                dbcon.SaveChanges();// save the changes 
                GridViewSent.DataBind();  // update the gridview
            }
        }
    }
}
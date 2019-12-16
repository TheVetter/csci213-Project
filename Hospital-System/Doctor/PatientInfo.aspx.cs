using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System.Doctor
{
    public partial class PatientInfo : System.Web.UI.Page
    {
        hsEntities dbcon = new hsEntities();
        private int DocPK = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon.PatientsTables.Load();

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

            var patList = from x in dbcon.PatientsTables.Local
                          where x.DoctorID == DocPK
                          select new
                          {
                              x.PatientID,
                              Name = x.FirstName.ToString() + " " + x.LastName.ToString()
                          };

            GridView1.DataSource = patList;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0)
            {
                dbcon.PatientsTables.Load(); // load up the database
                dbcon.TestsTables.Load();
                dbcon.MedicationListTables.Load();

                // find the patient based on the PatientID
                PatientsTable patient = dbcon.PatientsTables.Find(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));

                //Fill in Name label
                Name.Text = patient.FirstName + " " + patient.LastName;

                //Fill in Email label
                Email.Text = patient.Email;

                //Fill in Tests label
                if(patient.TestID != null)
                {
                    var tests = (from x in dbcon.TestsTables.Local
                                 where x.TestID == patient.TestID
                                 select x).First();

                    Tests.Text = "TestID: " + tests.TestID.ToString() + " Test Results: " + tests.TestResults.ToString() + " Test Date: " + tests.TestDate.ToString();

                } else
                {
                    Tests.Text = "No tests";
                }


                //Fill in Medications label
                if (patient.TestID != null)
                {
                    var meds = (from x in dbcon.MedicationListTables.Local
                                where x.PatientID == patient.PatientID
                                select x).First();

                    Medications.Text = "Medication ID: " + meds.MedicationID.ToString() + " Description: " + meds.Description.ToString();
                } else
                {
                    Medications.Text = "No medications";
                }
            }
        }
        
        //Search for patient by PatientID or Last and First Name
        protected void Search_Button_Click(object sender, EventArgs e)
        {
            //TextBox1.Text
        }
    }
}
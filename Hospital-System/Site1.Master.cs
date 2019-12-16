using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Hospital_System
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        hsEntities dbcon = new hsEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session.Count >= 1)
            {
                string d = "DocPK";
                string p = "patPK";
                int patPK = -1;
                int docPK = -1;
                foreach (string s in Session)
                {
                    if (s.Equals(p))
                    {
                        patPK = Convert.ToInt32(Session[s].ToString());
                        break;
                    }
                    else if (s.Equals(d))
                    {
                        docPK = Convert.ToInt32(Session[s].ToString());
                        break;
                    }
                }

                // create patient name 
                if(patPK > 0)
                {
                    dbcon.PatientsTables.Load();
                    dbcon.DoctorsTables.Load();
                    PatientsTable patient = (from pat in dbcon.PatientsTables.Local
                                             where pat.PatientID == patPK
                                             select pat).First();
                    DoctorsTable doctor = (from doc in dbcon.DoctorsTables.Local
                                           where doc.DoctorID == patient.DoctorID
                                           select doc).First();
                    Label1.Text = "Hello, " + patient.FirstName + " " + patient.LastName + "      Your Doctor: Dr. "+
                                    doctor.FirstName + " " + doctor.LastName;
                }
                else if (docPK >0)
                {
                    dbcon.DoctorsTables.Load();

                    DoctorsTable doctor = (from doc in dbcon.DoctorsTables.Local
                                           where doc.DoctorID == docPK
                                           select doc).First();
                    Label1.Text = "Hello, Dr. " + doctor.FirstName + " " + doctor.LastName;
                }

            }else
            {
                Label1.Text = "Please Login ->";
            }

        }
    }
}
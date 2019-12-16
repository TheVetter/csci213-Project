using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;


namespace Hospital_System
{
    public partial class Logon : System.Web.UI.Page
    {

        private hsEntities dbcon = new hsEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            dbcon.UsersTables.Load();

            string username = Login1.UserName.Trim();
            string pass = Login1.Password.Trim();

            UsersTable user = null;
            try
            {
                user = (from x in dbcon.UsersTables.Local
                                   where x.UserLoginName.Trim().StartsWith(username) && x.UserLoginPass.StartsWith(pass)
                                   select x).First();
            }catch (InvalidOperationException)
            {
                FormsAuthentication.RedirectToLoginPage(); // this is kinda dirty and not helpful but whatever
            }


            if (user !=null && user.UserLoginType.Trim().Equals("Patient"))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);

                dbcon.PatientsTables.Load();
                int patpk = Convert.ToInt32((from x in dbcon.PatientsTables.Local
                                            where x.UserLoginName.Equals(user.UserLoginName)
                                            select x.PatientID).First());
                Session.Add("patPK", patpk);
                Response.Redirect("~/Patient/patientHome.aspx");
            }
            else if (user != null && user.UserLoginType.Trim().Equals("Doctor"))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);

                dbcon.DoctorsTables.Load();
                int docpk = Convert.ToInt32(from x in dbcon.DoctorsTables.Local
                            where x.UserLoginName.Equals(user.UserLoginName)
                            select x.DoctorID);
                Session.Add("DocPK", docpk);
                Response.Redirect("~/Doctor/DoctorHome.aspx");
            }

        }
    }
}
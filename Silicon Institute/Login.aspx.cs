using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Entity;
using BusinessLogic;

namespace Silicon_Institute
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            User user = UserLogic.ValidateUser(TextBoxUserName.Text.Trim(), TextBoxPassword.Text.Trim());
            if(user==null)
            {

            }
            else
            {
                Session["User"] = user;
                Response.Redirect("Employees.aspx");
            }
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            
        }

        protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
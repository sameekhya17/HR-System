using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace Silicon_Institute
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToLongDateString();
            if(Session["User"]!=null)
            {
                SiteMenu.Visible = true;
                User user = (User)Session["User"];
                UserLabel.Text = "Welcome "+ user.FirstName + " " + user.LastName;
            }
        }
    }
}

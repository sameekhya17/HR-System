using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BusinessLogic;

namespace Silicon_Institute
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ArrayList typeList = MasterLogic.GetActiveEmployeeType();
                typeList.Insert(0, new EmployeeType(-1, "--All--"));
                DropDownTypes.DataSource = typeList;
                DropDownTypes.DataTextField = "Description";
                DropDownTypes.DataValueField = "Id";
                DropDownTypes.DataBind();

                ArrayList categoryList = MasterLogic.GetActiveEmployeeCategory();
                categoryList.Insert(0, new EmployeeCategory(-1, "--All--"));
                DropDownCategories.DataSource = categoryList;
                DropDownCategories.DataTextField = "Description";
                DropDownCategories.DataValueField = "Id";
                DropDownCategories.DataBind();
            }
        }

        protected void Buttonsearch_Click(object sender, EventArgs e)
        {
            ArrayList employees;
            if(CheckDeleted.Checked)
            {
                employees = EmployeeLogic.SearchEmployees(Convert.ToInt32(DropDownTypes.SelectedValue), Convert.ToInt32(DropDownCategories.SelectedValue),
                TextBoxName.Text);
            }
            else
            {
                employees = EmployeeLogic.SearchActiveEmployees(Convert.ToInt32(DropDownTypes.SelectedValue), Convert.ToInt32(DropDownCategories.SelectedValue),
                TextBoxName.Text);
            }
            GridViewEmployees.DataSource = employees;
            GridViewEmployees.DataBind();
        }

        protected void ButtonNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeDetails.aspx?Id=-1");
        }

        protected void GridViewEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridViewEmployees.DataKeys[e.NewEditIndex]["Id"].ToString();
            Response.Redirect("EmployeeDetails.aspx?Id="+ id);
        }
    }
}
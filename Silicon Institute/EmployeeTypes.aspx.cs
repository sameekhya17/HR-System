using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using Entity;

namespace Silicon_Institute
{
    public partial class EmployeeTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeTypes();
                BindEmployeeCategories();
                BindDocumentTypes();
                ButtonEmployeeCategories.CssClass = "Initial";
                ButtonEmployeeTypes.CssClass = "Clicked";
                ButtonDocumentType.CssClass = "Initial";
                MainView.ActiveViewIndex = 0;
                GridViewEmployeeTypes.ShowFooter = true;
            }
        }
        private void BindEmployeeTypes()
        {
            ArrayList list = MasterLogic.GetAllEmployeeType();
            GridViewEmployeeTypes.DataSource = list;
            GridViewEmployeeTypes.DataBind();
        }
        private void BindEmployeeCategories()
        {
            ArrayList list = MasterLogic.GetActiveEmployeeCategory();
            GridViewCategories.DataSource = list;
            GridViewCategories.DataBind();
        }
        private void BindDocumentTypes()
        {
            ArrayList listCategories = MasterLogic.GetActiveDocumentType();
            GridViewDocumentTypes.DataSource = listCategories;
            GridViewDocumentTypes.DataBind();
        }
        protected void ButtonEmployeeCategories_Click(object sender, EventArgs e)
        {
            ButtonEmployeeCategories.CssClass = "Clicked";
            ButtonEmployeeTypes.CssClass = "Initial";
            ButtonDocumentType.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;
        }

        protected void ButtonEmployeeTypes_Click(object sender, EventArgs e)
        {
            ButtonEmployeeCategories.CssClass = "Initial";
            ButtonEmployeeTypes.CssClass = "Clicked";
            ButtonDocumentType.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void ButtonDocumentType_Click(object sender, EventArgs e)
        {
            ButtonEmployeeCategories.CssClass = "Initial";
            ButtonEmployeeTypes.CssClass = "Initial";
            ButtonDocumentType.CssClass = "Clicked";
            MainView.ActiveViewIndex = 2;
        }

        protected void GridViewEmployeeTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Alter")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                GridViewEmployeeTypes.EditIndex = row.RowIndex;
                GridViewEmployeeTypes.ShowFooter = false;
                BindEmployeeTypes();
            }
            else if (e.CommandName == "CancelEdit")
            {
                GridViewEmployeeTypes.EditIndex = -1;
                GridViewEmployeeTypes.ShowFooter = true;
                BindEmployeeTypes();
            }
            else if (e.CommandName == "Save")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                int id = Convert.ToInt32(GridViewEmployeeTypes.DataKeys[row.RowIndex]["Id"].ToString());
                string description = ((TextBox)row.FindControl("TextDescription")).Text;
                bool isActive = ((CheckBox)row.FindControl("CheckIsActive")).Checked;
                EmployeeType employeeType = new EmployeeType();
                employeeType.Id = id;
                employeeType.Description = description;
                employeeType.IsActive = isActive;
                MasterLogic.SaveEmployeeType(employeeType, (User)Session["User"]);
                GridViewEmployeeTypes.EditIndex = -1;
                GridViewEmployeeTypes.ShowFooter = true;
                BindEmployeeTypes();
            }
            else if (e.CommandName == "Insert")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                string description = ((TextBox)row.FindControl("TextDescriptionInsert")).Text;
                EmployeeType employeeType = new EmployeeType();
                employeeType.Description = description;
                MasterLogic.SaveEmployeeType(employeeType, (User)Session["User"]);
                GridViewEmployeeTypes.EditIndex = -1;
                GridViewEmployeeTypes.ShowFooter = true;
                BindEmployeeTypes();
            }
        }
        protected void GridViewCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Alter")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                GridViewCategories.EditIndex = row.RowIndex;
                GridViewCategories.ShowFooter = false;
                BindEmployeeCategories();
            }
            else if (e.CommandName == "CancelEdit")
            {
                GridViewCategories.EditIndex = -1;
                GridViewCategories.ShowFooter = true;
                BindEmployeeCategories();
            }
            else if (e.CommandName == "Save")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                int id = Convert.ToInt32(GridViewCategories.DataKeys[row.RowIndex]["Id"].ToString());
                string description = ((TextBox)row.FindControl("TextDescription")).Text;
                bool isActive = ((CheckBox)row.FindControl("CheckIsActive")).Checked;
                EmployeeCategory employeeCategory = new EmployeeCategory();
                employeeCategory.Id = id;
                employeeCategory.Description = description;
                employeeCategory.IsActive = isActive;
                MasterLogic.SaveEmployeeCategory(employeeCategory,(User)Session["User"]);
                GridViewCategories.EditIndex = -1;
                GridViewCategories.ShowFooter = true;
                BindEmployeeCategories();
            }
            else if (e.CommandName == "Insert")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                string description = ((TextBox)row.FindControl("TextDescriptionInsert")).Text;
                EmployeeCategory employeeCategory = new EmployeeCategory();
                employeeCategory.Description = description;
                MasterLogic.SaveEmployeeCategory(employeeCategory, (User)Session["User"]);
                GridViewCategories.EditIndex = -1;
                GridViewCategories.ShowFooter = true;
                BindEmployeeCategories();
            }
        }
        protected void GridViewDocumentTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Alter")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                GridViewDocumentTypes.EditIndex = row.RowIndex;
                GridViewDocumentTypes.ShowFooter = false;
                BindDocumentTypes();
            }
            else if (e.CommandName == "CancelEdit")
            {
                GridViewDocumentTypes.EditIndex = -1;
                GridViewDocumentTypes.ShowFooter = true;
                BindDocumentTypes();
            }
            else if (e.CommandName == "Save")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                int id = Convert.ToInt32(GridViewDocumentTypes.DataKeys[row.RowIndex]["Id"].ToString());
                string description = ((TextBox)row.FindControl("TextDescription")).Text;
                bool isActive = ((CheckBox)row.FindControl("CheckIsActive")).Checked;
                DocumentType DocumentType = new DocumentType();
                DocumentType.Id = id;
                DocumentType.Description = description;
                DocumentType.IsActive = isActive;
                MasterLogic.SaveDocumentType(DocumentType, (User)Session["User"]);
                GridViewDocumentTypes.EditIndex = -1;
                GridViewDocumentTypes.ShowFooter = true;
                BindDocumentTypes();
            }
            else if (e.CommandName == "Insert")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                string description = ((TextBox)row.FindControl("TextDescriptionInsert")).Text;
                DocumentType DocumentType = new DocumentType();
                DocumentType.Description = description;
                MasterLogic.SaveDocumentType(DocumentType, (User)Session["User"]);
                GridViewDocumentTypes.EditIndex = -1;
                GridViewDocumentTypes.ShowFooter = true;
                BindDocumentTypes();
            }
        }
    }
}


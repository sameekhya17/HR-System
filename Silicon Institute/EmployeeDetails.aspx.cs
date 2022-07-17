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
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"].ToString();
                Employee employee = id == "-1" ? new Employee() : EmployeeLogic.GetEmployeeById(Convert.ToInt32(id));
                LabelId.Text = id;
                Session["SelectedEmployee"] = employee;

                PageHelper.BindListToDropDown(MasterLogic.GetActiveEmployeeType(), DropDownTypes, "Description", "Id");
                PageHelper.BindListToDropDown(MasterLogic.GetActiveEmployeeCategory(), DropDownListCategories, "Description", "Id");
                TextBoxFirstName.Text = employee.FirstName;
                TextBoxMiddleName.Text = employee.MiddleName;
                TextBoxLastName.Text = employee.LastName;
                if (employee.Id > 0)
                {
                    ListItem itemType = DropDownTypes.Items.FindByValue(employee.EmployeeType.Id.ToString());
                    itemType.Selected = true;

                    ListItem itemCategory = DropDownListCategories.Items.FindByValue(employee.Category.Id.ToString());
                    itemCategory.Selected = true;
                    TextBoxDOB.Text = employee.DateOfBirth.ToString("dd/MM/yyyy");
                    TextBoxDOJ.Text = employee.DateOfJoining.ToString("dd/MM/yyyy");
                }
                else
                {
                    employee.Category = new EmployeeCategory(Convert.ToInt32(DropDownListCategories.SelectedValue), DropDownListCategories.Text);
                    employee.EmployeeType = new EmployeeType(Convert.ToInt32(DropDownTypes.SelectedValue), DropDownTypes.Text);
                }
                GridViewDocuments.DataSource = employee.EmployeeDocuments;
                GridViewDocuments.DataBind();
                PageHelper.BindListToDropDown(MasterLogic.GetActiveDocumentType(), DropDownListDocumentTypes, "Description", "Id");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employees.aspx");
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            if(employee.Id < 0)
            {
                EmployeeLogic.InsertEmployees(employee, (User)Session["User"]);
            }
            else if(employee.IsDirty)
            {
                EmployeeLogic.UpdateEmployees(employee, (User)Session["User"]);
            }
            Response.Redirect("Employees.aspx");
        }
        
        protected void TextBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            employee.FirstName = TextBoxFirstName.Text;
        }

        protected void DropDownTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            employee.EmployeeType = new EmployeeType(Convert.ToInt32(DropDownTypes.SelectedValue), DropDownTypes.Text);
        }

        protected void CalendarButton_Click(object sender, ImageClickEventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            if(employee.Id > 0)
            {
                DOBCalendar.SelectedDate = employee.DateOfBirth;
                DOBCalendar.VisibleDate = employee.DateOfBirth;
            }
            else
            {
                DOBCalendar.SelectedDate = DateTime.Today.AddYears(-18);
                DOBCalendar.VisibleDate = DateTime.Today.AddYears(-18);
            }
            DOBCalendar.Visible = true;
        }
       
        protected void DOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            TextBoxDOB.Text = DOBCalendar.SelectedDate.ToString("dd/MM/yyyy");
            employee.DateOfBirth = DOBCalendar.SelectedDate;
            DOBCalendar.Visible = false;
        }

        protected void CalendarDOJ_SelectionChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            TextBoxDOJ.Text = CalendarDOJ.SelectedDate.ToString("dd/MM/yyyy");
            employee.DateOfJoining = CalendarDOJ.SelectedDate;
            CalendarDOJ.Visible = false;
        }

        protected void CalendarButtonDOJ_Click(object sender, ImageClickEventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            if(employee.Id > 0)
            {
                CalendarDOJ.SelectedDate = employee.DateOfJoining;
                CalendarDOJ.VisibleDate = employee.DateOfJoining;
            }
            else
            {
                CalendarDOJ.SelectedDate = DateTime.Today;
                CalendarDOJ.VisibleDate = DateTime.Today;
            }
            CalendarDOJ.Visible = true;
        }

        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            employee.Category = new EmployeeCategory(Convert.ToInt32(DropDownListCategories.SelectedValue), DropDownListCategories.Text);
        }

        protected void TextBoxMiddleName_TextChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            employee.MiddleName = TextBoxMiddleName.Text;
        }

        protected void TextBoxLastName_TextChanged(object sender, EventArgs e)
        {
            Employee employee = (Employee)Session["SelectedEmployee"];
            employee.LastName = TextBoxLastName.Text;
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadDocument.PostedFile.ContentLength > 0 && FileUploadDocument.FileName.Trim() != string.Empty)
            {
                Employee employee = (Employee)Session["SelectedEmployee"];
                employee.EmployeeDocuments.Add(new EmployeeDocument(-1, FileUploadDocument.PostedFile.FileName, new DocumentType(Convert.ToInt32(DropDownListDocumentTypes.SelectedValue), DropDownListDocumentTypes.SelectedItem.Text), FileUploadDocument.PostedFile, true));
                GridViewDocuments.DataSource = employee.EmployeeDocuments;
                GridViewDocuments.DataBind();
            }
        }

        protected void GridViewDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                int id = Convert.ToInt32(GridViewDocuments.DataKeys[row.RowIndex]["Id"].ToString());
                Employee employee = (Employee)Session["SelectedEmployee"];
                EmployeeDocument document = null;
                foreach(EmployeeDocument employeeDocument in employee.EmployeeDocuments)
                {
                    if(employeeDocument.Id==id)
                    {
                        document = employeeDocument;
                        break;
                    }
                }
                string fullFileName = HttpContext.Current.Server.MapPath(".") + @"\bin\EmployeeDocuments\" + employee.Id.ToString() + @"\" +
                document.DocumentType.Id + @"\" + document.Id + @"\" + document.FileName;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fullFileName);
                Response.TransmitFile(fullFileName);
                Response.End();
            }
            else if(e.CommandName == "DeleteFile")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).DataItemContainer;
                int id = Convert.ToInt32(GridViewDocuments.DataKeys[row.RowIndex]["Id"].ToString());
                Employee employee = (Employee)Session["SelectedEmployee"];
                EmployeeDocument document = null;
                foreach (EmployeeDocument employeeDocument in employee.EmployeeDocuments)
                {
                    if (employeeDocument.Id == id)
                    {
                        document = employeeDocument;
                        break;
                    }
                }
                document.IsActive = false;
            }
        }
    }
}
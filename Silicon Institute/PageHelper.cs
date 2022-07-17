using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Silicon_Institute
{
    internal class PageHelper
    {
        internal static void BindListToDropDown(ArrayList list, DropDownList dropDown, string textField, string valueField)
        {
            dropDown.DataSource = list;
            dropDown.DataTextField = textField;
            dropDown.DataValueField = valueField;
            dropDown.DataBind();
        }
    }
}
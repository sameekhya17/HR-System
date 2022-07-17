<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Silicon_Institute.EmployeeDetails" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="EmployeeContent">
    <div style="min-height:500px">
        <table style="width:100%">
            <tr>
                <td colspan="3">
                    <asp:Label ID="LabelId" Visible="false" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:40%; text-align:right">
                    Employee Type:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="width:50%; text-align:left">
                    <asp:DropDownList runat="server" OnSelectedIndexChanged="DropDownTypes_SelectedIndexChanged" ID="DropDownTypes"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Employee Category:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:DropDownList OnSelectedIndexChanged="DropDownListCategories_SelectedIndexChanged" runat="server" ID="DropDownListCategories"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    First Name:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="TextBoxFirstName_TextChanged" ID="TextBoxFirstName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Middle Name:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:TextBox OnTextChanged="TextBoxMiddleName_TextChanged" runat="server" ID="TextBoxMiddleName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                   Last Name:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:TextBox OnTextChanged="TextBoxLastName_TextChanged" runat="server" ID="TextBoxLastName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Date of Birth:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:TextBox runat="server" ID="TextBoxDOB"></asp:TextBox>
                    <asp:ImageButton ID="CalendarButton" Height="20px" runat="server" OnClick="CalendarButton_Click" ImageUrl="~/Images/Calendar.jpg" />
                    <asp:Calendar OnSelectionChanged="DOBCalendar_SelectionChanged" runat="server" ID="DOBCalendar" Visible="false"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Date of Joining:
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:TextBox runat="server" ID="TextBoxDOJ"></asp:TextBox>
                    <asp:ImageButton ID="CalendarButtonDOJ" Height="20px" OnClick="CalendarButtonDOJ_Click" runat="server" ImageUrl="~/Images/Calendar.jpg" />
                    <asp:Calendar OnSelectionChanged="CalendarDOJ_SelectionChanged" runat="server" ID="CalendarDOJ" Visible="false"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right">
                    Document Type:&nbsp;&nbsp; <asp:DropDownList runat="server" ID="DropDownListDocumentTypes"></asp:DropDownList>
                    <asp:FileUpload ID="FileUploadDocument" runat="server" />
                    <asp:Button runat="server" ID="ButtonUpload" Text="Upload" OnClick="ButtonUpload_Click"></asp:Button>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right">
                    <asp:GridView DataKeyNames="Id" OnRowCommand="GridViewDocuments_RowCommand" Width="100%" AutoGenerateColumns="false" runat="server" ID="GridViewDocuments">
                        <Columns>
                            <asp:BoundField HeaderText="Document Type" DataField="DocumentTypeText" />
                            <asp:BoundField HeaderText="File Name" DataField="FileName" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ButtonDelete" CommandName="DeleteFile" runat="server" Text="Delete"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ButtonDownload" CommandName="Download" runat="server" Text="Download"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                     <asp:Button ID="ButtonSave" CssClass="SubmitButton" Text="Save" runat="server" OnClick="ButtonSave_Click" />
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="text-align:left">
                    <asp:Button ID="ButtonCancel" CssClass="CancelButton" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
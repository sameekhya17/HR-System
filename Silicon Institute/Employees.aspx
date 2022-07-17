<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employees.aspx.cs" Inherits="Silicon_Institute.Employees" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="EmployeesContent">
<div style="min-height:500px; text-align:left">
           <div style="width:100%; background-color:khaki">
               <label style="font-weight:bold">Name:</label>&nbsp;&nbsp;<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;&nbsp;<label style="font-weight:bold">Type:</label>&nbsp;&nbsp;<asp:DropDownList ID="DropDownTypes" runat="server"></asp:DropDownList>
               &nbsp;&nbsp;&nbsp;&nbsp;<label style="font-weight:bold">Category:</label>&nbsp;&nbsp;<asp:DropDownList ID="DropDownCategories" runat="server"></asp:DropDownList>
               &nbsp;<asp:CheckBox ID="CheckDeleted" runat="server" Text="Include Deleted" />
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Buttonsearch" Text="Search" runat="server" OnClick="Buttonsearch_Click" />
           </div>
               <br />
           <asp:GridView ID="GridViewEmployees" DataKeyNames="Id" OnRowEditing="GridViewEmployees_RowEditing" AutoGenerateColumns="False" 
                runat="server" HeaderStyle-BackColor="LightSkyBlue" AlternatingRowStyle-BackColor="SpringGreen" BackColor="MistyRose">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelFirstName" Text=<%#Eval("FullName")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelType" Text=<%#Eval("EmployeeTypeText")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCategory" Text=<%#Eval("CategoryText")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedBy" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDate" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdated" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDate" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelIsActive" Text=<%#Eval("IsActiveText")%>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" />
                </Columns>
            </asp:GridView>
           <br />
           <asp:Button ID="ButtonNew" runat="server" OnClick="ButtonNew_Click" Text="New Employee" BackColor="#FFCC66" BorderStyle="Inset" />
        </div>
    </asp:Content>
    
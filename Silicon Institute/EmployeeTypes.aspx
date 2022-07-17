<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeTypes.aspx.cs" Inherits="Silicon_Institute.EmployeeTypes" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="EmployeeTypesContent">
    <style type="text/css">
        .Initial
        {
            display:block;
            float:left;
            background-color:aquamarine;
            color:black;
            font-weight:bold;
        }
        .Clicked
        {
            display:block;
            float:left;
            background-color:darkgray;
            color:white;
            font-weight:bold;
        }
    </style>
    <div style="min-height:500px">
    <asp:Button Text="Employee Types" BorderStyle="Solid" OnClick="ButtonEmployeeTypes_Click" ID="ButtonEmployeeTypes" runat="server" />
    <asp:Button Text="Employee Categories" OnClick="ButtonEmployeeCategories_Click" BorderStyle="Solid" ID="ButtonEmployeeCategories" runat="server" />
    <asp:Button Text="Document Types" OnClick="ButtonDocumentType_Click" BorderStyle="Solid" ID="ButtonDocumentType" runat="server" />
    <br /><br />
    <asp:MultiView ID="MainView" runat="server">
        <asp:View ID="ViewType" runat="server">
            <asp:GridView ShowFooter="true" OnRowCommand="GridViewEmployeeTypes_RowCommand" ID="GridViewEmployeeTypes" DataKeyNames="Id" AutoGenerateColumns="False" 
                runat="server" HeaderStyle-BackColor="LightSkyBlue" AlternatingRowStyle-BackColor="SpringGreen" BackColor="MistyRose">
                <Columns>
                    <asp:TemplateField HeaderText="Employee Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelDescription" Text=<%#Eval("Description")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="TextDescription" Text=<%#Eval("Description")%>></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextDescriptionInsert" Text=<%#Eval("Description")%>></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedBy" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedByEdit" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDate" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDateEdit" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdated" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedEdit" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDate" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDateEdit" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelIsActive" Text=<%#Eval("IsActiveText")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox runat="server" ID="CheckIsActive" Checked=<%#Eval("IsActive")%>></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="ButtonEdit" CommandName="Alter" Text="Alter"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" ID="ButtonSave" CommandName="Save" Text="Save"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="ButtonCancel" CommandName="CancelEdit" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton runat="server" ID="ButtonInsert" CommandName="Insert" Text="Insert"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="ViewCategories" runat="server">
            <asp:GridView ShowFooter="true" OnRowCommand="GridViewCategories_RowCommand" ID="GridViewCategories" DataKeyNames="Id" AutoGenerateColumns="False" 
                runat="server" HeaderStyle-BackColor="LightSkyBlue" AlternatingRowStyle-BackColor="SpringGreen" BackColor="MistyRose">
                <Columns>
                    <asp:TemplateField HeaderText="Employee Category">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelDescription" Text=<%#Eval("Description")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="TextDescription" Text=<%#Eval("Description")%>></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextDescriptionInsert" Text=<%#Eval("Description")%>></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedBy" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedByEdit" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDate" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDateEdit" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdated" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedEdit" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDate" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDateEdit" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelIsActive" Text=<%#Eval("IsActiveText")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox runat="server" ID="CheckIsActive" Checked=<%#Eval("IsActive")%>></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="ButtonEdit" CommandName="Alter" Text="Alter"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" ID="ButtonSave" CommandName="Save" Text="Save"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="ButtonCancel" CommandName="CancelEdit" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton runat="server" ID="ButtonInsert" CommandName="Insert" Text="Insert"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>  
        <asp:View ID="ViewDocumentType" runat="server">
            <asp:GridView ShowFooter="true" OnRowCommand="GridViewDocumentTypes_RowCommand" ID="GridViewDocumentTypes" DataKeyNames="Id" AutoGenerateColumns="False" 
                runat="server" HeaderStyle-BackColor="LightSkyBlue" AlternatingRowStyle-BackColor="SpringGreen" BackColor="MistyRose">
                <Columns>
                    <asp:TemplateField HeaderText="Document Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelDescription" Text=<%#Eval("Description")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="TextDescription" Text=<%#Eval("Description")%>></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="TextDescriptionInsert" Text=<%#Eval("Description")%>></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedBy" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedByEdit" Text=<%#Eval("CreatedBy")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDate" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelCreatedDateEdit" Text=<%#Eval("CreatedDate")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated By">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdated" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedEdit" Text=<%#Eval("LastUpdatedBy")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Updated Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDate" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label runat="server" ID="LabelLastUpdatedDateEdit" Text=<%#Eval("LastUpdatedDate")%>></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelIsActive" Text=<%#Eval("IsActiveText")%>></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox runat="server" ID="CheckIsActive" Checked=<%#Eval("IsActive")%>></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="ButtonEdit" CommandName="Alter" Text="Alter"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" ID="ButtonSave" CommandName="Save" Text="Save"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="ButtonCancel" CommandName="CancelEdit" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton runat="server" ID="ButtonInsert" CommandName="Insert" Text="Insert"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
    </div>
</asp:Content>
    
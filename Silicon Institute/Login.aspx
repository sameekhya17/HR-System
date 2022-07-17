<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="Silicon_Institute.Login" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ID="LoginContent">
    <table style="width:100%">
        <tr>
            <td style="width:20%">
            </td>
            <td style="width:60%">
                <div style="background-color:thistle; height:250px; width:100%;">
            <table style="width:100%">
                <tr>
                    <td colspan="2" style="font-weight:bold; text-align:center; font-size:larger">Login Credentials</td>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight:bold; text-align:center">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width:50%">UserName:</td>
                    <td><asp:TextBox runat="server" ID="TextBoxUserName" style="margin-left: 0px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxUserName" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight:bold; text-align:center">&nbsp;</td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="TextBoxPassword" TextMode="Password" OnTextChanged="TextBoxPassword_TextChanged"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-weight:bold; text-align:center">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:center"><asp:Button runat="server" ID="buttonCancel" CssClass="CancelButton" Text="Cancel" OnClick="buttonCancel_Click"/></td>
                    <td style="text-align:center"><asp:Button runat="server" ID="buttonSave" CssClass="SubmitButton" Text="Save" OnClick="buttonSave_Click" /></td>
                </tr>
                </table>
        </div>
            </td>
            <td style="width:20%">
                &nbsp;</td>
        </tr>
        </table>
    </asp:Content>
    
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewBusiness.aspx.cs" Inherits="WebApplication1.NewBusiness" %>

<meta name="viewport" content="width=device-width, initial-scale=1.0">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>New Business Form</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/masterStyle.css" />
</head>

<body>
<%--<header>
    <uc:Nav runat="server" id="Nav" />
</header>--%>

<form id="form1" runat="server" defaultbutton="Button1">
    <div class="header">New Business Request<br /></div>

    <div class="newbusForm">
        <br />
        <input type="button" id="backButton" value="Back" onclick="history.go(-1)" class="styledButton" />
        <asp:Button ID="btnLogOff" runat="server" OnClick="btnLogOff_Click" Text="Logout" CssClass="styledButton" />
        <br />
        <asp:Label ID="lblFormSubmitSuccess" runat="server" CssClass="submitSuccess"></asp:Label>
        <br />
        <table class="responsive-table">
            <tr>
                <td class="formLabels">
                    Our 4-Digit Ref:<br />
                    <asp:TextBox ID="yourRefTxt" runat="server" Width="73px" CssClass="auto-style25" ReadOnly="True"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorRefValidation" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Client Account Number<span class="astrix">*</span>:<br />
                    <asp:TextBox ID="clientAccountNumberTxt" runat="server" CssClass="responsive-textfield" Width="100%" OnTextChanged="TextBox13_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorClientAccountNumber" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Full Name<span class="astrix">*</span>:<br />
                    <asp:TextBox ID="fullNameTxt" runat="server" CssClass="responsive-textfield" Width="100%"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorNameValidation" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Address<span class="astrix">*</span>:<br />
                    <asp:TextBox ID="addressTxt" runat="server" TextMode="MultiLine" CssClass="multiLineTextbox" Width="100%"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorAddressValidation" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Type of Debt (e.g Goods Supplied)<span class="astrix">*</span>:<br />
                    <asp:TextBox ID="debtTypeTxt" runat="server" CssClass="responsive-textfield" TabIndex="4"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorTypeOfDebtValidation" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Special Instructions (optional):<br />
                    <asp:TextBox ID="instructionsTxt" runat="server" TextMode="MultiLine" CssClass="multiLineTextbox" TabIndex="5"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorInstructionsValidation" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Comments (optional):<br />
                    <asp:TextBox ID="TextBox13" runat="server" TextMode="MultiLine" CssClass="multiLineTextbox" TabIndex="6"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorComments" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Agreement Date (if any):<br />
                    <asp:TextBox ID="TextBox10" runat="server" Width="100%" TabIndex="7" TextMode="Date" onkeydown="return false;" onpaste="return false;"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorAgreementDate" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Balance Due<span class="astrix">*</span>:<br />
                    <asp:TextBox ID="TextBox9" runat="server" Width="100%" TabIndex="8"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorBalanceValidation" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Date of Birth<span class="astrix">*</span>:<br />
                    <asp:TextBox ID="dobTxt" runat="server" Width="100%" TextMode="Date" onkeydown="return false;" onpaste="return false;" TabIndex="9"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorDOB" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Phone Number:<br />
                    <asp:TextBox ID="phoneTxt" runat="server" Width="100%" TabIndex="10"></asp:TextBox>
                    <br />
                    <asp:Label ID="errorPhoneNumber" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    Upload Attachment (optional):<br />
                    <asp:FileUpload ID="fileUpload" runat="server" CssClass="responsive-textfield" />
                    <br />
                    <asp:Label ID="errorFileUpload" runat="server" CssClass="labelBadValidation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabels">
                    <span class="astrix">*Required Field</span>&nbsp; 
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button CssClass="styledButton" ID="Button1" runat="server" Font-Size="Medium" OnClick="Button1_Click" Text="Submit New Business"/>
        <br />
        <asp:Label ID="lblCroskReference" runat="server" Text="Label"></asp:Label>
    </div>
</form>

</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CLIR_Book_A_Seat.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Sign in</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            font-size: large;
        }
        .auto-style3 {
            font-size: xx-small;
        }
    </style>
</head>
<body>
    <form id="account_signin" runat="server">
        <div class="auto-style1">
            <h1>CLIR Book-A-Seat</h1>
        </div>
        <br />
        <br />
    <div class="auto-style2">
        Account number:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="accnum_txt" runat="server" MaxLength="10" Width="175px" style="margin-left: 5px; margin-right: 5px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="accnum_vld" runat="server" ControlToValidate="accnum_txt" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="position: absolute;" Display="Dynamic">*</asp:RequiredFieldValidator>
        <br />
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="accpass_txt" runat="server" MaxLength="30" Width="175px" TextMode="Password" style="margin-left: 5px; margin-right: 5px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="accpass_vld" runat="server" ControlToValidate="accpass_txt" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="position: absolute;" Display="Dynamic">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="login_lbl" runat="server" CssClass="auto-style3" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="loginsubmit_btn" runat="server" OnClick="loginsubmit_btn_Click" Text="Log in" Width="150px" Height="34px" />
        </div>
    </form>
    </body>
</html>

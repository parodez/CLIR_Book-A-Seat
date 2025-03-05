<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="CLIR_Book_A_Seat.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seat Register</title>
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
    <form id="seat_register" runat="server">
        <div class="auto-style1">
            <h1>CLIR Sign in</h1>
        </div>
        <br />
        <br />
    <div class="auto-style2">
        Account number:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="seatnum_txt" runat="server" MaxLength="10" Width="175px" style="margin-left: 5px; margin-right: 5px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="seatnum_vld" runat="server" ControlToValidate="seatnum_txt" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="position: absolute;" Display="Dynamic">*</asp:RequiredFieldValidator>
        <br />
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="seatpass_txt" runat="server" MaxLength="30" Width="175px" TextMode="Password" style="margin-left: 5px; margin-right: 5px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="seatpass_vld" runat="server" ControlToValidate="seatpass_txt" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="position: absolute;" Display="Dynamic">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="seatregister_lbl" runat="server" CssClass="auto-style3" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="seatcancel_btn" runat="server" OnClick="seatcancel_btn_Click" Text="Cancel" Width="120px" Height="34px" style="margin-left: 5px; margin-right:5px;" CausesValidation="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="seatsubmit_btn" runat="server" OnClick="seatsubmit_btn_Click" Text="Submit" Width="120px" Height="34px" style="margin-left: 5px; margin-right:5px;" />
        </div>
    </form>
</body>
</html>

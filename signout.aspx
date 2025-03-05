<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signout.aspx.cs" Inherits="CLIR_Book_A_Seat.signout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Out</title>
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
         .auto-style4 {
             left: 841px;
         }
    </style>
</head>
<body>
    <form id="sign_out" runat="server">
       <div class="auto-style1">
           <h1>CLIR Sign out</h1>
       </div>
       <asp:SqlDataSource ID="CLIR_DB_Signout" runat="server"></asp:SqlDataSource>
       <br />
   <div class="auto-style2">
       Account number:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="signoutnum_txt" runat="server" MaxLength="10" Width="175px" style="margin-left: 5px; margin-right: 5px;"></asp:TextBox>
       <asp:RequiredFieldValidator ID="signoutnum_vld" runat="server" ControlToValidate="signoutnum_txt" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="position: absolute;" Display="Dynamic" CssClass="auto-style4">*</asp:RequiredFieldValidator>
       <br />
       <br />
       Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="signoutpass_txt" runat="server" MaxLength="30" Width="175px" TextMode="Password" style="margin-left: 5px; margin-right: 5px;"></asp:TextBox>
       <asp:RequiredFieldValidator ID="signoutpass_vld" runat="server" ControlToValidate="signoutpass_txt" EnableClientScript="False" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="position: absolute;" Display="Dynamic">*</asp:RequiredFieldValidator>
       <br />
       <asp:Label ID="signout_lbl" runat="server" CssClass="auto-style3" ForeColor="Red"></asp:Label>
       <br />
       <br />
       <asp:Button ID="signoutcancel_btn" runat="server" Text="Cancel" Width="120px" Height="34px" style="margin-left: 5px; margin-right:5px;" CausesValidation="False" OnClick="signoutcancel_btn_Click" />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="signoutsubmit_btn" runat="server" Text="Submit" Width="120px" Height="34px" style="margin-left: 5px; margin-right:5px;" OnClick="signoutsubmit_btn_Click" />
       </div>
    </form>
</body>
</html>

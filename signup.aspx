<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="CLIR_Book_A_Seat.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style3 {
            font-size: x-small;
        }
        td{
            width: 300px;
            text-align: left;
        }
    </style>
    <script>
        function toggleSubmitButton() {
            var checkbox = document.getElementById('<%= terms.ClientID %>');
            var submitButton = document.getElementById('<%= signupsubmit_btn.ClientID %>');
            submitButton.disabled = !checkbox.checked; //enable if checked, disable if unchecked
    }
    </script>
</head>
<body>
    <form id="account_signup" runat="server">
        <div class="auto-style1">
            <h1>CLIR Account Sign up</h1>
        </div>

    <div class="auto-style1">
        <center>
        <table>
            <tr>
                <td>
                    <h3>Student number:</h3>
                </td>
                <td>
                    <asp:TextBox ID="studnum_txt" runat="server" Width="270px" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="studnum_txt" ErrorMessage="*" ForeColor="Red" style="margin-left: 5px;"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <h3>Student name:</h3>
                </td>
                <td>
                    <asp:TextBox ID="studname_txt" runat="server" Width="270px" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="studname_vld" runat="server" ControlToValidate="studname_txt" ErrorMessage="*" ForeColor="Red" style="margin-left: 5px;"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <h3>Department:</h3>
                </td>
                <td>
                    <asp:DropDownList ID="dept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dept_SelectedIndexChanged" Width="95px">
                    <asp:ListItem Value="CAS">CAS</asp:ListItem>
                    <asp:ListItem Value="CCIS">CCIS</asp:ListItem>
                    <asp:ListItem Value="CHS">CHS</asp:ListItem>
                    <asp:ListItem Value="CMET">CMET</asp:ListItem>
                    <asp:ListItem Value="ETYCB">ETYCB</asp:ListItem>
                    <asp:ListItem Value="MIA">MIA</asp:ListItem>
                    <asp:ListItem Value="MITL">MITL</asp:ListItem>
                    <asp:ListItem Value="SHS">SHS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <h3>Program:</h3>
                </td>
                <td>
                    <asp:DropDownList ID="prog" runat="server" Width="95px" AutoPostBack="True">
                    <asp:ListItem>COMM</asp:ListItem>
                    <asp:ListItem>MMA</asp:ListItem>
            </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <h3>Year level:</h3>
                </td>
                <td>
                    <asp:DropDownList ID="year" runat="server" Width="95px" AutoPostBack="True" ValidateRequestMode="Disabled">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <h3>Password:</h3>
                </td>
                <td>
                    <asp:TextBox ID="pass_txt" runat="server" Width="270px" MaxLength="30" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="pass_vld" runat="server" ControlToValidate="pass_txt" ErrorMessage="*" ForeColor="Red" style="margin-left: 5px;"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <h3>Confirm password:</h3>
                </td>
                <td>
                    <asp:TextBox ID="confpass_txt" runat="server" Width="270px" MaxLength="30" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="confpass_vld" runat="server" ControlToValidate="confpass_txt" ErrorMessage="*" ForeColor="Red" style="margin-left: 5px;"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td colspan ="2" class="auto-style1">
                    <asp:Label ID="signup_lbl" runat="server" CssClass="auto-style3" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td colspan ="2" class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="MALAYAN COLLEGES LAGUNA, INC., A MAPUA SCHOOL (MCL) commits compliance to the Republic Act No. 10173, otherwise known as the Data Privacy Act of 2012. MCL recognizes its responsibilities under the same Act and upholds its commitment to protect the integrity and security of the data being collected, recorded, organized, updated, used, consolidated or destructed from its internal and external clients. Please be assured that any personal data obtained will be generated and stored in secured systems as warranted by the DPA. "></asp:Label>
                    <br />
                    <asp:CheckBox ID="terms" runat="server" AutoPostBack="false" onclick="toggleSubmitButton();" CssClass="auto-style3" Text="Yes, I am giving my consent." />

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="back_btn" runat="server" Text="Back" style="margin-left: 5px; margin-right: 5px;" Width="85px" CausesValidation="False" OnClick="back_btn_Click"/>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="signupsubmit_btn" runat="server" Text="Submit" style="margin-left: 5px; margin-right: 5px;" OnClick="signupsubmit_btn_Click" Width="85px"/>
                </td>
             </tr>
    </table>
    </center>
    </div>

    </form>
    </body>
</html>

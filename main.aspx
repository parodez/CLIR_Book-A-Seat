<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="CLIR_Book_A_Seat.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        .auto-style2 {
            text-align: center;
        }
        .container{
            display: grid;
            grid-template-columns: repeat(21, 1fr);
            grid-template-rows: repeat(7, 1fr);
            column-width: 80px;
            width: 100%;
            height: 100%;
            padding: 0px 0px 50px 0px;
            text-align: center;
        }
        .cell{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
            visibility: hidden;
        }
        .cell1{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: none;
            border-left: 2px solid lightgrey;
            border-right: 2px solid lightgrey;
            background-color: white;
            font-size: 10px;
        }
        .cell2{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: none;
            border-left: 2px solid lightgrey;
            border-right: 2px solid lightgrey;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell3{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: none;
            border-left: 2px solid lightgrey;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell4{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: 2px solid lightgrey;
            border-left: none;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell5{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: none;
            border-left: none;
            border-right: 2px solid lightgrey;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell6{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: none;
            border-left: none;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell7{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: 2px solid lightgrey;
            border-left: none;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell8{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: 2px solid lightgrey;
            border-left: 2px solid lightgrey;
            border-right: 2px solid lightgrey;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell9{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: 2px solid lightgrey;
            border-left: 2px solid lightgrey;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell10{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: none; 
            border-bottom: 2px solid lightgrey;
            border-left: none;
            border-right: 2px solid lightgrey;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell11{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: 2px solid lightgrey;
            border-left: none;
            border-right: 2px solid lightgrey;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell12{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: none;
            border-left: none;
            border-right: 2px solid lightgrey;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell13{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: none;
            border-left: 2px solid lightgrey;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .cell14{
            height: 68px;
            width: 68px;
            margin: 2px;
            border-top: 2px solid lightgrey; 
            border-bottom: none;
            border-left: none;
            border-right: none;
            border-color: lightgray;
            background-color: white;
            font-size: 10px;
        }
        .auto-style3 {
            display: grid;
            grid-template-columns: repeat(21, 1fr);
            grid-template-rows: repeat(7, 1fr);
            column-width: 80px;
            width: 100%;
            height: 100%;
            text-align: center;
        }
        .carrel{
            height: 68px;
            width: 68px;
            margin: 2px;
            background-color: #00CC66; 
            border-color: #85EC7A;
            border-width: 3px;
            font-weight: bold;
            font-size: 18px;
            color: white;
            text-align: center;
        }
        .desk{
            height: 68px;
            width: 68px;
            margin: 2px;
        }

    </style>
</head>
<body>
    <form id="user_logs" runat="server">
        <br />
        <div class="auto-style1">
            Semester:
            <asp:DropDownList ID="semester" runat="server" style="margin-left: 5px; margin-right: 5px;" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="semester_SelectedIndexChanged">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="records" runat="server" Text="Records" style="margin-left: 5px; margin-right: 5px;" Width="80px" OnClick="records_Click"/>
            <asp:Button ID="signup_btn" runat="server" Text="Sign up" style="margin-left: 5px; margin-right: 5px;" Width="80px" OnClick="signup_btn_Click"/>
            <asp:Button ID="logout_btn" runat="server" Text="Log out" style="margin-left: 5px; margin-right: 5px;" Width="80px" OnClick="logout_btn_Click"/>
        </div>
        <br />
        <br />
    <div class="auto-style2">
        <h1>CLIR Individual Study Zone</h1>
    </div>
        <br />
    <div class="auto-style3">
        <asp:Button ID="Button1" runat="server" CssClass="desk" ViewStateMode="Disabled" Enabled="False" />
        <asp:Button ID="Button2" runat="server" CssClass="desk" Enabled="False" />
        <asp:Button ID="Button3" runat="server" CssClass="desk" Text="Button" BackColor="Black" Enabled="False" />
        <asp:Button ID="Button4" runat="server" CssClass="cell1" Enabled="False" />
        <asp:Button ID="C_01" runat="server" CssClass="carrel" Text="C_01" OnClick="btn_Click" />
        <asp:Button ID="C_02" runat="server" CssClass="carrel" Text="C_02" OnClick="btn_Click"/>
        <asp:Button ID="Button7" runat="server" CssClass="cell1" Font-Bold="False" Enabled="False" />
        <asp:Button ID="C_03" runat="server" CssClass="carrel" Text="C_03" OnClick="btn_Click" />
        <asp:Button ID="C_04" runat="server" CssClass="carrel" Text="C_04" OnClick="btn_Click" />
        <asp:Button ID="Button10" runat="server" CssClass="cell1" Enabled="False" />
        <asp:Button ID="C_05" runat="server" CssClass="carrel" Text="C_05" OnClick="btn_Click" />
        <asp:Button ID="C_06" runat="server" CssClass="carrel" Text="C_06" OnClick="btn_Click" />
        <asp:Button ID="Button13" runat="server" CssClass="cell1" Enabled="False" />
        <asp:Button ID="C_07" runat="server" CssClass="carrel" Text="C_07" OnClick="btn_Click" />
        <asp:Button ID="C_08" runat="server" CssClass="carrel" Text="C_08" OnClick="btn_Click" />
        <asp:Button ID="Button16" runat="server" CssClass="cell1" Enabled="False" />
        <asp:Button ID="C_09" runat="server" CssClass="carrel" Text="C_09" OnClick="btn_Click" />
        <asp:Button ID="C_10" runat="server" CssClass="carrel" Text="C_10" OnClick="btn_Click" />
        <asp:Button ID="Button19" runat="server" CssClass="cell1" Enabled="False" />
        <asp:Button ID="C_11" runat="server" CssClass="carrel" Text="C_11" OnClick="btn_Click" />
        <asp:Button ID="C_12" runat="server" CssClass="carrel" Text="C_12" OnClick="btn_Click" />

        <asp:Button ID="Button22" runat="server" CssClass="desk" ViewStateMode="Disabled" Enabled="False" />
        <asp:Button ID="Button23" runat="server" CssClass="desk" ViewStateMode="Disabled" Enabled="False" />
        <asp:Button ID="Button24" runat="server" CssClass="desk" Text="Button" BackColor="Black" Enabled="False" />
        <asp:Button ID="Button25" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_13" runat="server" CssClass="carrel" Text="C_13" OnClick="btn_Click" />
        <asp:Button ID="C_14" runat="server" CssClass="carrel" Text="C_14" OnClick="btn_Click" />
        <asp:Button ID="Button28" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_15" runat="server" CssClass="carrel" Text="C_15" OnClick="btn_Click" />
        <asp:Button ID="C_16" runat="server" CssClass="carrel" Text="C_16" OnClick="btn_Click" />
        <asp:Button ID="Button31" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_17" runat="server" CssClass="carrel" Text="C_17" OnClick="btn_Click" />
        <asp:Button ID="C_18" runat="server" CssClass="carrel" Text="C_18" OnClick="btn_Click" />
        <asp:Button ID="Button34" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_19" runat="server" CssClass="carrel" Text="C_19" OnClick="btn_Click" />
        <asp:Button ID="C_20" runat="server" CssClass="carrel" Text="C_20" OnClick="btn_Click" />
        <asp:Button ID="Button37" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_21" runat="server" CssClass="carrel" Text="C_21" OnClick="btn_Click" />
        <asp:Button ID="C_22" runat="server" CssClass="carrel" Text="C_22" OnClick="btn_Click" />
        <asp:Button ID="Button40" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_23" runat="server" CssClass="carrel" Text="C_23" OnClick="btn_Click" />
        <asp:Button ID="C_24" runat="server" CssClass="carrel" Text="C_24" OnClick="btn_Click" />

        <asp:Button ID="Button43" runat="server" CssClass="desk" Text="Button" BackColor="Black" Enabled="False" />
        <asp:Button ID="Button44" runat="server" CssClass="desk" Text="Button" BackColor="Black" Enabled="False" />
        <asp:Button ID="Button45" runat="server" CssClass="desk" Text="Button" BackColor="Black" Enabled="False" />
        <asp:Button ID="Button46" runat="server" CssClass="cell3" Enabled="False" />
        <asp:Button ID="Button47" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button48" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button49" runat="server" CssClass="cell7" Enabled="False" />
        <asp:Button ID="Button50" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button51" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button52" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button53" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button54" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button55" runat="server" CssClass="cell7" Enabled="False" />
        <asp:Button ID="Button56" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button57" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button58" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button59" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button60" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button61" runat="server" CssClass="cell7" Enabled="False" />
        <asp:Button ID="Button62" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button63" runat="server" CssClass="cell11" Enabled="False" />

        <asp:Button ID="Button64" runat="server" CssClass="cell13" Enabled="False" />
        <asp:Button ID="Button65" runat="server" CssClass="carrel" Text="You" BackColor="#66CCFF" BorderColor="#0099FF" BorderStyle="Solid" BorderWidth="2px" Enabled="False" />
        <asp:Button ID="Button66" runat="server" CssClass="cell14" Enabled="False" />
        <asp:Button ID="Button67" runat="server" CssClass="cell5" Enabled="False" />
        <asp:Button ID="C_25" runat="server" CssClass="carrel" Text="C_25" OnClick="btn_Click" />
        <asp:Button ID="Button69" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_26" runat="server" CssClass="carrel" Text="C_26" OnClick="btn_Click" />
        <asp:Button ID="Button71" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_27" runat="server" CssClass="carrel" Text="C_27" OnClick="btn_Click" />
        <asp:Button ID="Button73" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_28" runat="server" CssClass="carrel" Text="C_28" OnClick="btn_Click" />
        <asp:Button ID="Button75" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_29" runat="server" CssClass="carrel" Text="C_29" OnClick="btn_Click" />
        <asp:Button ID="Button77" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_30" runat="server" CssClass="carrel" Text="C_30" OnClick="btn_Click" />
        <asp:Button ID="Button79" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_31" runat="server" CssClass="carrel" Text="C_31" OnClick="btn_Click" />
        <asp:Button ID="Button81" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_32" runat="server" CssClass="carrel" Text="C_32" OnClick="btn_Click" />
        <asp:Button ID="Button83" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_33" runat="server" CssClass="carrel" Text="C_33" OnClick="btn_Click" />

        <asp:Button ID="Button85" runat="server" CssClass="cell3" Enabled="False" />
        <asp:Button ID="Button86" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button87" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button88" runat="server" CssClass="cell5" Enabled="False" />
        <asp:Button ID="C_34" runat="server" CssClass="carrel" Text="C_34" OnClick="btn_Click" />
        <asp:Button ID="Button90" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_35" runat="server" CssClass="carrel" Text="C_35" OnClick="btn_Click" />
        <asp:Button ID="Button92" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_36" runat="server" CssClass="carrel" Text="C_36" OnClick="btn_Click" />
        <asp:Button ID="Button94" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_37" runat="server" CssClass="carrel" Text="C_37" OnClick="btn_Click" />
        <asp:Button ID="Button96" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_38" runat="server" CssClass="carrel" Text="C_38" OnClick="btn_Click" />
        <asp:Button ID="Button98" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_39" runat="server" CssClass="carrel" Text="C_39" OnClick="btn_Click" />
        <asp:Button ID="Button100" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_40" runat="server" CssClass="carrel" Text="C_40" OnClick="btn_Click" />
        <asp:Button ID="Button102" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_41" runat="server" CssClass="carrel" Text="C_41" OnClick="btn_Click" />
        <asp:Button ID="Button104" runat="server" CssClass="cell2" Enabled="False" />
        <asp:Button ID="C_42" runat="server" CssClass="carrel" Text="C_42" OnClick="btn_Click" />

        <asp:Button ID="Button106" runat="server" CssClass="cell3" Enabled="False" />
        <asp:Button ID="Button107" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button108" runat="server" CssClass="cell" Enabled="False"/>
        <asp:Button ID="Button109" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button110" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button111" runat="server" CssClass="cell" Enabled="False"/>
        <asp:Button ID="Button112" runat="server" CssClass="cell4" Enabled="False"/>
        <asp:Button ID="Button113" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button114" runat="server" CssClass="cell4" Enabled="False"/>
        <asp:Button ID="Button115" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button116" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button117" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button118" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button119" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button120" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button121" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button122" runat="server" CssClass="cell4" Enabled="False" />
        <asp:Button ID="Button123" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button124" runat="server" CssClass="cell6" Enabled="False" />
        <asp:Button ID="Button125" runat="server" CssClass="cell" Enabled="False" />
        <asp:Button ID="Button126" runat="server" CssClass="cell12" Enabled="False" />

        <asp:Button ID="Button127" runat="server" CssClass="cell9" Enabled="False" />
        <asp:Button ID="Button128" runat="server" CssClass="cell7" Enabled="False"/>
        <asp:Button ID="Button129" runat="server" CssClass="cell7" Enabled="False" />
        <asp:Button ID="Button130" runat="server" CssClass="cell10" Enabled="False" />
        <asp:Button ID="C_43" runat="server" CssClass="carrel" Text="C_43" OnClick="btn_Click" />
        <asp:Button ID="Button132" runat="server" CssClass="cell8" Enabled="False" />
        <asp:Button ID="C_44" runat="server" CssClass="carrel" Text="C_44" OnClick="btn_Click" />
        <asp:Button ID="Button134" runat="server" CssClass="cell8" Enabled="False" />
        <asp:Button ID="C_45" runat="server" CssClass="carrel" Text="C_45" OnClick="btn_Click" />
        <asp:Button ID="Button136" runat="server" CssClass="cell8" Enabled="False" />
        <asp:Button ID="C_46" runat="server" CssClass="carrel" Text="C_46" OnClick="btn_Click" />
        <asp:Button ID="Button138" runat="server" CssClass="cell8" Enabled="False" />
        <asp:Button ID="C_47" runat="server" CssClass="carrel" Text="C_47" OnClick="btn_Click" />
        <asp:Button ID="Button140" runat="server" CssClass="cell8" Enabled="False" />
        <asp:Button ID="C_48" runat="server" CssClass="carrel" Text="C_48" OnClick="btn_Click" />
        <asp:Button ID="Button142" runat="server" CssClass="cell8" Enabled="False" />
        <asp:Button ID="C_49" runat="server" CssClass="carrel" Text="C_49" OnClick="btn_Click" />
        <asp:Button ID="Button144" runat="server" CssClass="cell9" Enabled="False" />
        <asp:Button ID="Button145" runat="server" CssClass="cell7" Enabled="False" />
        <asp:Button ID="Button146" runat="server" CssClass="cell7" Enabled="False" />
        <asp:Button ID="Button147" runat="server" CssClass="cell10" Enabled="False" />    
    </div>
    </form>
    </body>
</html>

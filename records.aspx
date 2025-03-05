<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="records.aspx.cs" Inherits="CLIR_Book_A_Seat.records" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Records</title>
   <style>
        body::-webkit-scrollbar {
            display: none;
        }
        .tab-button {
            padding: 10px 20px;
            margin: 5px;
            border: none;
            cursor: pointer;
            background-color: lightgray;
            transition: 0.3s;
            width: 220px;
        }
        .tab-button.active {
            background-color: dodgerblue;
            color: white;
        }
        .styled-grid {
            width: 100%;
            border-collapse: collapse;
        }

        .styled-grid th, .styled-grid td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .styled-grid th {
            background-color: #f4f4f4;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <asp:Button ID="general" runat="server" Text="General" CssClass="tab-button" OnClick="btn_Click"/>
            <asp:Button ID="user_accounts" runat="server" Text="User Accounts" CssClass="tab-button" OnClick="btn_Click"/>
            <asp:Button ID="user_logs" runat="server" Text="User Logs" CssClass="tab-button" OnClick="btn_Click"/>
            <asp:Button ID="seat_info" runat="server" Text="Seat Info" CssClass="tab-button" OnClick="btn_Click"/>
            <asp:Button ID= "back" runat="server" Text="Back" CssClass="tab-button" OnClick="btn_Click"/>
        </div>

        <h1 style="text-align: center;"> <asp:Label ID="lblTableName" runat="server" Text=""></asp:Label></h1>

        <div style="margin: auto; width: 80%; text-align: center;">
            <center>
            <asp:GridView ID="gvRecords" runat="server" AutoGenerateColumns="true" CssClass="styled-grid" OnRowDataBound="totalText"></asp:GridView>
                </center>
        </div>
    </form>
</body>
</html>
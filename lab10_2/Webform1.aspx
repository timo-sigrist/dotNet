<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication_Framework.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMI Berechnung</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Gewicht (kg):"></asp:Label>
            <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Größe (m):"></asp:Label>
            <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="BMI Berechnen" OnClick="Button1_Click" /><br />
            <asp:Label ID="lblResult" runat="server" Text="Ergebnis:"></asp:Label>
        </div>
    </form>
</body>
</html>

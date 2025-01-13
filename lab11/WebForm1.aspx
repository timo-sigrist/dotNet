<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BMICalculator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
            font-family: arial,verdana,sans-serif;
        }
        .input {
            background-color: cornflowerblue;
        }
        td.label {
            width:180px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td class="label">
                    <asp:Label ID="Label1" runat="server" Text="Gewicht (kg)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Gewicht" runat="server" Columns="10" CssClass="input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Gr�sse (m)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Groesse" runat="server" Columns="10" CssClass="input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="BMI"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Bmi" runat="server" Columns="10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Berechne" runat="server" Text="Berechne" OnClick="Berechne_Click" />
                </td>
                <td>
                    <asp:Button ID="Reset" runat="server" Text="Reset" OnClick="Reset_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>

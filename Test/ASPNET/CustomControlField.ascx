<%@ Control Language="C#" AutoEventWireup="true" CodeBehinde="CustomControlField.ascx.cs"
    Inherits="WebApplication_Framework.CustomControlField" %>
<asp:TextBox ID="amount" Runat="server" />
<asp:DorpDownList ID="currency" AutoPostBack="true" OnSelectIndexChanged="Select" Runat="server">
    <asp:ListItem Text="Euro" Value="1.0" Selected="true" />
    <asp:ListItem Text="CHF" Value="1.1" />
</asp:DorpDownList>

<!-- Code Behinde CustomControlField.ascx.cs -->
public partial class CustomControlField: UserControl {
    public string Text {
       get { return amount.Text; }
       set { amount.Text = value; }
    }
    
    public void Select() {
        double val = Convert.ToDouble(amount.Text);
        double factor = Convert.ToDouble(currency.SelectedItem.Value);
        double newVal = val * factor;
       amount.Text = newVal.ToString();
    }
}

<!-- Eigenes Element verwenden in anderer Seite -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="my" TagName="CustomControlField" Src="CustomControlField.ascx" %> <!-- Definition -->
<html>
    <body>
        <my:CustomControlField ID="field" Runat="server" /> <!-- Eigens Feld -->
        <asp:Button ID="ok" Text="Convert" OnClick="ButtonClick" Runat="server" />
    </body>
</html>
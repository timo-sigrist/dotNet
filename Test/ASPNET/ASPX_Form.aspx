<%@ Page Language ="C#" Inherits="_AdderPage" CodeFile="Adder.aspx.cs" %>
<html>
    <head><title>Klassenstand</title></head>
    <body>
        <form method="post">
            <b>Klassenstand</b>
            <asp:Label ID="total" Text="0" Runat="server"></asp:Label>Euro<br><br>
            <asp:TextBox ID="amount" Runat="server" />
            <asp:Button ID="ok" Text="Einzahlen" onClick="ButtonClick" Runat="server" />
        </form>
    </body>
</html>



<!-- Hier 'Adder.apsx.cs' Code -->
using System; using System.Web.UI; using System.Web.UI.WebControls;
public partial class AdderPage : Page {
    <!-- ButtonClick-Methode -->
   public void ButtonClick(Object sender, EventArgs e) {
      int total = Int32.Parse(total.Text);
      int amount = Int32.Parse(amount.Text);
      total.Text = (total + amount).ToString();
   }
}


<!-- Form mit Validator-Objekten -->
<form method="post">
    <b>Form mit Validatoren</b>
    <p>
        Name: <asp:TextBox ID="name" Runat="server" Width="136px" />
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" Runat="server" ControlToValidate="name"
            ErrorMessage="Geben Sie ein Name ein" ><!-- display="none" Zeig die Fehlermeldung nicht an -->
        </asp:RequiredFieldValidator>
    </p>
    <p>
        Alter: <asp:TextBox ID="alter" Runat="server"/>
        <asp:RangeValidator id="RangeValidator1" Runat="server" ControlToValidate="alter"
            Minimum="0" Maximum="120" ErrorMessage="Das Alter muss zwischen 0 und 120 liegen">
        </asp:RangeValidator>
    </p>

    <asp:TextBox id="email" Runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator id="emailValidator" runat="server" ControlToValidate="email"
        ErrorMessage="Keine gültige Email" ValidationExpression=".*@.*\..*">
    </asp:RegularExpressionValidator>

    <!--  zb wenn password und passwordConfirm feld vorhanden, vergleich nur einen Wert-->
    <asp:CompareValidator ID="cvConfirmPassword" runat="server"
                ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                ErrorMessage="Passwords do not match." Operator="Equal"></asp:CompareValidator>

    <asp:TextBox id="customTextbox" Runat="server"></asp:TextBox>
    <asp:CustomValidator id="customValidator1" runat="server" ControlToValidate="customTextbox"
        ErrorMessage="Custom ist nicht valid" 
        ClientValidateFunction="ClientValidate" <!-- ClientValidate ist Javascript function in <script> tags -->
        OnServerValidate="ServerValidate"> <!-- ServerValidate ist eine Methode im aspx.cs File -->
    </asp:CustomValidator>

    <asp:Button ID="ButtonSubmit" Text="Commit" onClick="Submit" Runat="server" />
</form>
<!-- Code -> Page.IsValid() übernimmt die Prüfung und ist zwingend notwendig!!!! -->
<!-- Fehlermeldungen werden gesammelt und im Popup angezeigt -->
 public void Submit(Object sender, EventArgs e) {
    if (Page.IsValid) {
        // contiune with logic
    }  
 }

<!-- Damit Validation auch ab Version > 4 funktioniert muss Code in LoadPage ausgefphrt werden -->
ValidatorSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
<!-- Oder in web.config -->
<appSettings>
    <add key="ValidationSettings:UnobtrusiveValidationMode" value="None"/>
</appSettings>
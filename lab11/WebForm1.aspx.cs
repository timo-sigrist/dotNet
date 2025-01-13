using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BMICalculator {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition { Path = "~/scripts/jquery-1.7.2.min.js", DebugPath = "~/scripts/jquery-1.7.2.min.js", CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js", CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js" });
        }

        protected void Berechne_Click(object sender, EventArgs e) {
            try {
                double bmi = Double.Parse(this.Gewicht.Text) /
                    (Double.Parse(this.Groesse.Text) * Double.Parse(this.Groesse.Text));
                Bmi.Text = ((int)(10 * bmi) / 10.0).ToString();
            } catch (Exception ex) {
                ErrorMsg.Text = ex.Message;
            }

        }

        protected void Reset_Click(object sender, EventArgs e) {
            this.Gewicht.Text = "";
            this.Groesse.Text = "";
            this.Bmi.Text = "";
            this.ErrorMsg.Text = "";
        }
    }
}
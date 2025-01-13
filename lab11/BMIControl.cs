using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BMIControls {
    public class BMIControl : WebControl {
        const bool USE_RESOURCE = true;

        public string InputValue { get; set; }

        protected override void Render(HtmlTextWriter writer) {
            double calculatedBmi = 18.0;
            try {
                calculatedBmi = double.Parse(InputValue);
            } catch (FormatException) {
                // Log or handle invalid format if necessary
            } catch (Exception ex) {
                // Handle unexpected exceptions
            }

            string imageName = DetermineImage(calculatedBmi);

            if (!USE_RESOURCE) {
                writer.Write($"<img height=\"150\" src=\"{imageName}\"/>");
            } else {
                WriteEmbeddedImage(writer, imageName);
            }
        }

        private string DetermineImage(double bmi) {
            if (bmi <= 20) {
                return "bmi18.jpg";
            } else if (bmi <= 25) {
                return "bmi20.jpg";
            } else if (bmi <= 30) {
                return "bmi25.jpg";
            } else if (bmi <= 40) {
                return "bmi30.jpg";
            } else {
                return "bmi40.jpg";
            }
        }

        private void WriteEmbeddedImage(HtmlTextWriter writer, string imageName) {
            writer.Write("<img src=\"data:image/jpeg;base64,");

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream resourceStream = assembly.GetManifestResourceStream("BMIControl." + imageName)) {
                if (resourceStream != null) {
                    using (var image = new Bitmap(resourceStream)) {
                        ImageConverter converter = new ImageConverter();
                        byte[] imageBytes = (byte[])converter.ConvertTo(image, typeof(byte[]));
                        writer.Write(Convert.ToBase64String(imageBytes, Base64FormattingOptions.InsertLineBreaks));
                    }
                }
            }

            writer.Write("\" >");
        }
    }
}
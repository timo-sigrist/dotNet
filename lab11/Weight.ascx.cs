using System;
using System.Web.UI;

namespace BMI_Calculator {
    public partial class Weight : UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            // Initialization logic, if any, can go here.
        }

        protected void CalculateBMIButton_Click(object sender, EventArgs e) {
            try {
                // Parse input values from textboxes
                double weight = double.Parse(WeightTextBox.Text); // Weight in kilograms
                double height = double.Parse(HeightTextBox.Text); // Height in meters

                if (height <= 0 || weight <= 0) {
                    ResultLabel.Text = "Height and weight must be positive numbers.";
                    return;
                }

                // Calculate BMI
                double bmi = weight / (height * height);

                // Display the BMI value
                ResultLabel.Text = $"Your BMI is: {bmi:F2}";
            } catch (FormatException) {
                ResultLabel.Text = "Please enter valid numeric values for weight and height.";
            } catch (Exception ex) {
                ResultLabel.Text = $"An error occurred: {ex.Message}";
            }
        }
    }
}
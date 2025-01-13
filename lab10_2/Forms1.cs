using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace lab10_2 {
    public partial class Form1 : Form {

        private DataSet dataSet1;
        private string connectionString = @"Driver=SQLite3 ODBC Driver; Database=c:\tmp\app2020.db";


        public Form1() {
            InitializeComponent();
            dataSet1 = new DataSet();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnLoad_Click(object sender, EventArgs e) {
         
        }

        private void btnStore_Click(object sender, EventArgs e) {
            StoreTable();
        }

        private void LoadTable() {
            try {
                using (OdbcConnection connection = new OdbcConnection(connectionString)) {
                    connection.Open();

                    string query = "SELECT * FROM Appointments";
                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection);

                    dataSet1.Clear();
                    adapter.Fill(dataSet1, "Appointments");

                    DataView dv = dataSet1.Tables["Appointments"].DefaultView;
                    dataGridAppointments.DataSource = dv;

                    MessageBox.Show("Daten erfolgreich geladen.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Fehler beim Laden der Daten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StoreTable() {
            try {
                using (OdbcConnection connection = new OdbcConnection(connectionString)) {
                    connection.Open();

                    string query = "SELECT * FROM Appointments";
                    OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection);

                    OdbcCommandBuilder builder = new OdbcCommandBuilder(adapter);
                    adapter.Update(dataSet1, "Appointments");

                    MessageBox.Show("Daten erfolgreich gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Fehler beim Speichern der Daten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dateTimePicker_ValueChanged(object sender, EventArgs e) {
            if (dataSet1.Tables.Contains("Appointments")) {
                string dateDB = dateTimePicker.Value.ToString("MM.dd.yyyy");
                string filter = $"Start > #{dateDB} 00:00:00# and Start < #{dateDB} 23:59:59#";
                dataSet1.Tables["Appointments"].DefaultView.RowFilter = filter;
            }
        }
    }

}

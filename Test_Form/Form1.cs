using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            int i;
            try {
                i = Convert.ToInt32(textBox1.Text);
                if ((i % 2) == 0) {
                    label1.Text = "Gerade";
                } else {
                    label1.Text = "Ungerade";
                }
            } catch (Exception ex) {
                label1.Text = "Fehler: " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.button1.BackColor = Color.Lavender;
            //MessageBox.Show("Gerade number", "AppInfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (progressBar1.Value == 20) {
                progressBar1.Value = 1;
            } else {
                progressBar1.Value += 1;
            }
        }
    }
}

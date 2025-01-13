namespace lab8 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axSystemMonitor1 = new AxSystemMonitor.AxSystemMonitor();
            ((System.ComponentModel.ISupportInitialize)(this.axSystemMonitor1)).BeginInit();
            this.SuspendLayout();
            // 
            // axSystemMonitor1
            // 
            this.axSystemMonitor1.Enabled = true;
            this.axSystemMonitor1.Location = new System.Drawing.Point(12, 154);
            this.axSystemMonitor1.Name = "axSystemMonitor1";
            this.axSystemMonitor1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSystemMonitor1.OcxState")));
            this.axSystemMonitor1.Size = new System.Drawing.Size(1139, 574);
            this.axSystemMonitor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 729);
            this.Controls.Add(this.axSystemMonitor1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axSystemMonitor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxSystemMonitor.AxSystemMonitor axSystemMonitor1;
    }
}


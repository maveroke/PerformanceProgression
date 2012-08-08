namespace Prototype
{
    partial class CreateNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonM = new System.Windows.Forms.RadioButton();
            this.radioButtonF = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(149, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Athlete Name";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "";
            this.dateTimePicker.Location = new System.Drawing.Point(89, 35);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(149, 20);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.Value = new System.DateTime(2011, 12, 13, 16, 24, 16, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "DoB";
            // 
            // radioButtonM
            // 
            this.radioButtonM.AutoSize = true;
            this.radioButtonM.Checked = true;
            this.radioButtonM.Location = new System.Drawing.Point(89, 61);
            this.radioButtonM.Name = "radioButtonM";
            this.radioButtonM.Size = new System.Drawing.Size(48, 17);
            this.radioButtonM.TabIndex = 4;
            this.radioButtonM.TabStop = true;
            this.radioButtonM.Text = "Male";
            this.radioButtonM.UseVisualStyleBackColor = true;
            this.radioButtonM.CheckedChanged += new System.EventHandler(this.radioButtonM_CheckedChanged);
            // 
            // radioButtonF
            // 
            this.radioButtonF.AutoSize = true;
            this.radioButtonF.Location = new System.Drawing.Point(143, 61);
            this.radioButtonF.Name = "radioButtonF";
            this.radioButtonF.Size = new System.Drawing.Size(59, 17);
            this.radioButtonF.TabIndex = 5;
            this.radioButtonF.Text = "Female";
            this.radioButtonF.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sex";
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Items.AddRange(new object[] {
            "100m",
            "110m Hurdles",
            "200m",
            "400m",
            "400m Hurdles",
            "800m",
            "1500m",
            "3000m Steeple",
            "5000m",
            "10000m",
            "Discus Throw",
            "Hammer Throw",
            "High Jump",
            "Javelin Throw",
            "Long Jump",
            "Pole Vault",
            "Shot Put",
            "Triple Jump",
            "Decathlon"});
            this.comboBoxEvent.Location = new System.Drawing.Point(89, 85);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(149, 21);
            this.comboBoxEvent.TabIndex = 7;
            this.comboBoxEvent.Text = "100m";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Event";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxEvent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonF);
            this.Controls.Add(this.radioButtonM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonM;
        private System.Windows.Forms.RadioButton radioButtonF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}
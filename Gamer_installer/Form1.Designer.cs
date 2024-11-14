namespace Gamer_installer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            listBoxSetups = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            progressBarInstallation = new ProgressBar();
            textBoxInstallLog = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans Unicode", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(38, 26);
            label1.Name = "label1";
            label1.Size = new Size(116, 35);
            label1.TabIndex = 0;
            label1.Text = "GaMeR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Yi Baiti", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(151, 32);
            label2.Name = "label2";
            label2.Size = new Size(98, 29);
            label2.TabIndex = 1;
            label2.Text = "Installer";
            // 
            // listBoxSetups
            // 
            listBoxSetups.BackColor = Color.FromArgb(64, 64, 64);
            listBoxSetups.BorderStyle = BorderStyle.None;
            listBoxSetups.Font = new Font("Microsoft PhagsPa", 12F, FontStyle.Bold, GraphicsUnit.Point);
            listBoxSetups.ForeColor = SystemColors.ControlLightLight;
            listBoxSetups.Location = new Point(57, 103);
            listBoxSetups.Margin = new Padding(10);
            listBoxSetups.Name = "listBoxSetups";
            listBoxSetups.Size = new Size(777, 276);
            listBoxSetups.TabIndex = 2;
            listBoxSetups.SelectedIndexChanged += listBoxSetups_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(392, 421);
            button1.Name = "button1";
            button1.Size = new Size(113, 34);
            button1.TabIndex = 3;
            button1.Text = "Install";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(532, 421);
            button2.Name = "button2";
            button2.Size = new Size(43, 34);
            button2.TabIndex = 4;
            button2.Text = "R";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBarInstallation
            // 
            progressBarInstallation.Location = new Point(57, 482);
            progressBarInstallation.Name = "progressBarInstallation";
            progressBarInstallation.Size = new Size(783, 23);
            progressBarInstallation.TabIndex = 5;
            // 
            // textBoxInstallLog
            // 
            textBoxInstallLog.Location = new Point(57, 103);
            textBoxInstallLog.Name = "textBoxInstallLog";
            textBoxInstallLog.Size = new Size(777, 276);
            textBoxInstallLog.TabIndex = 6;
            textBoxInstallLog.Text = "";
            textBoxInstallLog.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(900, 577);
            Controls.Add(textBoxInstallLog);
            Controls.Add(progressBarInstallation);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBoxSetups);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckedListBox listBoxSetups;
        private Button button1;
        private Button button2;
        private ProgressBar progressBarInstallation;
        private RichTextBox textBoxInstallLog;
    }
}

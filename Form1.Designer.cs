﻿namespace _3951_Lab6_Bryson_Polina
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            buttonPolina1 = new global::Program.ButtonPolina();
            userControlrgbSelectorPolina1 = new UserControlRGBSelectorPolina();
            SuspendLayout();
            // 
            // buttonPolina1
            // 
            buttonPolina1.Location = new Point(12, 12);
            buttonPolina1.Name = "buttonPolina1";
            buttonPolina1.PrimaryColor = Color.LawnGreen;
            buttonPolina1.PrimaryTransparency = 200;
            buttonPolina1.SecondaryColor = Color.Orange;
            buttonPolina1.SecondaryTransparency = 255;
            buttonPolina1.Size = new Size(132, 23);
            buttonPolina1.TabIndex = 0;
            buttonPolina1.Text = "my beautiful text";
            buttonPolina1.UseVisualStyleBackColor = true;
            // 
            // userControlrgbSelectorPolina1
            // 
            userControlrgbSelectorPolina1.Location = new Point(168, 12);
            userControlrgbSelectorPolina1.Name = "userControlrgbSelectorPolina1";
            userControlrgbSelectorPolina1.Size = new Size(300, 170);
            userControlrgbSelectorPolina1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(userControlrgbSelectorPolina1);
            Controls.Add(buttonPolina1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private global::Program.ButtonPolina buttonPolina1;
        private UserControlRGBSelectorPolina userControlrgbSelectorPolina1;
    }
}

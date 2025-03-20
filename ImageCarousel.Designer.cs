namespace _3951_Lab6_Bryson_Polina
{
    partial class ImageCarousel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxMain = new PictureBox();
            buttonPrev = new Button();
            buttonAdd = new Button();
            buttonNext = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Location = new Point(3, 3);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(351, 273);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            // 
            // buttonPrev
            // 
            buttonPrev.Location = new Point(3, 282);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(115, 23);
            buttonPrev.TabIndex = 1;
            buttonPrev.Text = "Previous";
            buttonPrev.UseVisualStyleBackColor = true;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(128, 325);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(95, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add Images";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAddImages_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(239, 282);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(115, 23);
            buttonNext.TabIndex = 4;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // ImageCarousel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonNext);
            Controls.Add(buttonAdd);
            Controls.Add(buttonPrev);
            Controls.Add(pictureBoxMain);
            Name = "ImageCarousel";
            Size = new Size(357, 351);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxMain;
        private Button buttonPrev;
        private Button buttonAdd;
        private Button buttonNext;
    }
}

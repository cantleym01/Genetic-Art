namespace Genetic_Art
{
    partial class genArtForm
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
            this.picLoadButton = new System.Windows.Forms.Button();
            this.picLoadTextBox = new System.Windows.Forms.TextBox();
            this.genArtPanel = new System.Windows.Forms.Panel();
            this.picLabel = new System.Windows.Forms.Label();
            this.genArtLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.genArtButton = new System.Windows.Forms.Button();
            this.genLabel = new System.Windows.Forms.Label();
            this.genNumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoadButton
            // 
            this.picLoadButton.Location = new System.Drawing.Point(531, 9);
            this.picLoadButton.Name = "picLoadButton";
            this.picLoadButton.Size = new System.Drawing.Size(75, 23);
            this.picLoadButton.TabIndex = 0;
            this.picLoadButton.Text = "Load Image";
            this.picLoadButton.UseVisualStyleBackColor = true;
            this.picLoadButton.Click += new System.EventHandler(this.PicLoadClick);
            // 
            // picLoadTextBox
            // 
            this.picLoadTextBox.Location = new System.Drawing.Point(10, 12);
            this.picLoadTextBox.Name = "picLoadTextBox";
            this.picLoadTextBox.Size = new System.Drawing.Size(515, 20);
            this.picLoadTextBox.TabIndex = 2;
            // 
            // genArtPanel
            // 
            this.genArtPanel.Location = new System.Drawing.Point(531, 39);
            this.genArtPanel.Name = "genArtPanel";
            this.genArtPanel.Size = new System.Drawing.Size(512, 512);
            this.genArtPanel.TabIndex = 6;
            // 
            // picLabel
            // 
            this.picLabel.AutoSize = true;
            this.picLabel.Location = new System.Drawing.Point(237, 554);
            this.picLabel.Name = "picLabel";
            this.picLabel.Size = new System.Drawing.Size(74, 13);
            this.picLabel.TabIndex = 7;
            this.picLabel.Text = "Original Image";
            // 
            // genArtLabel
            // 
            this.genArtLabel.AutoSize = true;
            this.genArtLabel.Location = new System.Drawing.Point(762, 554);
            this.genArtLabel.Name = "genArtLabel";
            this.genArtLabel.Size = new System.Drawing.Size(60, 13);
            this.genArtLabel.TabIndex = 8;
            this.genArtLabel.Text = "Genetic Art";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(613, 12);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // genArtButton
            // 
            this.genArtButton.Location = new System.Drawing.Point(612, 9);
            this.genArtButton.Name = "genArtButton";
            this.genArtButton.Size = new System.Drawing.Size(75, 23);
            this.genArtButton.TabIndex = 11;
            this.genArtButton.Text = "Generate";
            this.genArtButton.UseVisualStyleBackColor = true;
            this.genArtButton.Click += new System.EventHandler(this.GenArtClick);
            // 
            // genLabel
            // 
            this.genLabel.AutoSize = true;
            this.genLabel.Location = new System.Drawing.Point(693, 14);
            this.genLabel.Name = "genLabel";
            this.genLabel.Size = new System.Drawing.Size(62, 13);
            this.genLabel.TabIndex = 12;
            this.genLabel.Text = "Generation:";
            // 
            // genNumLabel
            // 
            this.genNumLabel.AutoSize = true;
            this.genNumLabel.Location = new System.Drawing.Point(761, 14);
            this.genNumLabel.Name = "genNumLabel";
            this.genNumLabel.Size = new System.Drawing.Size(13, 13);
            this.genNumLabel.TabIndex = 13;
            this.genNumLabel.Text = "0";
            // 
            // genArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 574);
            this.Controls.Add(this.genNumLabel);
            this.Controls.Add(this.genLabel);
            this.Controls.Add(this.genArtButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.genArtLabel);
            this.Controls.Add(this.picLabel);
            this.Controls.Add(this.genArtPanel);
            this.Controls.Add(this.picLoadTextBox);
            this.Controls.Add(this.picLoadButton);
            this.Name = "genArtForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button picLoadButton;
        private System.Windows.Forms.TextBox picLoadTextBox;
        private System.Windows.Forms.Panel genArtPanel;
        private System.Windows.Forms.Label picLabel;
        private System.Windows.Forms.Label genArtLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button genArtButton;
        private System.Windows.Forms.Label genLabel;
        private System.Windows.Forms.Label genNumLabel;
    }
}


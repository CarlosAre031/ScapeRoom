namespace ScapeRoom
{
    partial class Historia4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historia4));
            this.button1 = new System.Windows.Forms.Button();
            this.Parte1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Parte1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.CausesValidation = false;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(506, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 76);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Parte1
            // 
            this.Parte1.BackColor = System.Drawing.Color.Transparent;
            this.Parte1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Parte1.Image = ((System.Drawing.Image)(resources.GetObject("Parte1.Image")));
            this.Parte1.Location = new System.Drawing.Point(-2, 34);
            this.Parte1.Name = "Parte1";
            this.Parte1.Size = new System.Drawing.Size(684, 443);
            this.Parte1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Parte1.TabIndex = 17;
            this.Parte1.TabStop = false;
            this.Parte1.Click += new System.EventHandler(this.Parte1_Click);
            // 
            // Historia4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(680, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Parte1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Historia4";
            this.Text = "Escape De Blancas";
            ((System.ComponentModel.ISupportInitialize)(this.Parte1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Parte1;
    }
}
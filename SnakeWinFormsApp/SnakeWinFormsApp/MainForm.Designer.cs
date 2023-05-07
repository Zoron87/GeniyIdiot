namespace SnakeWinFormsApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.snakePictureBox = new System.Windows.Forms.PictureBox();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.snakePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // snakePictureBox
            // 
            this.snakePictureBox.Image = global::SnakeWinFormsApp.Properties.Resources.snake_small;
            this.snakePictureBox.Location = new System.Drawing.Point(12, 12);
            this.snakePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.snakePictureBox.Name = "snakePictureBox";
            this.snakePictureBox.Size = new System.Drawing.Size(35, 35);
            this.snakePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.snakePictureBox.TabIndex = 0;
            this.snakePictureBox.TabStop = false;
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 644);
            this.Controls.Add(this.snakePictureBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.snakePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox snakePictureBox;
        private System.Windows.Forms.Timer mainTimer;
    }
}
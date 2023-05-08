namespace Task72WinFormsApp
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
            this.startGameButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.countBallsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(654, 12);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(134, 35);
            this.startGameButton.TabIndex = 0;
            this.startGameButton.Text = "Создать";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(654, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пойманных шаров";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // countBallsLabel
            // 
            this.countBallsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.countBallsLabel.Location = new System.Drawing.Point(654, 107);
            this.countBallsLabel.Name = "countBallsLabel";
            this.countBallsLabel.Size = new System.Drawing.Size(134, 23);
            this.countBallsLabel.TabIndex = 2;
            this.countBallsLabel.Text = "0";
            this.countBallsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countBallsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startGameButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private Button startGameButton;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label countBallsLabel;
    }
}
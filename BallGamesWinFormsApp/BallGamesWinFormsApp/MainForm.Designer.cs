namespace BallGamesWinFormsApp
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.createBallsButton = new System.Windows.Forms.Button();
            this.stopMoveButton = new System.Windows.Forms.Button();
            this.catchBallsLabel = new System.Windows.Forms.Label();
            this.catchBallsNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createBallsButton
            // 
            this.createBallsButton.Location = new System.Drawing.Point(532, 12);
            this.createBallsButton.Name = "createBallsButton";
            this.createBallsButton.Size = new System.Drawing.Size(125, 39);
            this.createBallsButton.TabIndex = 2;
            this.createBallsButton.Text = "Создать";
            this.createBallsButton.UseVisualStyleBackColor = true;
            this.createBallsButton.Click += new System.EventHandler(this.createBallsButton_Click);
            // 
            // stopMoveButton
            // 
            this.stopMoveButton.Location = new System.Drawing.Point(663, 12);
            this.stopMoveButton.Name = "stopMoveButton";
            this.stopMoveButton.Size = new System.Drawing.Size(125, 39);
            this.stopMoveButton.TabIndex = 3;
            this.stopMoveButton.Text = "Остановить";
            this.stopMoveButton.UseVisualStyleBackColor = true;
            this.stopMoveButton.Click += new System.EventHandler(this.stopMoveButton_Click);
            // 
            // catchBallsLabel
            // 
            this.catchBallsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.catchBallsLabel.Location = new System.Drawing.Point(532, 54);
            this.catchBallsLabel.Name = "catchBallsLabel";
            this.catchBallsLabel.Size = new System.Drawing.Size(256, 51);
            this.catchBallsLabel.TabIndex = 4;
            this.catchBallsLabel.Text = "Количество \'пойманных\' шариков";
            this.catchBallsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // catchBallsNumberLabel
            // 
            this.catchBallsNumberLabel.AutoSize = true;
            this.catchBallsNumberLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.catchBallsNumberLabel.Location = new System.Drawing.Point(644, 117);
            this.catchBallsNumberLabel.Name = "catchBallsNumberLabel";
            this.catchBallsNumberLabel.Size = new System.Drawing.Size(28, 32);
            this.catchBallsNumberLabel.TabIndex = 5;
            this.catchBallsNumberLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.catchBallsNumberLabel);
            this.Controls.Add(this.catchBallsLabel);
            this.Controls.Add(this.stopMoveButton);
            this.Controls.Add(this.createBallsButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private Button createBallsButton;
        private Button stopMoveButton;
        private Label catchBallsLabel;
        private Label catchBallsNumberLabel;
    }
}
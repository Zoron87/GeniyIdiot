namespace FruitNinjaWinFormsApp
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
            this.startGameButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startGameButton.Location = new System.Drawing.Point(860, 570);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(88, 61);
            this.startGameButton.TabIndex = 0;
            this.startGameButton.Text = "Начать игру";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.Location = new System.Drawing.Point(860, 532);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(23, 25);
            this.scoreLabel.TabIndex = 14;
            this.scoreLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(860, 499);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Счет:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 643);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.startGameButton);
            this.Name = "MainForm";
            this.Text = "FruitNinja";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startGameButton;
        private Label scoreLabel;
        private Label label4;
    }
}
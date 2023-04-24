namespace BillyardBallsWinFormsApp
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
            this.leftGreenLabel = new System.Windows.Forms.Label();
            this.topGreenLabel = new System.Windows.Forms.Label();
            this.downGreenLabel = new System.Windows.Forms.Label();
            this.rightBlueLabel = new System.Windows.Forms.Label();
            this.rightGreenLabel = new System.Windows.Forms.Label();
            this.leftBlueLabel = new System.Windows.Forms.Label();
            this.topBlueLabel = new System.Windows.Forms.Label();
            this.downBlueLabel = new System.Windows.Forms.Label();
            this.billyardTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftGreenLabel
            // 
            this.leftGreenLabel.AutoSize = true;
            this.leftGreenLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leftGreenLabel.ForeColor = System.Drawing.Color.Green;
            this.leftGreenLabel.Location = new System.Drawing.Point(12, 182);
            this.leftGreenLabel.Name = "leftGreenLabel";
            this.leftGreenLabel.Size = new System.Drawing.Size(19, 21);
            this.leftGreenLabel.TabIndex = 0;
            this.leftGreenLabel.Text = "0";
            // 
            // topGreenLabel
            // 
            this.topGreenLabel.AutoSize = true;
            this.topGreenLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.topGreenLabel.ForeColor = System.Drawing.Color.Green;
            this.topGreenLabel.Location = new System.Drawing.Point(369, 9);
            this.topGreenLabel.Name = "topGreenLabel";
            this.topGreenLabel.Size = new System.Drawing.Size(19, 21);
            this.topGreenLabel.TabIndex = 1;
            this.topGreenLabel.Text = "0";
            // 
            // downGreenLabel
            // 
            this.downGreenLabel.AutoSize = true;
            this.downGreenLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.downGreenLabel.ForeColor = System.Drawing.Color.Green;
            this.downGreenLabel.Location = new System.Drawing.Point(369, 420);
            this.downGreenLabel.Name = "downGreenLabel";
            this.downGreenLabel.Size = new System.Drawing.Size(19, 21);
            this.downGreenLabel.TabIndex = 2;
            this.downGreenLabel.Text = "0";
            this.downGreenLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.downLabel_Paint);
            // 
            // rightBlueLabel
            // 
            this.rightBlueLabel.AutoSize = true;
            this.rightBlueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rightBlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.rightBlueLabel.Location = new System.Drawing.Point(760, 220);
            this.rightBlueLabel.Name = "rightBlueLabel";
            this.rightBlueLabel.Size = new System.Drawing.Size(19, 21);
            this.rightBlueLabel.TabIndex = 3;
            this.rightBlueLabel.Text = "0";
            // 
            // rightGreenLabel
            // 
            this.rightGreenLabel.AutoSize = true;
            this.rightGreenLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rightGreenLabel.ForeColor = System.Drawing.Color.Green;
            this.rightGreenLabel.Location = new System.Drawing.Point(760, 182);
            this.rightGreenLabel.Name = "rightGreenLabel";
            this.rightGreenLabel.Size = new System.Drawing.Size(19, 21);
            this.rightGreenLabel.TabIndex = 4;
            this.rightGreenLabel.Text = "0";
            // 
            // leftBlueLabel
            // 
            this.leftBlueLabel.AutoSize = true;
            this.leftBlueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leftBlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.leftBlueLabel.Location = new System.Drawing.Point(12, 220);
            this.leftBlueLabel.Name = "leftBlueLabel";
            this.leftBlueLabel.Size = new System.Drawing.Size(19, 21);
            this.leftBlueLabel.TabIndex = 5;
            this.leftBlueLabel.Text = "0";
            // 
            // topBlueLabel
            // 
            this.topBlueLabel.AutoSize = true;
            this.topBlueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.topBlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.topBlueLabel.Location = new System.Drawing.Point(411, 9);
            this.topBlueLabel.Name = "topBlueLabel";
            this.topBlueLabel.Size = new System.Drawing.Size(19, 21);
            this.topBlueLabel.TabIndex = 6;
            this.topBlueLabel.Text = "0";
            // 
            // downBlueLabel
            // 
            this.downBlueLabel.AutoSize = true;
            this.downBlueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.downBlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.downBlueLabel.Location = new System.Drawing.Point(411, 420);
            this.downBlueLabel.Name = "downBlueLabel";
            this.downBlueLabel.Size = new System.Drawing.Size(19, 21);
            this.downBlueLabel.TabIndex = 7;
            this.downBlueLabel.Text = "0";
            // 
            // billyardTimer
            // 
            this.billyardTimer.Interval = 1000;
            this.billyardTimer.Tick += new System.EventHandler(this.billyardTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.downBlueLabel);
            this.Controls.Add(this.topBlueLabel);
            this.Controls.Add(this.leftBlueLabel);
            this.Controls.Add(this.rightGreenLabel);
            this.Controls.Add(this.rightBlueLabel);
            this.Controls.Add(this.downGreenLabel);
            this.Controls.Add(this.topGreenLabel);
            this.Controls.Add(this.leftGreenLabel);
            this.Name = "MainForm";
            this.Text = "BillyardBallsForm";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label leftGreenLabel;
        private Label topGreenLabel;
        private Label downGreenLabel;
        private Label rightBlueLabel;
        private Label rightGreenLabel;
        private Label leftBlueLabel;
        private Label topBlueLabel;
        private Label downBlueLabel;
        private System.Windows.Forms.Timer billyardTimer;
        private Button button1;
    }
}
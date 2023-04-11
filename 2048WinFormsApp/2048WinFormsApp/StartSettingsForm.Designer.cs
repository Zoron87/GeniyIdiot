namespace _2048WinFormsApp
{
    partial class StartSettingsForm
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
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(21, 52);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(237, 23);
            this.userNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите ваше имя";
            // 
            // userNameButton
            // 
            this.userNameButton.Location = new System.Drawing.Point(22, 91);
            this.userNameButton.Name = "userNameButton";
            this.userNameButton.Size = new System.Drawing.Size(235, 36);
            this.userNameButton.TabIndex = 2;
            this.userNameButton.Text = "Сохранить";
            this.userNameButton.UseVisualStyleBackColor = true;
            this.userNameButton.Click += new System.EventHandler(this.userNameButton_Click);
            // 
            // UserNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 141);
            this.Controls.Add(this.userNameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userNameTextBox);
            this.Name = "UserNameForm";
            this.Text = "Введите ваше имя";
            this.Load += new System.EventHandler(this.UserNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox userNameTextBox;
        private Label label1;
        private Button userNameButton;
    }
}
namespace GeniyIdiotWinFormsApp
{
    partial class InputUsername
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.SaveUsernameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ваше имя:";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(38, 77);
            this.UserNameTextBox.Multiline = true;
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(183, 38);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // SaveUsernameButton
            // 
            this.SaveUsernameButton.Location = new System.Drawing.Point(38, 134);
            this.SaveUsernameButton.Name = "SaveUsernameButton";
            this.SaveUsernameButton.Size = new System.Drawing.Size(183, 31);
            this.SaveUsernameButton.TabIndex = 2;
            this.SaveUsernameButton.Text = "Сохранить";
            this.SaveUsernameButton.UseVisualStyleBackColor = true;
            this.SaveUsernameButton.Click += new System.EventHandler(this.SaveUsernameButton_Click);
            // 
            // InputUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 177);
            this.Controls.Add(this.SaveUsernameButton);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "InputUsername";
            this.Text = "InputUsername";
            this.Load += new System.EventHandler(this.InputUsername_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox UserNameTextBox;
        private Button SaveUsernameButton;
    }
}
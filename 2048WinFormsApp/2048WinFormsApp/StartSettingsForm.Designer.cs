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
            this.components = new System.ComponentModel.Container();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameButton = new System.Windows.Forms.Button();
            this.mapSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(21, 52);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(237, 23);
            this.userNameTextBox.TabIndex = 0;
            this.userNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.userNameTextBox_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите ваше имя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userNameButton
            // 
            this.userNameButton.Location = new System.Drawing.Point(21, 213);
            this.userNameButton.Name = "userNameButton";
            this.userNameButton.Size = new System.Drawing.Size(235, 36);
            this.userNameButton.TabIndex = 2;
            this.userNameButton.Text = "Начать игру!";
            this.userNameButton.UseVisualStyleBackColor = true;
            this.userNameButton.Click += new System.EventHandler(this.userNameButton_Click);
            // 
            // mapSizeComboBox
            // 
            this.mapSizeComboBox.FormattingEnabled = true;
            this.mapSizeComboBox.Items.AddRange(new object[] {
            "4x4",
            "5x5",
            "6x6"});
            this.mapSizeComboBox.Location = new System.Drawing.Point(24, 157);
            this.mapSizeComboBox.Name = "mapSizeComboBox";
            this.mapSizeComboBox.Size = new System.Drawing.Size(232, 23);
            this.mapSizeComboBox.TabIndex = 3;
            this.mapSizeComboBox.Text = "4x4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выберите размер поля";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // StartSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 271);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mapSizeComboBox);
            this.Controls.Add(this.userNameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userNameTextBox);
            this.Name = "StartSettingsForm";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.UserNameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox userNameTextBox;
        private Label label1;
        private Button userNameButton;
        private ComboBox mapSizeComboBox;
        private Label label2;
        private ErrorProvider errorProvider;
    }
}
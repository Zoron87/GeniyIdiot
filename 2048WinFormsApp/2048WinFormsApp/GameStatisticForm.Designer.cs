namespace _2048WinFormsApp
{
    partial class GameStatisticForm
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
            this.userResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userResultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userResultsDataGridView
            // 
            this.userResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userResultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userName,
            this.userScore});
            this.userResultsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.userResultsDataGridView.Name = "userResultsDataGridView";
            this.userResultsDataGridView.RowTemplate.Height = 25;
            this.userResultsDataGridView.Size = new System.Drawing.Size(240, 426);
            this.userResultsDataGridView.TabIndex = 0;
            // 
            // userName
            // 
            this.userName.HeaderText = "Имя";
            this.userName.Name = "userName";
            // 
            // userScore
            // 
            this.userScore.HeaderText = "Результат";
            this.userScore.Name = "userScore";
            // 
            // GameStatisticForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 450);
            this.Controls.Add(this.userResultsDataGridView);
            this.Name = "GameStatisticForm1";
            this.Text = "GameStatisticForm1";
            this.Load += new System.EventHandler(this.GameStatisticForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userResultsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView userResultsDataGridView;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn userScore;
    }
}
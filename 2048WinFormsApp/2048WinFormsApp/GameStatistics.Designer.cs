namespace _2048WinFormsApp
{
    partial class GameStatistics
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
            this.userGameStatisticDataGridView = new System.Windows.Forms.DataGridView();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGameStatistic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userGameStatisticDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userGameStatisticDataGridView
            // 
            this.userGameStatisticDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGameStatisticDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userName,
            this.userGameStatistic});
            this.userGameStatisticDataGridView.Location = new System.Drawing.Point(12, 12);
            this.userGameStatisticDataGridView.Name = "userGameStatisticDataGridView";
            this.userGameStatisticDataGridView.RowTemplate.Height = 25;
            this.userGameStatisticDataGridView.Size = new System.Drawing.Size(246, 426);
            this.userGameStatisticDataGridView.TabIndex = 0;
            // 
            // userName
            // 
            this.userName.HeaderText = "Имя";
            this.userName.Name = "userName";
            // 
            // userGameStatistic
            // 
            this.userGameStatistic.HeaderText = "Результат";
            this.userGameStatistic.Name = "userGameStatistic";
            // 
            // GameStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 450);
            this.Controls.Add(this.userGameStatisticDataGridView);
            this.Name = "GameStatistics";
            this.Text = "GameStatistics";
            this.Load += new System.EventHandler(this.GameStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userGameStatisticDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView userGameStatisticDataGridView;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn userGameStatistic;
    }
}
namespace GeniyIdiotWinFormsApp
{
    partial class DeleteQuestion
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
            this.questionGridView = new System.Windows.Forms.DataGridView();
            this.Question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // questionGridView
            // 
            this.questionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.questionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Question,
            this.Answer});
            this.questionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionGridView.Location = new System.Drawing.Point(0, 0);
            this.questionGridView.MultiSelect = false;
            this.questionGridView.Name = "questionGridView";
            this.questionGridView.ReadOnly = true;
            this.questionGridView.RowTemplate.Height = 25;
            this.questionGridView.Size = new System.Drawing.Size(426, 450);
            this.questionGridView.TabIndex = 0;
            // 
            // Question
            // 
            this.Question.HeaderText = "Вопрос";
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            // 
            // Answer
            // 
            this.Answer.HeaderText = "Ответ";
            this.Answer.Name = "Answer";
            this.Answer.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(0, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(426, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Удалить выделенный вопрос";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.questionGridView);
            this.Name = "DeleteQuestion";
            this.Text = "DeleteQuestion";
            this.Load += new System.EventHandler(this.DeleteQuestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.questionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView questionGridView;
        private DataGridViewTextBoxColumn Question;
        private DataGridViewTextBoxColumn Answer;
        private Button button1;
    }
}
namespace GeniyIdiotWinForm
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
            this.nextButton = new System.Windows.Forms.Button();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.questionsTextLabel = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограмеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вопросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСуществующийВопросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.userAnswerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAnswerNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.nextButton.Location = new System.Drawing.Point(54, 290);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(278, 66);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.questionNumberLabel.Location = new System.Drawing.Point(160, 24);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(93, 21);
            this.questionNumberLabel.TabIndex = 1;
            this.questionNumberLabel.Text = "Вопрос №1";
            this.questionNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // questionsTextLabel
            // 
            this.questionsTextLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.questionsTextLabel.Location = new System.Drawing.Point(91, 101);
            this.questionsTextLabel.Name = "questionsTextLabel";
            this.questionsTextLabel.Size = new System.Drawing.Size(241, 72);
            this.questionsTextLabel.TabIndex = 2;
            this.questionsTextLabel.Text = "Текст вопроса";
            this.questionsTextLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.вопросыToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(391, 24);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.результатыToolStripMenuItem,
            this.оПрограмеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // результатыToolStripMenuItem
            // 
            this.результатыToolStripMenuItem.Name = "результатыToolStripMenuItem";
            this.результатыToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.результатыToolStripMenuItem.Text = "Статистика игр";
            this.результатыToolStripMenuItem.Click += new System.EventHandler(this.результатыToolStripMenuItem_Click);
            // 
            // оПрограмеToolStripMenuItem
            // 
            this.оПрограмеToolStripMenuItem.Name = "оПрограмеToolStripMenuItem";
            this.оПрограмеToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.оПрограмеToolStripMenuItem.Text = "О программе";
            this.оПрограмеToolStripMenuItem.Click += new System.EventHandler(this.оПрограмеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // вопросыToolStripMenuItem
            // 
            this.вопросыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.удалитьСуществующийВопросToolStripMenuItem});
            this.вопросыToolStripMenuItem.Name = "вопросыToolStripMenuItem";
            this.вопросыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.вопросыToolStripMenuItem.Text = "Вопросы";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(251, 22);
            this.toolStripMenuItem2.Text = "Добавить новый вопрос";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // удалитьСуществующийВопросToolStripMenuItem
            // 
            this.удалитьСуществующийВопросToolStripMenuItem.Name = "удалитьСуществующийВопросToolStripMenuItem";
            this.удалитьСуществующийВопросToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.удалитьСуществующийВопросToolStripMenuItem.Text = "Удалить существующий вопрос";
            this.удалитьСуществующийВопросToolStripMenuItem.Click += new System.EventHandler(this.удалитьСуществующийВопросToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GeniyIdiotWinFormsApp.Properties.Resources._1737369_answer_circle_okay_tick_icon;
            this.pictureBox1.Location = new System.Drawing.Point(54, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GeniyIdiotWinFormsApp.Properties.Resources._172477_question_help_icon;
            this.pictureBox2.Location = new System.Drawing.Point(54, 107);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GeniyIdiotWinFormsApp.Properties.Resources._4829872_arrow_next_right_icon;
            this.pictureBox3.Location = new System.Drawing.Point(251, 314);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // userAnswerNumericUpDown
            // 
            this.userAnswerNumericUpDown.Location = new System.Drawing.Point(91, 198);
            this.userAnswerNumericUpDown.Name = "userAnswerNumericUpDown";
            this.userAnswerNumericUpDown.Size = new System.Drawing.Size(191, 23);
            this.userAnswerNumericUpDown.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 378);
            this.Controls.Add(this.userAnswerNumericUpDown);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.questionsTextLabel);
            this.Controls.Add(this.questionNumberLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAnswerNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionsTextLabel;
        private MenuStrip mainMenu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem результатыToolStripMenuItem;
        private ToolStripMenuItem оПрограмеToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private ToolStripMenuItem вопросыToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem удалитьСуществующийВопросToolStripMenuItem;
        private NumericUpDown userAnswerNumericUpDown;
    }
}
namespace TRRP0
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pathFileText = new System.Windows.Forms.TextBox();
            this.changeFileButton = new System.Windows.Forms.Button();
            this.openFileDb = new System.Windows.Forms.OpenFileDialog();
            this.StartNormalize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите файл ненормализованной базы данных";
            // 
            // pathFileText
            // 
            this.pathFileText.Location = new System.Drawing.Point(12, 29);
            this.pathFileText.Name = "pathFileText";
            this.pathFileText.Size = new System.Drawing.Size(291, 22);
            this.pathFileText.TabIndex = 1;
            // 
            // changeFileButton
            // 
            this.changeFileButton.Location = new System.Drawing.Point(309, 29);
            this.changeFileButton.Name = "changeFileButton";
            this.changeFileButton.Size = new System.Drawing.Size(44, 23);
            this.changeFileButton.TabIndex = 2;
            this.changeFileButton.Text = "...";
            this.changeFileButton.UseVisualStyleBackColor = true;
            this.changeFileButton.Click += new System.EventHandler(this.changeFileButton_Click);
            // 
            // openFileDb
            // 
            this.openFileDb.FileName = "D:\\4 курс\\ТРРП\\Входной\\sales.db";
            // 
            // StartNormalize
            // 
            this.StartNormalize.Location = new System.Drawing.Point(12, 58);
            this.StartNormalize.Name = "StartNormalize";
            this.StartNormalize.Size = new System.Drawing.Size(341, 29);
            this.StartNormalize.TabIndex = 4;
            this.StartNormalize.Text = "Нормализовать";
            this.StartNormalize.UseVisualStyleBackColor = true;
            this.StartNormalize.Click += new System.EventHandler(this.StartNormalize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 96);
            this.Controls.Add(this.StartNormalize);
            this.Controls.Add(this.changeFileButton);
            this.Controls.Add(this.pathFileText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Нормализация БД";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathFileText;
        private System.Windows.Forms.Button changeFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDb;
        private System.Windows.Forms.Button StartNormalize;
    }
}


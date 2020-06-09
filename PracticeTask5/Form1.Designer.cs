namespace PracticeTask5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SizeChoice = new System.Windows.Forms.Label();
            this.InputSize = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ввестиВручнуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ввестиИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeChoice
            // 
            this.SizeChoice.AutoSize = true;
            this.SizeChoice.BackColor = System.Drawing.Color.Transparent;
            this.SizeChoice.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeChoice.Location = new System.Drawing.Point(11, 59);
            this.SizeChoice.Name = "SizeChoice";
            this.SizeChoice.Size = new System.Drawing.Size(416, 33);
            this.SizeChoice.TabIndex = 3;
            this.SizeChoice.Text = "Введите размер квадратной матрицы:";
            this.SizeChoice.Visible = false;
            // 
            // InputSize
            // 
            this.InputSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.InputSize.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputSize.Location = new System.Drawing.Point(433, 55);
            this.InputSize.Name = "InputSize";
            this.InputSize.Size = new System.Drawing.Size(54, 41);
            this.InputSize.TabIndex = 4;
            this.InputSize.Visible = false;
            this.InputSize.TextChanged += new System.EventHandler(this.InputSize_TextChanged);
            this.InputSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputSize_KeyDown);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.BackColor = System.Drawing.Color.Transparent;
            this.InputLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputLabel.Location = new System.Drawing.Point(12, 92);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(232, 33);
            this.InputLabel.TabIndex = 5;
            this.InputLabel.Text = "Заполните матрицу:";
            this.InputLabel.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ввестиВручнуюToolStripMenuItem,
            this.ввестиИзФайлаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(503, 41);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ввестиВручнуюToolStripMenuItem
            // 
            this.ввестиВручнуюToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ввестиВручнуюToolStripMenuItem.Name = "ввестиВручнуюToolStripMenuItem";
            this.ввестиВручнуюToolStripMenuItem.Size = new System.Drawing.Size(250, 37);
            this.ввестиВручнуюToolStripMenuItem.Text = "Ввести вручную       ";
            this.ввестиВручнуюToolStripMenuItem.Click += new System.EventHandler(this.ввестиВручнуюToolStripMenuItem_Click);
            // 
            // ввестиИзФайлаToolStripMenuItem
            // 
            this.ввестиИзФайлаToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ввестиИзФайлаToolStripMenuItem.Name = "ввестиИзФайлаToolStripMenuItem";
            this.ввестиИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(203, 37);
            this.ввестиИзФайлаToolStripMenuItem.Text = "Ввести из файла";
            this.ввестиИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.ввестиИзФайлаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::PracticeTask5.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(503, 568);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.InputSize);
            this.Controls.Add(this.SizeChoice);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1181, 827);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Последовательность b";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SizeChoice;
        private System.Windows.Forms.TextBox InputSize;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ввестиВручнуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ввестиИзФайлаToolStripMenuItem;
    }
}


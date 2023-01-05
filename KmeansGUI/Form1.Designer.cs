
namespace KmeansGUI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.kmeans_num = new System.Windows.Forms.NumericUpDown();
            this.graphicsPage1 = new KmeansGUI.GraphicsPage();
            this.btn_generateDraw = new System.Windows.Forms.Button();
            this.text_Console = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kmeans_num)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 236);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = " Наименование перегона";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Длина (км)";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Время последнего капитального ремонта (дней)";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Электрификация перегона";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Пропускная способность (ваг/год)";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Колличество путей";
            this.Column6.Name = "Column6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(944, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "K=";
            // 
            // kmeans_num
            // 
            this.kmeans_num.Location = new System.Drawing.Point(970, 11);
            this.kmeans_num.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.kmeans_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kmeans_num.Name = "kmeans_num";
            this.kmeans_num.Size = new System.Drawing.Size(120, 20);
            this.kmeans_num.TabIndex = 2;
            this.kmeans_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // graphicsPage1
            // 
            this.graphicsPage1.BackColor = System.Drawing.SystemColors.Control;
            this.graphicsPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphicsPage1.Location = new System.Drawing.Point(558, 277);
            this.graphicsPage1.Name = "graphicsPage1";
            this.graphicsPage1.Size = new System.Drawing.Size(543, 332);
            this.graphicsPage1.TabIndex = 3;
            // 
            // btn_generateDraw
            // 
            this.btn_generateDraw.Location = new System.Drawing.Point(804, 234);
            this.btn_generateDraw.Name = "btn_generateDraw";
            this.btn_generateDraw.Size = new System.Drawing.Size(297, 37);
            this.btn_generateDraw.TabIndex = 4;
            this.btn_generateDraw.Text = "Сгенерировать пузырьковый график KMeans";
            this.btn_generateDraw.UseVisualStyleBackColor = true;
            this.btn_generateDraw.Click += new System.EventHandler(this.btn_generateDraw_Click);
            // 
            // text_Console
            // 
            this.text_Console.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_Console.Location = new System.Drawing.Point(12, 277);
            this.text_Console.Name = "text_Console";
            this.text_Console.Size = new System.Drawing.Size(540, 332);
            this.text_Console.TabIndex = 5;
            this.text_Console.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 621);
            this.Controls.Add(this.text_Console);
            this.Controls.Add(this.btn_generateDraw);
            this.Controls.Add(this.graphicsPage1);
            this.Controls.Add(this.kmeans_num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kmeans_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown kmeans_num;
        private GraphicsPage graphicsPage1;
        private System.Windows.Forms.Button btn_generateDraw;
        private System.Windows.Forms.RichTextBox text_Console;
    }
}


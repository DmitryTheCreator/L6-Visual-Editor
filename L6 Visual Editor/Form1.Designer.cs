namespace L6_Visual_Editor
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
            this.panel = new System.Windows.Forms.Panel();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cmbxShape = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSelection = new System.Windows.Forms.PictureBox();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Silver;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1114, 54);
            this.panel.TabIndex = 0;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.BackColor = System.Drawing.Color.Silver;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblColor.ForeColor = System.Drawing.Color.Black;
            this.lblColor.Location = new System.Drawing.Point(198, 11);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(136, 25);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Цвет фигуры";
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.SandyBrown;
            this.pbColor.Location = new System.Drawing.Point(340, 13);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(30, 30);
            this.pbColor.TabIndex = 5;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.pbColor_Click);
            // 
            // cmbxShape
            // 
            this.cmbxShape.BackColor = System.Drawing.Color.White;
            this.cmbxShape.DropDownWidth = 108;
            this.cmbxShape.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbxShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbxShape.FormattingEnabled = true;
            this.cmbxShape.Items.AddRange(new object[] {
            "Квадрат",
            "Треугольник",
            "Круг"});
            this.cmbxShape.Location = new System.Drawing.Point(12, 8);
            this.cmbxShape.Name = "cmbxShape";
            this.cmbxShape.Size = new System.Drawing.Size(160, 33);
            this.cmbxShape.TabIndex = 8;
            this.cmbxShape.Text = "Фигура";
            this.cmbxShape.SelectedIndexChanged += new System.EventHandler(this.cmbxShape_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(389, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Цвет выделения";
            // 
            // pbSelection
            // 
            this.pbSelection.BackColor = System.Drawing.Color.MediumPurple;
            this.pbSelection.Location = new System.Drawing.Point(562, 13);
            this.pbSelection.Name = "pbSelection";
            this.pbSelection.Size = new System.Drawing.Size(30, 30);
            this.pbSelection.TabIndex = 10;
            this.pbSelection.TabStop = false;
            this.pbSelection.Click += new System.EventHandler(this.pbSelection_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(622, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 35);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(731, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 35);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 596);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pbSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxShape);
            this.Controls.Add(this.pbColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "L6 Visual Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.ComboBox cmbxShape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSelection;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
    }
}


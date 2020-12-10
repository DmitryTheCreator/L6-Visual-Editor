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
            this.pbBorder = new System.Windows.Forms.PictureBox();
            this.lblBorder = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.cmbxShape = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(12, 49);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1090, 535);
            this.panel.TabIndex = 0;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
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
            this.pbColor.BackColor = System.Drawing.Color.Salmon;
            this.pbColor.Location = new System.Drawing.Point(340, 13);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(30, 30);
            this.pbColor.TabIndex = 5;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.pbColor_Click);
            // 
            // pbBorder
            // 
            this.pbBorder.BackColor = System.Drawing.Color.Black;
            this.pbBorder.Location = new System.Drawing.Point(522, 13);
            this.pbBorder.Name = "pbBorder";
            this.pbBorder.Size = new System.Drawing.Size(30, 30);
            this.pbBorder.TabIndex = 7;
            this.pbBorder.TabStop = false;
            this.pbBorder.Click += new System.EventHandler(this.pbBorder_Click);
            // 
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBorder.Location = new System.Drawing.Point(393, 11);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(123, 25);
            this.lblBorder.TabIndex = 6;
            this.lblBorder.Text = "Цвет рамки";
            // 
            // cmbxShape
            // 
            this.cmbxShape.DropDownWidth = 108;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1114, 596);
            this.Controls.Add(this.cmbxShape);
            this.Controls.Add(this.pbBorder);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.pbColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "L6 Visual Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox pbBorder;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.ComboBox cmbxShape;
    }
}


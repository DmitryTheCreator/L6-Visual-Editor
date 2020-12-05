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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel = new System.Windows.Forms.Panel();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.pbBorder = new System.Windows.Forms.PictureBox();
            this.lblBorder = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(245, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(869, 596);
            this.panel.TabIndex = 0;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnSquare
            // 
            this.btnSquare.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSquare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSquare.FlatAppearance.BorderSize = 0;
            this.btnSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSquare.Image = ((System.Drawing.Image)(resources.GetObject("btnSquare.Image")));
            this.btnSquare.Location = new System.Drawing.Point(6, 49);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(66, 66);
            this.btnSquare.TabIndex = 1;
            this.btnSquare.UseVisualStyleBackColor = false;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.BackColor = System.Drawing.Color.PeachPuff;
            this.btnTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTriangle.FlatAppearance.BorderSize = 0;
            this.btnTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.Location = new System.Drawing.Point(87, 49);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(66, 66);
            this.btnTriangle.TabIndex = 2;
            this.btnTriangle.UseVisualStyleBackColor = false;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.BackColor = System.Drawing.Color.PeachPuff;
            this.btnCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCircle.FlatAppearance.BorderSize = 0;
            this.btnCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.Location = new System.Drawing.Point(167, 49);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(66, 66);
            this.btnCircle.TabIndex = 3;
            this.btnCircle.UseVisualStyleBackColor = false;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblColor.Location = new System.Drawing.Point(12, 148);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(167, 32);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Цвет фигур";
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Salmon;
            this.pbColor.Location = new System.Drawing.Point(185, 148);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(36, 32);
            this.pbColor.TabIndex = 5;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.pbColor_Click);
            // 
            // pbBorder
            // 
            this.pbBorder.BackColor = System.Drawing.Color.White;
            this.pbBorder.Location = new System.Drawing.Point(185, 202);
            this.pbBorder.Name = "pbBorder";
            this.pbBorder.Size = new System.Drawing.Size(36, 32);
            this.pbBorder.TabIndex = 7;
            this.pbBorder.TabStop = false;
            this.pbBorder.Click += new System.EventHandler(this.pbBorder_Click);
            // 
            // lblBorder
            // 
            this.lblBorder.AutoSize = true;
            this.lblBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBorder.Location = new System.Drawing.Point(12, 202);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(169, 32);
            this.lblBorder.TabIndex = 6;
            this.lblBorder.Text = "Цвет рамки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1114, 596);
            this.Controls.Add(this.pbBorder);
            this.Controls.Add(this.lblBorder);
            this.Controls.Add(this.pbColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnTriangle);
            this.Controls.Add(this.btnSquare);
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
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox pbBorder;
        private System.Windows.Forms.Label lblBorder;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.PictureBox pbColor;
    }
}


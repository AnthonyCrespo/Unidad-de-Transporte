
namespace Unidad_de_Transporte 
{
    partial class main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.btn_1 = new System.Windows.Forms.Button();
            this.btn_2 = new System.Windows.Forms.Button();
            this.pic_escudo = new System.Windows.Forms.PictureBox();
            this.pic_msp = new System.Windows.Forms.PictureBox();
            this.main_insertBtn = new System.Windows.Forms.Button();
            this.main_informBtn = new System.Windows.Forms.Button();
            this.main_autBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_escudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_msp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_1
            // 
            this.btn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1.Location = new System.Drawing.Point(475, 229);
            this.btn_1.Name = "btn_1";
            this.btn_1.Padding = new System.Windows.Forms.Padding(1);
            this.btn_1.Size = new System.Drawing.Size(309, 49);
            this.btn_1.TabIndex = 4;
            this.btn_1.Text = "Inspección de Ambulancia";
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // btn_2
            // 
            this.btn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_2.Location = new System.Drawing.Point(475, 295);
            this.btn_2.Name = "btn_2";
            this.btn_2.Padding = new System.Windows.Forms.Padding(1);
            this.btn_2.Size = new System.Drawing.Size(309, 49);
            this.btn_2.TabIndex = 5;
            this.btn_2.Text = "Observar reporte";
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // pic_escudo
            // 
            this.pic_escudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_escudo.BackColor = System.Drawing.Color.Transparent;
            this.pic_escudo.Image = ((System.Drawing.Image)(resources.GetObject("pic_escudo.Image")));
            this.pic_escudo.Location = new System.Drawing.Point(789, 9);
            this.pic_escudo.Name = "pic_escudo";
            this.pic_escudo.Size = new System.Drawing.Size(68, 80);
            this.pic_escudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_escudo.TabIndex = 16;
            this.pic_escudo.TabStop = false;
            // 
            // pic_msp
            // 
            this.pic_msp.BackColor = System.Drawing.Color.Transparent;
            this.pic_msp.Image = ((System.Drawing.Image)(resources.GetObject("pic_msp.Image")));
            this.pic_msp.Location = new System.Drawing.Point(23, 9);
            this.pic_msp.Name = "pic_msp";
            this.pic_msp.Size = new System.Drawing.Size(159, 72);
            this.pic_msp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_msp.TabIndex = 15;
            this.pic_msp.TabStop = false;
            // 
            // main_insertBtn
            // 
            this.main_insertBtn.Location = new System.Drawing.Point(35, 36);
            this.main_insertBtn.Margin = new System.Windows.Forms.Padding(4);
            this.main_insertBtn.Name = "main_insertBtn";
            this.main_insertBtn.Size = new System.Drawing.Size(309, 49);
            this.main_insertBtn.TabIndex = 0;
            this.main_insertBtn.Text = "Orden de Movilización";
            this.main_insertBtn.UseVisualStyleBackColor = true;
            this.main_insertBtn.Click += new System.EventHandler(this.main_insertBtn_Click);
            // 
            // main_informBtn
            // 
            this.main_informBtn.Location = new System.Drawing.Point(35, 150);
            this.main_informBtn.Margin = new System.Windows.Forms.Padding(4);
            this.main_informBtn.Name = "main_informBtn";
            this.main_informBtn.Size = new System.Drawing.Size(309, 49);
            this.main_informBtn.TabIndex = 3;
            this.main_informBtn.Text = "Informes y Hojas de Ruta";
            this.main_informBtn.UseVisualStyleBackColor = true;
            this.main_informBtn.Click += new System.EventHandler(this.main_informBtn_Click);
            // 
            // main_autBtn
            // 
            this.main_autBtn.Location = new System.Drawing.Point(35, 93);
            this.main_autBtn.Margin = new System.Windows.Forms.Padding(4);
            this.main_autBtn.Name = "main_autBtn";
            this.main_autBtn.Size = new System.Drawing.Size(309, 49);
            this.main_autBtn.TabIndex = 1;
            this.main_autBtn.Text = "Autorización de Salida";
            this.main_autBtn.UseVisualStyleBackColor = true;
            this.main_autBtn.Click += new System.EventHandler(this.main_autBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "Unidad de Transporte ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(251, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "Hospital San Vicente de Paúl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 31);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ministerio de Salud Pública";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.main_autBtn);
            this.groupBox1.Controls.Add(this.main_informBtn);
            this.groupBox1.Controls.Add(this.main_insertBtn);
            this.groupBox1.Location = new System.Drawing.Point(48, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 226);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.groupBox3.Location = new System.Drawing.Point(451, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 226);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_escudo);
            this.Controls.Add(this.pic_msp);
            this.Controls.Add(this.btn_2);
            this.Controls.Add(this.btn_1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspección Diaria Ambulancia";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_escudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_msp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.PictureBox pic_escudo;
        private System.Windows.Forms.PictureBox pic_msp;
        private System.Windows.Forms.Button main_insertBtn;
        private System.Windows.Forms.Button main_informBtn;
        private System.Windows.Forms.Button main_autBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}


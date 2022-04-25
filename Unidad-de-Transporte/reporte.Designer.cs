
namespace Unidad_de_Transporte 
{
    partial class reporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporte));
            this.Buscador = new System.Windows.Forms.TabPage();
            this.btn_generar_reporte = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.no_reporte = new System.Windows.Forms.NumericUpDown();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.buscar_por = new System.Windows.Forms.ComboBox();
            this.grd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Informe = new System.Windows.Forms.TabControl();
            this.Buscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.no_reporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.Informe.SuspendLayout();
            this.SuspendLayout();
            // 
            // Buscador
            // 
            this.Buscador.Controls.Add(this.btn_generar_reporte);
            this.Buscador.Controls.Add(this.btn_buscar);
            this.Buscador.Controls.Add(this.no_reporte);
            this.Buscador.Controls.Add(this.fecha);
            this.Buscador.Controls.Add(this.buscar_por);
            this.Buscador.Controls.Add(this.grd);
            this.Buscador.Controls.Add(this.label2);
            this.Buscador.Location = new System.Drawing.Point(4, 27);
            this.Buscador.Name = "Buscador";
            this.Buscador.Padding = new System.Windows.Forms.Padding(3);
            this.Buscador.Size = new System.Drawing.Size(1277, 752);
            this.Buscador.TabIndex = 0;
            this.Buscador.Text = "Buscador";
            this.Buscador.UseVisualStyleBackColor = true;
            // 
            // btn_generar_reporte
            // 
            this.btn_generar_reporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_generar_reporte.Location = new System.Drawing.Point(1030, 680);
            this.btn_generar_reporte.Name = "btn_generar_reporte";
            this.btn_generar_reporte.Size = new System.Drawing.Size(155, 47);
            this.btn_generar_reporte.TabIndex = 66;
            this.btn_generar_reporte.Text = "Generar Reporte";
            this.btn_generar_reporte.UseVisualStyleBackColor = true;
            this.btn_generar_reporte.Click += new System.EventHandler(this.btn_generar_reporte_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(626, 11);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(174, 42);
            this.btn_buscar.TabIndex = 65;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // no_reporte
            // 
            this.no_reporte.Location = new System.Drawing.Point(310, 21);
            this.no_reporte.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.no_reporte.Name = "no_reporte";
            this.no_reporte.Size = new System.Drawing.Size(120, 24);
            this.no_reporte.TabIndex = 64;
            // 
            // fecha
            // 
            this.fecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fecha.CustomFormat = "";
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha.Location = new System.Drawing.Point(459, 21);
            this.fecha.Margin = new System.Windows.Forms.Padding(4);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(149, 24);
            this.fecha.TabIndex = 63;
            // 
            // buscar_por
            // 
            this.buscar_por.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buscar_por.FormattingEnabled = true;
            this.buscar_por.Items.AddRange(new object[] {
            "No. de Reporte",
            "Fecha"});
            this.buscar_por.Location = new System.Drawing.Point(132, 19);
            this.buscar_por.Name = "buscar_por";
            this.buscar_por.Size = new System.Drawing.Size(152, 26);
            this.buscar_por.TabIndex = 4;
            this.buscar_por.SelectedIndexChanged += new System.EventHandler(this.buscar_por_SelectedIndexChanged);
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.AllowUserToOrderColumns = true;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Location = new System.Drawing.Point(132, 71);
            this.grd.MultiSelect = false;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowHeadersWidth = 51;
            this.grd.RowTemplate.Height = 24;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd.Size = new System.Drawing.Size(1053, 583);
            this.grd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar por:";
            // 
            // Informe
            // 
            this.Informe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Informe.Controls.Add(this.Buscador);
            this.Informe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Informe.Location = new System.Drawing.Point(12, 12);
            this.Informe.Name = "Informe";
            this.Informe.SelectedIndex = 0;
            this.Informe.Size = new System.Drawing.Size(1285, 783);
            this.Informe.TabIndex = 0;
            // 
            // reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 807);
            this.Controls.Add(this.Informe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.reporte_Load);
            this.Buscador.ResumeLayout(false);
            this.Buscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.no_reporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.Informe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Buscador;
        private System.Windows.Forms.Button btn_generar_reporte;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.NumericUpDown no_reporte;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.ComboBox buscar_por;
        public System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl Informe;
    }
}
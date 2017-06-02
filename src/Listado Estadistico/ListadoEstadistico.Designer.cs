namespace UberFrba.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClienteMismoAuto = new System.Windows.Forms.Button();
            this.btnClienteMayorConsumo = new System.Windows.Forms.Button();
            this.btnChoferViajeMasLargo = new System.Windows.Forms.Button();
            this.btnChoferMayorRecaudacion = new System.Windows.Forms.Button();
            this.cbCuatrimestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAño = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClienteMismoAuto);
            this.groupBox1.Controls.Add(this.btnClienteMayorConsumo);
            this.groupBox1.Controls.Add(this.btnChoferViajeMasLargo);
            this.groupBox1.Controls.Add(this.btnChoferMayorRecaudacion);
            this.groupBox1.Controls.Add(this.cbCuatrimestre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbAño);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta de Estadisticas";
            // 
            // btnClienteMismoAuto
            // 
            this.btnClienteMismoAuto.Location = new System.Drawing.Point(27, 208);
            this.btnClienteMismoAuto.Name = "btnClienteMismoAuto";
            this.btnClienteMismoAuto.Size = new System.Drawing.Size(431, 23);
            this.btnClienteMismoAuto.TabIndex = 7;
            this.btnClienteMismoAuto.Text = "Cliente que utilizo más veces el mismo automóvil en los viajes que ha realizado";
            this.btnClienteMismoAuto.UseVisualStyleBackColor = true;
            this.btnClienteMismoAuto.Click += new System.EventHandler(this.btnClienteMismoAuto_Click);
            // 
            // btnClienteMayorConsumo
            // 
            this.btnClienteMayorConsumo.Location = new System.Drawing.Point(27, 179);
            this.btnClienteMayorConsumo.Name = "btnClienteMayorConsumo";
            this.btnClienteMayorConsumo.Size = new System.Drawing.Size(431, 23);
            this.btnClienteMayorConsumo.TabIndex = 6;
            this.btnClienteMayorConsumo.Text = "Clientes con mayor consumo";
            this.btnClienteMayorConsumo.UseVisualStyleBackColor = true;
            this.btnClienteMayorConsumo.Click += new System.EventHandler(this.btnClienteMayorConsumo_Click);
            // 
            // btnChoferViajeMasLargo
            // 
            this.btnChoferViajeMasLargo.Location = new System.Drawing.Point(27, 149);
            this.btnChoferViajeMasLargo.Name = "btnChoferViajeMasLargo";
            this.btnChoferViajeMasLargo.Size = new System.Drawing.Size(431, 23);
            this.btnChoferViajeMasLargo.TabIndex = 5;
            this.btnChoferViajeMasLargo.Text = "Choferes con el viaje mas largo realizado";
            this.btnChoferViajeMasLargo.UseVisualStyleBackColor = true;
            this.btnChoferViajeMasLargo.Click += new System.EventHandler(this.btnChoferViajeMasLargo_Click);
            // 
            // btnChoferMayorRecaudacion
            // 
            this.btnChoferMayorRecaudacion.Location = new System.Drawing.Point(27, 119);
            this.btnChoferMayorRecaudacion.Name = "btnChoferMayorRecaudacion";
            this.btnChoferMayorRecaudacion.Size = new System.Drawing.Size(431, 23);
            this.btnChoferMayorRecaudacion.TabIndex = 4;
            this.btnChoferMayorRecaudacion.Text = "Choferes con mayor recaudacion";
            this.btnChoferMayorRecaudacion.UseVisualStyleBackColor = true;
            this.btnChoferMayorRecaudacion.Click += new System.EventHandler(this.btnChoferMayorRecaudacion_Click);
            // 
            // cbCuatrimestre
            // 
            this.cbCuatrimestre.FormattingEnabled = true;
            this.cbCuatrimestre.Location = new System.Drawing.Point(182, 71);
            this.cbCuatrimestre.Name = "cbCuatrimestre";
            this.cbCuatrimestre.Size = new System.Drawing.Size(121, 21);
            this.cbCuatrimestre.TabIndex = 3;
            this.cbCuatrimestre.SelectedIndexChanged += new System.EventHandler(this.cbCuatrimestre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elija el cuatrimestre";
            // 
            // tbAño
            // 
            this.tbAño.Location = new System.Drawing.Point(182, 31);
            this.tbAño.Name = "tbAño";
            this.tbAño.Size = new System.Drawing.Size(100, 20);
            this.tbAño.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el año a consultar";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(403, 570);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(88, 28);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(33, 275);
            this.dgvResultados.Name = "dgvResultados";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultados.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResultados.RowHeadersVisible = false;
            this.dgvResultados.Size = new System.Drawing.Size(490, 222);
            this.dgvResultados.TabIndex = 2;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 610);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClienteMismoAuto;
        private System.Windows.Forms.Button btnClienteMayorConsumo;
        private System.Windows.Forms.Button btnChoferViajeMasLargo;
        private System.Windows.Forms.Button btnChoferMayorRecaudacion;
        private System.Windows.Forms.ComboBox cbCuatrimestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvResultados;
    }
}
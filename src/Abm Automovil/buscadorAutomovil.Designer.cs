namespace UberFrba.Abm_Automovil
{
    partial class buscadorAutomovil
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonResetMarcas = new System.Windows.Forms.Button();
            this.comboBoxMarcas = new System.Windows.Forms.ComboBox();
            this.textBoxChofer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPatente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewAutos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonResetMarcas);
            this.groupBox1.Controls.Add(this.comboBoxMarcas);
            this.groupBox1.Controls.Add(this.textBoxChofer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxPatente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxModelo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(793, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Búsqueda";
            // 
            // buttonResetMarcas
            // 
            this.buttonResetMarcas.Location = new System.Drawing.Point(530, 57);
            this.buttonResetMarcas.Name = "buttonResetMarcas";
            this.buttonResetMarcas.Size = new System.Drawing.Size(256, 29);
            this.buttonResetMarcas.TabIndex = 8;
            this.buttonResetMarcas.Text = "Cualquier Marca";
            this.buttonResetMarcas.UseVisualStyleBackColor = true;
            this.buttonResetMarcas.Click += new System.EventHandler(this.buttonResetMarcas_Click);
            // 
            // comboBoxMarcas
            // 
            this.comboBoxMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMarcas.FormattingEnabled = true;
            this.comboBoxMarcas.Location = new System.Drawing.Point(333, 59);
            this.comboBoxMarcas.Name = "comboBoxMarcas";
            this.comboBoxMarcas.Size = new System.Drawing.Size(182, 24);
            this.comboBoxMarcas.TabIndex = 7;
            // 
            // textBoxChofer
            // 
            this.textBoxChofer.Location = new System.Drawing.Point(88, 27);
            this.textBoxChofer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxChofer.Name = "textBoxChofer";
            this.textBoxChofer.Size = new System.Drawing.Size(132, 22);
            this.textBoxChofer.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Chofer";
            // 
            // textBoxPatente
            // 
            this.textBoxPatente.Location = new System.Drawing.Point(333, 27);
            this.textBoxPatente.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPatente.Name = "textBoxPatente";
            this.textBoxPatente.Size = new System.Drawing.Size(182, 22);
            this.textBoxPatente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Patente";
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(88, 59);
            this.textBoxModelo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(132, 22);
            this.textBoxModelo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 135);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 135);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewAutos
            // 
            this.dataGridViewAutos.AllowUserToAddRows = false;
            this.dataGridViewAutos.AllowUserToDeleteRows = false;
            this.dataGridViewAutos.AllowUserToResizeColumns = false;
            this.dataGridViewAutos.AllowUserToResizeRows = false;
            this.dataGridViewAutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewAutos.Location = new System.Drawing.Point(12, 184);
            this.dataGridViewAutos.Name = "dataGridViewAutos";
            this.dataGridViewAutos.ReadOnly = true;
            this.dataGridViewAutos.RowTemplate.Height = 24;
            this.dataGridViewAutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAutos.Size = new System.Drawing.Size(971, 238);
            this.dataGridViewAutos.TabIndex = 3;
            this.dataGridViewAutos.DoubleClick += new System.EventHandler(this.editarAuto);
            // 
            // buscadorAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 434);
            this.Controls.Add(this.dataGridViewAutos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "buscadorAutomovil";
            this.Text = "Listado de Selección";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxChofer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPatente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewAutos;
        private System.Windows.Forms.ComboBox comboBoxMarcas;
        private System.Windows.Forms.Button buttonResetMarcas;
    }
}
namespace UberFrba.Rendicion_Viajes
{
    partial class rendicionViaje
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
            this.tbRendicionTotal = new System.Windows.Forms.TextBox();
            this.cbChoferes = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCalcularRendicion = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTurno);
            this.groupBox1.Controls.Add(this.tbRendicionTotal);
            this.groupBox1.Controls.Add(this.cbChoferes);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(38, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos para rendir";
            // 
            // tbRendicionTotal
            // 
            this.tbRendicionTotal.Location = new System.Drawing.Point(154, 126);
            this.tbRendicionTotal.Name = "tbRendicionTotal";
            this.tbRendicionTotal.Size = new System.Drawing.Size(76, 20);
            this.tbRendicionTotal.TabIndex = 7;
            // 
            // cbChoferes
            // 
            this.cbChoferes.FormattingEnabled = true;
            this.cbChoferes.Location = new System.Drawing.Point(105, 56);
            this.cbChoferes.Name = "cbChoferes";
            this.cbChoferes.Size = new System.Drawing.Size(200, 21);
            this.cbChoferes.TabIndex = 5;
            this.cbChoferes.SelectedIndexChanged += new System.EventHandler(this.cbChoferes_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(105, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Importe total de la rendición";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Turno";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chofer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCalcularRendicion
            // 
            this.btnCalcularRendicion.Location = new System.Drawing.Point(231, 274);
            this.btnCalcularRendicion.Name = "btnCalcularRendicion";
            this.btnCalcularRendicion.Size = new System.Drawing.Size(75, 23);
            this.btnCalcularRendicion.TabIndex = 2;
            this.btnCalcularRendicion.Text = "Guardar";
            this.btnCalcularRendicion.UseVisualStyleBackColor = true;
            this.btnCalcularRendicion.Click += new System.EventHandler(this.btnCalcularRendicion_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(332, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbTurno
            // 
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(105, 87);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(200, 21);
            this.cbTurno.TabIndex = 8;
            this.cbTurno.SelectedIndexChanged += new System.EventHandler(this.cbTurno_SelectedIndexChanged);
            // 
            // rendicionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 309);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCalcularRendicion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "rendicionViaje";
            this.Text = "Rendición de viajes";
            this.Load += new System.EventHandler(this.rendicionViaje_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tbRendicionTotal;
        private System.Windows.Forms.ComboBox cbChoferes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCalcularRendicion;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbTurno;
    }
}
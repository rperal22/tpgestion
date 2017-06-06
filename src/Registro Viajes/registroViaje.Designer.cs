namespace UberFrba.Registro_Viajes
{
    partial class registroViaje
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
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonCambiarCliente = new System.Windows.Forms.Button();
            this.buttonCambiarChofer = new System.Windows.Forms.Button();
            this.labelChofer = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dayPicker = new System.Windows.Forms.DateTimePicker();
            this.lbAutoxChofer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbKM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelInfoTurno = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelInfoTurno);
            this.groupBox1.Controls.Add(this.dtpHoraFin);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.buttonCambiarCliente);
            this.groupBox1.Controls.Add(this.buttonCambiarChofer);
            this.groupBox1.Controls.Add(this.labelChofer);
            this.groupBox1.Controls.Add(this.labelCliente);
            this.groupBox1.Controls.Add(this.cbTurno);
            this.groupBox1.Controls.Add(this.dtpHoraInicio);
            this.groupBox1.Controls.Add(this.dayPicker);
            this.groupBox1.Controls.Add(this.lbAutoxChofer);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbKM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(60, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(897, 491);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Viaje";
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "\"HH:mm\"";
            this.dtpHoraFin.Location = new System.Drawing.Point(551, 315);
            this.dtpHoraFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.Size = new System.Drawing.Size(173, 22);
            this.dtpHoraFin.TabIndex = 27;
            this.dtpHoraFin.Value = new System.DateTime(2017, 6, 2, 11, 59, 14, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 315);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Seleccione hora final";
            // 
            // buttonCambiarCliente
            // 
            this.buttonCambiarCliente.Location = new System.Drawing.Point(673, 355);
            this.buttonCambiarCliente.Name = "buttonCambiarCliente";
            this.buttonCambiarCliente.Size = new System.Drawing.Size(185, 23);
            this.buttonCambiarCliente.TabIndex = 25;
            this.buttonCambiarCliente.Text = "Cambiar";
            this.buttonCambiarCliente.UseVisualStyleBackColor = true;
            this.buttonCambiarCliente.Click += new System.EventHandler(this.buttonCambiarCliente_Click);
            // 
            // buttonCambiarChofer
            // 
            this.buttonCambiarChofer.Location = new System.Drawing.Point(673, 38);
            this.buttonCambiarChofer.Name = "buttonCambiarChofer";
            this.buttonCambiarChofer.Size = new System.Drawing.Size(185, 23);
            this.buttonCambiarChofer.TabIndex = 24;
            this.buttonCambiarChofer.Text = "Cambiar";
            this.buttonCambiarChofer.UseVisualStyleBackColor = true;
            this.buttonCambiarChofer.Click += new System.EventHandler(this.buttonCambiarChofer_Click);
            // 
            // labelChofer
            // 
            this.labelChofer.AutoSize = true;
            this.labelChofer.Location = new System.Drawing.Point(237, 38);
            this.labelChofer.Name = "labelChofer";
            this.labelChofer.Size = new System.Drawing.Size(160, 17);
            this.labelChofer.TabIndex = 22;
            this.labelChofer.Text = "Seleccione algun chofer";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(237, 361);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(161, 17);
            this.labelCliente.TabIndex = 21;
            this.labelCliente.Text = "Seleccione algun cliente";
            // 
            // cbTurno
            // 
            this.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(241, 127);
            this.cbTurno.Margin = new System.Windows.Forms.Padding(4);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(271, 24);
            this.cbTurno.TabIndex = 20;
            this.cbTurno.SelectedIndexChanged += new System.EventHandler(this.cbTurno_SelectedIndexChanged);
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "\"HH:mm\"";
            this.dtpHoraInicio.Location = new System.Drawing.Point(189, 310);
            this.dtpHoraInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(173, 22);
            this.dtpHoraInicio.TabIndex = 19;
            this.dtpHoraInicio.Value = new System.DateTime(2017, 6, 2, 11, 59, 14, 0);
            // 
            // dayPicker
            // 
            this.dayPicker.Location = new System.Drawing.Point(241, 263);
            this.dayPicker.Margin = new System.Windows.Forms.Padding(4);
            this.dayPicker.Name = "dayPicker";
            this.dayPicker.Size = new System.Drawing.Size(265, 22);
            this.dayPicker.TabIndex = 18;
            this.dayPicker.ValueChanged += new System.EventHandler(this.cambioDeFecha);
            // 
            // lbAutoxChofer
            // 
            this.lbAutoxChofer.AutoSize = true;
            this.lbAutoxChofer.Location = new System.Drawing.Point(237, 91);
            this.lbAutoxChofer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAutoxChofer.Name = "lbAutoxChofer";
            this.lbAutoxChofer.Size = new System.Drawing.Size(197, 17);
            this.lbAutoxChofer.TabIndex = 17;
            this.lbAutoxChofer.Text = "No ha seleccionado un chofer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 420);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(316, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Recuerde que todos los campos son obligatorios";
            // 
            // tbKM
            // 
            this.tbKM.Location = new System.Drawing.Point(241, 188);
            this.tbKM.Margin = new System.Windows.Forms.Padding(4);
            this.tbKM.Name = "tbKM";
            this.tbKM.Size = new System.Drawing.Size(271, 22);
            this.tbKM.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 361);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 315);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Seleccione hora inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 263);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha y hora de inicio del viaje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad de KM del viaje";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Automóvil";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chofer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 532);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(466, 532);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(714, 532);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelInfoTurno
            // 
            this.labelInfoTurno.AutoSize = true;
            this.labelInfoTurno.Location = new System.Drawing.Point(548, 138);
            this.labelInfoTurno.Name = "labelInfoTurno";
            this.labelInfoTurno.Size = new System.Drawing.Size(124, 17);
            this.labelInfoTurno.TabIndex = 28;
            this.labelInfoTurno.Text = "Info Turno Horario";
            // 
            // registroViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 647);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "registroViaje";
            this.Text = "Registro del Viaje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbKM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbAutoxChofer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dayPicker;
        private System.Windows.Forms.Label labelChofer;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Button buttonCambiarCliente;
        private System.Windows.Forms.Button buttonCambiarChofer;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelInfoTurno;
    }
}
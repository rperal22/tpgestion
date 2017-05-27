namespace UberFrba
{
    partial class login
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelRol = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonIngresar = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonListo = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // labelRol
            // 
            this.labelRol.AutoSize = true;
            this.labelRol.Enabled = false;
            this.labelRol.Location = new System.Drawing.Point(57, 141);
            this.labelRol.Name = "labelRol";
            this.labelRol.Size = new System.Drawing.Size(23, 13);
            this.labelRol.TabIndex = 1;
            this.labelRol.Text = "Rol";
            this.labelRol.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(100, 32);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(120, 20);
            this.textBoxUsuario.TabIndex = 3;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.Enabled = false;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(117, 138);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoles.TabIndex = 10;
            this.comboBoxRoles.Visible = false;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(234, 49);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 7;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonIngresar
            // 
            this.buttonIngresar.Location = new System.Drawing.Point(235, 19);
            this.buttonIngresar.Name = "buttonIngresar";
            this.buttonIngresar.Size = new System.Drawing.Size(75, 23);
            this.buttonIngresar.TabIndex = 9;
            this.buttonIngresar.Text = "Ingresar";
            this.buttonIngresar.UseVisualStyleBackColor = true;
            this.buttonIngresar.Click += new System.EventHandler(this.buttonIngresar_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(100, 66);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(120, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.buttonIngresar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonLimpiar);
            this.groupBox1.Controls.Add(this.textBoxUsuario);
            this.groupBox1.Location = new System.Drawing.Point(18, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 124);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Usuario";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonListo
            // 
            this.buttonListo.Enabled = false;
            this.buttonListo.Location = new System.Drawing.Point(265, 136);
            this.buttonListo.Name = "buttonListo";
            this.buttonListo.Size = new System.Drawing.Size(75, 23);
            this.buttonListo.TabIndex = 12;
            this.buttonListo.Text = "Listo";
            this.buttonListo.UseVisualStyleBackColor = true;
            this.buttonListo.Visible = false;
            this.buttonListo.Click += new System.EventHandler(this.buttonListo_Click);
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.Location = new System.Drawing.Point(20, 189);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(140, 29);
            this.btnAltaUsuario.TabIndex = 13;
            this.btnAltaUsuario.Text = "Registrarse";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 231);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.buttonListo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.labelRol);
            this.Name = "login";
            this.Text = "Ingreso al Sistema";
            this.Load += new System.EventHandler(this.login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonIngresar;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonListo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAltaUsuario;

    }
}


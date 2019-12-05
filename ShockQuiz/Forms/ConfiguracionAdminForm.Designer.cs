namespace ShockQuiz.Forms
{
    partial class ConfiguracionAdminForm
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
            this.btnAdmin = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cbConjunto = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbToken = new System.Windows.Forms.CheckBox();
            this.btnAddConjunto = new System.Windows.Forms.Button();
            this.nudAddConjunto = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddConjunto = new System.Windows.Forms.TextBox();
            this.helpToken = new System.Windows.Forms.HelpProvider();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddConjunto)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(9, 76);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(245, 23);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Usuario a Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.BtnAdmin_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(55, 24);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(199, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(347, 307);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(265, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // cbConjunto
            // 
            this.cbConjunto.FormattingEnabled = true;
            this.cbConjunto.Location = new System.Drawing.Point(68, 38);
            this.cbConjunto.Name = "cbConjunto";
            this.cbConjunto.Size = new System.Drawing.Size(193, 21);
            this.cbConjunto.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnAdmin);
            this.groupBox1.Location = new System.Drawing.Point(338, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 111);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar autoridad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudCantidad);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbConjunto);
            this.groupBox2.Location = new System.Drawing.Point(10, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 129);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar preguntas a un conjunto";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(68, 69);
            this.nudCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(112, 20);
            this.nudCantidad.TabIndex = 10;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(13, 95);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(271, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Conjunto";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbToken);
            this.groupBox3.Controls.Add(this.btnAddConjunto);
            this.groupBox3.Controls.Add(this.nudAddConjunto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtAddConjunto);
            this.groupBox3.Location = new System.Drawing.Point(10, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(292, 154);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Añadir Conjunto";
            // 
            // cbToken
            // 
            this.cbToken.AutoSize = true;
            this.cbToken.Location = new System.Drawing.Point(12, 95);
            this.cbToken.Name = "cbToken";
            this.cbToken.Size = new System.Drawing.Size(84, 17);
            this.cbToken.TabIndex = 5;
            this.cbToken.Text = "Pedir Token";
            this.cbToken.UseVisualStyleBackColor = true;
            // 
            // btnAddConjunto
            // 
            this.btnAddConjunto.Location = new System.Drawing.Point(6, 125);
            this.btnAddConjunto.Name = "btnAddConjunto";
            this.btnAddConjunto.Size = new System.Drawing.Size(280, 23);
            this.btnAddConjunto.TabIndex = 4;
            this.btnAddConjunto.Text = "Añadir";
            this.btnAddConjunto.UseVisualStyleBackColor = true;
            this.btnAddConjunto.Click += new System.EventHandler(this.btnAddConjunto_Click);
            // 
            // nudAddConjunto
            // 
            this.nudAddConjunto.Location = new System.Drawing.Point(108, 59);
            this.nudAddConjunto.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudAddConjunto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAddConjunto.Name = "nudAddConjunto";
            this.nudAddConjunto.Size = new System.Drawing.Size(120, 20);
            this.nudAddConjunto.TabIndex = 3;
            this.nudAddConjunto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 35);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tiempo Esperado por Pregunta";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nombre";
            // 
            // txtAddConjunto
            // 
            this.txtAddConjunto.Location = new System.Drawing.Point(108, 24);
            this.txtAddConjunto.Name = "txtAddConjunto";
            this.txtAddConjunto.Size = new System.Drawing.Size(120, 20);
            this.txtAddConjunto.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(6, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 320);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "OpenTDB";
            // 
            // ConfiguracionAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(633, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox4);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracionAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddConjunto)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cbConjunto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddConjunto;
        private System.Windows.Forms.NumericUpDown nudAddConjunto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddConjunto;
        private System.Windows.Forms.CheckBox cbToken;
        private System.Windows.Forms.HelpProvider helpToken;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
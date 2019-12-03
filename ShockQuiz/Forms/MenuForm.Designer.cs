namespace ShockQuiz.Forms
{
    partial class MenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevaSesion = new System.Windows.Forms.Button();
            this.btnRanking = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu Principal";
            // 
            // btnNuevaSesion
            // 
            this.btnNuevaSesion.Location = new System.Drawing.Point(36, 53);
            this.btnNuevaSesion.Name = "btnNuevaSesion";
            this.btnNuevaSesion.Size = new System.Drawing.Size(164, 23);
            this.btnNuevaSesion.TabIndex = 1;
            this.btnNuevaSesion.Text = "Iniciar";
            this.btnNuevaSesion.UseVisualStyleBackColor = true;
            this.btnNuevaSesion.Click += new System.EventHandler(this.BtnNuevaSesion_Click);
            // 
            // btnRanking
            // 
            this.btnRanking.Location = new System.Drawing.Point(36, 82);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(164, 23);
            this.btnRanking.TabIndex = 2;
            this.btnRanking.Text = "Ranking";
            this.btnRanking.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(36, 111);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(164, 23);
            this.btnConfiguracion.TabIndex = 3;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(36, 152);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(164, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 187);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.btnRanking);
            this.Controls.Add(this.btnNuevaSesion);
            this.Controls.Add(this.label1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevaSesion;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnSalir;
    }
}
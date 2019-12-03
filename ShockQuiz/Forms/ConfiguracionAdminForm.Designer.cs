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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearConjunto = new System.Windows.Forms.Button();
            this.txtConjunto = new System.Windows.Forms.TextBox();
            this.txtAscender = new System.Windows.Forms.TextBox();
            this.btnAscender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuración";
            // 
            // btnCrearConjunto
            // 
            this.btnCrearConjunto.Location = new System.Drawing.Point(183, 58);
            this.btnCrearConjunto.Name = "btnCrearConjunto";
            this.btnCrearConjunto.Size = new System.Drawing.Size(104, 23);
            this.btnCrearConjunto.TabIndex = 1;
            this.btnCrearConjunto.Text = "Crear conjunto";
            this.btnCrearConjunto.UseVisualStyleBackColor = true;
            // 
            // txtConjunto
            // 
            this.txtConjunto.Location = new System.Drawing.Point(13, 60);
            this.txtConjunto.Name = "txtConjunto";
            this.txtConjunto.Size = new System.Drawing.Size(164, 20);
            this.txtConjunto.TabIndex = 2;
            // 
            // txtAscender
            // 
            this.txtAscender.Location = new System.Drawing.Point(293, 60);
            this.txtAscender.Name = "txtAscender";
            this.txtAscender.Size = new System.Drawing.Size(164, 20);
            this.txtAscender.TabIndex = 3;
            // 
            // btnAscender
            // 
            this.btnAscender.Location = new System.Drawing.Point(463, 58);
            this.btnAscender.Name = "btnAscender";
            this.btnAscender.Size = new System.Drawing.Size(104, 23);
            this.btnAscender.TabIndex = 4;
            this.btnAscender.Text = "Ascender usuario";
            this.btnAscender.UseVisualStyleBackColor = true;
            // 
            // ConfiguracionAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 320);
            this.Controls.Add(this.btnAscender);
            this.Controls.Add(this.txtAscender);
            this.Controls.Add(this.txtConjunto);
            this.Controls.Add(this.btnCrearConjunto);
            this.Controls.Add(this.label1);
            this.Name = "ConfiguracionAdminForm";
            this.Text = "ConfiguracionAdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearConjunto;
        private System.Windows.Forms.TextBox txtConjunto;
        private System.Windows.Forms.TextBox txtAscender;
        private System.Windows.Forms.Button btnAscender;
    }
}
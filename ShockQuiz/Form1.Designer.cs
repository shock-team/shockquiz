namespace ShockQuiz
{
    partial class Form1
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
            this.lblPregunta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRespuesta3 = new System.Windows.Forms.Button();
            this.btnRespuesta1 = new System.Windows.Forms.Button();
            this.btnRespuesta2 = new System.Windows.Forms.Button();
            this.btnRespuesta4 = new System.Windows.Forms.Button();
            this.lblRespuestasActuales = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRespuestasTotales = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(217, 147);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(276, 13);
            this.lblPregunta.TabIndex = 4;
            this.lblPregunta.Text = "Preguntaaaaaaaaaaaaaaaaaaaæaaaaaaaaaaaaaaaaaa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Respuestas correctas";
            // 
            // btnRespuesta3
            // 
            this.btnRespuesta3.BackColor = System.Drawing.Color.Red;
            this.btnRespuesta3.Location = new System.Drawing.Point(12, 287);
            this.btnRespuesta3.Name = "btnRespuesta3";
            this.btnRespuesta3.Size = new System.Drawing.Size(317, 40);
            this.btnRespuesta3.TabIndex = 6;
            this.btnRespuesta3.Text = "button1";
            this.btnRespuesta3.UseVisualStyleBackColor = false;
            // 
            // btnRespuesta1
            // 
            this.btnRespuesta1.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRespuesta1.Location = new System.Drawing.Point(12, 241);
            this.btnRespuesta1.Name = "btnRespuesta1";
            this.btnRespuesta1.Size = new System.Drawing.Size(317, 40);
            this.btnRespuesta1.TabIndex = 7;
            this.btnRespuesta1.Text = "button2";
            this.btnRespuesta1.UseVisualStyleBackColor = false;
            this.btnRespuesta1.Click += new System.EventHandler(this.BtnRespuesta1_Click);
            // 
            // btnRespuesta2
            // 
            this.btnRespuesta2.BackColor = System.Drawing.Color.Lime;
            this.btnRespuesta2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRespuesta2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnRespuesta2.Location = new System.Drawing.Point(386, 241);
            this.btnRespuesta2.Name = "btnRespuesta2";
            this.btnRespuesta2.Size = new System.Drawing.Size(317, 40);
            this.btnRespuesta2.TabIndex = 8;
            this.btnRespuesta2.Text = "button3";
            this.btnRespuesta2.UseVisualStyleBackColor = false;
            // 
            // btnRespuesta4
            // 
            this.btnRespuesta4.BackColor = System.Drawing.SystemColors.Control;
            this.btnRespuesta4.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRespuesta4.Location = new System.Drawing.Point(386, 287);
            this.btnRespuesta4.Name = "btnRespuesta4";
            this.btnRespuesta4.Size = new System.Drawing.Size(317, 40);
            this.btnRespuesta4.TabIndex = 9;
            this.btnRespuesta4.Text = "button4";
            this.btnRespuesta4.UseVisualStyleBackColor = false;
            // 
            // lblRespuestasActuales
            // 
            this.lblRespuestasActuales.AutoSize = true;
            this.lblRespuestasActuales.Location = new System.Drawing.Point(651, 9);
            this.lblRespuestasActuales.Name = "lblRespuestasActuales";
            this.lblRespuestasActuales.Size = new System.Drawing.Size(14, 13);
            this.lblRespuestasActuales.TabIndex = 10;
            this.lblRespuestasActuales.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(602, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tiempo";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(651, 33);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(55, 13);
            this.lblTiempo.TabIndex = 12;
            this.lblTiempo.Text = "æ : æ : æ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "/";
            // 
            // lblRespuestasTotales
            // 
            this.lblRespuestasTotales.AutoSize = true;
            this.lblRespuestasTotales.Location = new System.Drawing.Point(689, 9);
            this.lblRespuestasTotales.Name = "lblRespuestasTotales";
            this.lblRespuestasTotales.Size = new System.Drawing.Size(14, 13);
            this.lblRespuestasTotales.TabIndex = 14;
            this.lblRespuestasTotales.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Categoría";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Dificultad";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(69, 9);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(16, 13);
            this.lblCategoria.TabIndex = 17;
            this.lblCategoria.Text = "☼";
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.Location = new System.Drawing.Point(69, 33);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(13, 13);
            this.lblDificultad.TabIndex = 18;
            this.lblDificultad.Text = "‼";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(675, 136);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(27, 23);
            this.btnSiguiente.TabIndex = 19;
            this.btnSiguiente.Text = "→";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 339);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblRespuestasTotales);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRespuestasActuales);
            this.Controls.Add(this.btnRespuesta4);
            this.Controls.Add(this.btnRespuesta2);
            this.Controls.Add(this.btnRespuesta1);
            this.Controls.Add(this.btnRespuesta3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPregunta);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRespuesta3;
        private System.Windows.Forms.Button btnRespuesta1;
        private System.Windows.Forms.Button btnRespuesta2;
        private System.Windows.Forms.Button btnRespuesta4;
        private System.Windows.Forms.Label lblRespuestasActuales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRespuestasTotales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Button btnSiguiente;
    }
}


namespace ShockQuiz.Forms
{
    partial class RankingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingForm));
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Ranking = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.Ranking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.puntaje,
            this.fecha,
            this.duracion});
            this.dgvRanking.Location = new System.Drawing.Point(6, 19);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.Size = new System.Drawing.Size(454, 263);
            this.dgvRanking.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(385, 296);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Ranking
            // 
            this.Ranking.Controls.Add(this.btnActualizar);
            this.Ranking.Controls.Add(this.nudTop);
            this.Ranking.Controls.Add(this.label1);
            this.Ranking.Controls.Add(this.btnSalir);
            this.Ranking.Controls.Add(this.dgvRanking);
            this.Ranking.Location = new System.Drawing.Point(12, 12);
            this.Ranking.Name = "Ranking";
            this.Ranking.Size = new System.Drawing.Size(468, 330);
            this.Ranking.TabIndex = 2;
            this.Ranking.TabStop = false;
            this.Ranking.Text = "Ranking";
            // 
            // btnActualizar
            // 
            this.btnActualizar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnActualizar.Location = new System.Drawing.Point(205, 296);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // nudTop
            // 
            this.nudTop.Location = new System.Drawing.Point(79, 299);
            this.nudTop.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(120, 20);
            this.nudTop.TabIndex = 3;
            this.nudTop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top número:";
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nickname";
            this.nombre.Name = "nombre";
            // 
            // puntaje
            // 
            this.puntaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.puntaje.HeaderText = "Puntaje";
            this.puntaje.Name = "puntaje";
            this.puntaje.Width = 68;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.Width = 62;
            // 
            // duracion
            // 
            this.duracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.duracion.HeaderText = "Duración (s)";
            this.duracion.Name = "duracion";
            this.duracion.Width = 89;
            // 
            // RankingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(495, 351);
            this.Controls.Add(this.Ranking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RankingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ranking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.Ranking.ResumeLayout(false);
            this.Ranking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox Ranking;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracion;
    }
}
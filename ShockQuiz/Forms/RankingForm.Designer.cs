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
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Ranking = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.Ranking.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Location = new System.Drawing.Point(6, 19);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.Size = new System.Drawing.Size(627, 263);
            this.dgvRanking.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(558, 297);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Ranking
            // 
            this.Ranking.Controls.Add(this.btnSalir);
            this.Ranking.Controls.Add(this.dgvRanking);
            this.Ranking.Location = new System.Drawing.Point(12, 12);
            this.Ranking.Name = "Ranking";
            this.Ranking.Size = new System.Drawing.Size(649, 330);
            this.Ranking.TabIndex = 2;
            this.Ranking.TabStop = false;
            this.Ranking.Text = "Ranking";
            // 
            // RankingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 350);
            this.Controls.Add(this.Ranking);
            this.Name = "RankingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RankingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.Ranking.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox Ranking;
    }
}
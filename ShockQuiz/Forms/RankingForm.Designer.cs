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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Location = new System.Drawing.Point(12, 12);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.Size = new System.Drawing.Size(627, 263);
            this.dgvRanking.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(564, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RankingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRanking);
            this.Name = "RankingForm";
            this.Text = "RankingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Button button1;
    }
}
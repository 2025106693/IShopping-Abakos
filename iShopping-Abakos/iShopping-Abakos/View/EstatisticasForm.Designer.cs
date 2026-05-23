namespace iShopping_Abakos.View
{
    partial class EstatisticasForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Voltar = new System.Windows.Forms.Button();
            this.dataGridView_Orcamentos = new System.Windows.Forms.DataGridView();
            this.dataGridView_EstatisticasCompras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orcamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EstatisticasCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estatísticas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(55, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Histórico de Orçamentos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(55, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estatísticas de Compra:";
            // 
            // button_Voltar
            // 
            this.button_Voltar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Voltar.Location = new System.Drawing.Point(650, 565);
            this.button_Voltar.Name = "button_Voltar";
            this.button_Voltar.Size = new System.Drawing.Size(191, 36);
            this.button_Voltar.TabIndex = 3;
            this.button_Voltar.Text = "Voltar";
            this.button_Voltar.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Orcamentos
            // 
            this.dataGridView_Orcamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Orcamentos.Location = new System.Drawing.Point(59, 157);
            this.dataGridView_Orcamentos.Name = "dataGridView_Orcamentos";
            this.dataGridView_Orcamentos.RowHeadersWidth = 51;
            this.dataGridView_Orcamentos.RowTemplate.Height = 24;
            this.dataGridView_Orcamentos.Size = new System.Drawing.Size(782, 150);
            this.dataGridView_Orcamentos.TabIndex = 4;
            // 
            // dataGridView_EstatisticasCompras
            // 
            this.dataGridView_EstatisticasCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_EstatisticasCompras.Location = new System.Drawing.Point(59, 377);
            this.dataGridView_EstatisticasCompras.Name = "dataGridView_EstatisticasCompras";
            this.dataGridView_EstatisticasCompras.RowHeadersWidth = 51;
            this.dataGridView_EstatisticasCompras.RowTemplate.Height = 24;
            this.dataGridView_EstatisticasCompras.Size = new System.Drawing.Size(782, 170);
            this.dataGridView_EstatisticasCompras.TabIndex = 5;
            // 
            // EstatisticasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 626);
            this.Controls.Add(this.dataGridView_EstatisticasCompras);
            this.Controls.Add(this.dataGridView_Orcamentos);
            this.Controls.Add(this.button_Voltar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EstatisticasForm";
            this.Text = "EstatisticasForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Orcamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EstatisticasCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Voltar;
        private System.Windows.Forms.DataGridView dataGridView_Orcamentos;
        private System.Windows.Forms.DataGridView dataGridView_EstatisticasCompras;
    }
}
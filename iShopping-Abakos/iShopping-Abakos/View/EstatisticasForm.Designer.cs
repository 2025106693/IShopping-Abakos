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
            this.button_GerarEstatisticasOrcamento = new System.Windows.Forms.Button();
            this.label_Sugestao = new System.Windows.Forms.Label();
            this.label_Media = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(203, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estatísticas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(58, 131);
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
            this.button_Voltar.Click += new System.EventHandler(this.button_Voltar_Click);
            // 
            // dataGridView_Orcamentos
            // 
            this.dataGridView_Orcamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Orcamentos.Location = new System.Drawing.Point(59, 157);
            this.dataGridView_Orcamentos.Name = "dataGridView_Orcamentos";
            this.dataGridView_Orcamentos.RowHeadersWidth = 51;
            this.dataGridView_Orcamentos.RowTemplate.Height = 24;
            this.dataGridView_Orcamentos.Size = new System.Drawing.Size(308, 169);
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
            // button_GerarEstatisticasOrcamento
            // 
            this.button_GerarEstatisticasOrcamento.Location = new System.Drawing.Point(609, 279);
            this.button_GerarEstatisticasOrcamento.Name = "button_GerarEstatisticasOrcamento";
            this.button_GerarEstatisticasOrcamento.Size = new System.Drawing.Size(232, 47);
            this.button_GerarEstatisticasOrcamento.TabIndex = 6;
            this.button_GerarEstatisticasOrcamento.Text = "Gerar Estatísticas de Orçamento";
            this.button_GerarEstatisticasOrcamento.UseVisualStyleBackColor = true;
            this.button_GerarEstatisticasOrcamento.Click += new System.EventHandler(this.button_GerarEstatisticasOrcamento_Click);
            // 
            // label_Sugestao
            // 
            this.label_Sugestao.AutoSize = true;
            this.label_Sugestao.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_Sugestao.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Sugestao.Location = new System.Drawing.Point(792, 157);
            this.label_Sugestao.Name = "label_Sugestao";
            this.label_Sugestao.Size = new System.Drawing.Size(49, 19);
            this.label_Sugestao.TabIndex = 7;
            this.label_Sugestao.Text = "0.00€\r\n";
            // 
            // label_Media
            // 
            this.label_Media.AutoSize = true;
            this.label_Media.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Media.Location = new System.Drawing.Point(405, 191);
            this.label_Media.Name = "label_Media";
            this.label_Media.Size = new System.Drawing.Size(327, 38);
            this.label_Media.TabIndex = 8;
            this.label_Media.Text = "Média dos últimos meses (baseado até aos últimos 6):\r\n\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sugestão do próximo orçamento: ";
            // 
            // EstatisticasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 626);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Media);
            this.Controls.Add(this.label_Sugestao);
            this.Controls.Add(this.button_GerarEstatisticasOrcamento);
            this.Controls.Add(this.dataGridView_EstatisticasCompras);
            this.Controls.Add(this.dataGridView_Orcamentos);
            this.Controls.Add(this.button_Voltar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EstatisticasForm";
            this.Text = "EstatisticasForm";
            this.Load += new System.EventHandler(this.EstatisticasForm_Load);
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
        private System.Windows.Forms.Button button_GerarEstatisticasOrcamento;
        private System.Windows.Forms.Label label_Sugestao;
        private System.Windows.Forms.Label label_Media;
        private System.Windows.Forms.Label label4;
    }
}
namespace iShopping_Abakos.View
{
    partial class AdicionarItensNaoPrevistosForm
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
            System.Windows.Forms.Label label1;
            this.textBox_ID_NP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownQuantidade = new System.Windows.Forms.NumericUpDown();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            this.comboBox_TipoArtigo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Voltar = new System.Windows.Forms.Button();
            this.buttonAlterarQuantNP = new System.Windows.Forms.Button();
            this.buttonApagarItemNP = new System.Windows.Forms.Button();
            this.buttonAdicionarItemNP = new System.Windows.Forms.Button();
            this.label_TotalCompra = new System.Windows.Forms.Label();
            this.dataGridView_ItensCompra = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_NomeCompra = new System.Windows.Forms.Label();
            this.textBox_Observacoes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItensCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(31, 367);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 20);
            label1.TabIndex = 26;
            label1.Text = "Tipo de Artigo: ";
            // 
            // textBox_ID_NP
            // 
            this.textBox_ID_NP.Location = new System.Drawing.Point(338, 558);
            this.textBox_ID_NP.Name = "textBox_ID_NP";
            this.textBox_ID_NP.Size = new System.Drawing.Size(100, 22);
            this.textBox_ID_NP.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(304, 560);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "ID:";
            // 
            // numericUpDownQuantidade
            // 
            this.numericUpDownQuantidade.Location = new System.Drawing.Point(189, 441);
            this.numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            this.numericUpDownQuantidade.Size = new System.Drawing.Size(249, 22);
            this.numericUpDownQuantidade.TabIndex = 31;
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Location = new System.Drawing.Point(189, 404);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(249, 24);
            this.comboBoxArtigo.TabIndex = 30;
            // 
            // comboBox_TipoArtigo
            // 
            this.comboBox_TipoArtigo.FormattingEnabled = true;
            this.comboBox_TipoArtigo.Location = new System.Drawing.Point(189, 364);
            this.comboBox_TipoArtigo.Name = "comboBox_TipoArtigo";
            this.comboBox_TipoArtigo.Size = new System.Drawing.Size(249, 24);
            this.comboBox_TipoArtigo.TabIndex = 29;
            this.comboBox_TipoArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBox_TipoArtigo_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Quantidade:\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Artigo:\r\n";
            // 
            // button_Voltar
            // 
            this.button_Voltar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Voltar.Location = new System.Drawing.Point(839, 558);
            this.button_Voltar.Name = "button_Voltar";
            this.button_Voltar.Size = new System.Drawing.Size(116, 29);
            this.button_Voltar.TabIndex = 25;
            this.button_Voltar.Text = "Voltar";
            this.button_Voltar.UseVisualStyleBackColor = true;
            this.button_Voltar.Click += new System.EventHandler(this.button_Voltar_Click_1);
            // 
            // buttonAlterarQuantNP
            // 
            this.buttonAlterarQuantNP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlterarQuantNP.Location = new System.Drawing.Point(600, 488);
            this.buttonAlterarQuantNP.Name = "buttonAlterarQuantNP";
            this.buttonAlterarQuantNP.Size = new System.Drawing.Size(355, 32);
            this.buttonAlterarQuantNP.TabIndex = 24;
            this.buttonAlterarQuantNP.Text = "Alterar Quantidade ";
            this.buttonAlterarQuantNP.UseVisualStyleBackColor = true;
            this.buttonAlterarQuantNP.Click += new System.EventHandler(this.buttonAlterarQuantNP_Click_1);
            // 
            // buttonApagarItemNP
            // 
            this.buttonApagarItemNP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApagarItemNP.Location = new System.Drawing.Point(600, 428);
            this.buttonApagarItemNP.Name = "buttonApagarItemNP";
            this.buttonApagarItemNP.Size = new System.Drawing.Size(355, 32);
            this.buttonApagarItemNP.TabIndex = 23;
            this.buttonApagarItemNP.Text = "Apagar Item";
            this.buttonApagarItemNP.UseVisualStyleBackColor = true;
            this.buttonApagarItemNP.Click += new System.EventHandler(this.buttonApagarItemNP_Click_1);
            // 
            // buttonAdicionarItemNP
            // 
            this.buttonAdicionarItemNP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarItemNP.Location = new System.Drawing.Point(600, 367);
            this.buttonAdicionarItemNP.Name = "buttonAdicionarItemNP";
            this.buttonAdicionarItemNP.Size = new System.Drawing.Size(355, 32);
            this.buttonAdicionarItemNP.TabIndex = 22;
            this.buttonAdicionarItemNP.Text = "Adicionar Item";
            this.buttonAdicionarItemNP.UseVisualStyleBackColor = true;
            this.buttonAdicionarItemNP.Click += new System.EventHandler(this.buttonAdicionarItemNP_Click_1);
            // 
            // label_TotalCompra
            // 
            this.label_TotalCompra.AutoSize = true;
            this.label_TotalCompra.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalCompra.Location = new System.Drawing.Point(759, 79);
            this.label_TotalCompra.Name = "label_TotalCompra";
            this.label_TotalCompra.Size = new System.Drawing.Size(196, 20);
            this.label_TotalCompra.TabIndex = 21;
            this.label_TotalCompra.Text = "Total da Compra: 000.00€";
            // 
            // dataGridView_ItensCompra
            // 
            this.dataGridView_ItensCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ItensCompra.Location = new System.Drawing.Point(34, 102);
            this.dataGridView_ItensCompra.Name = "dataGridView_ItensCompra";
            this.dataGridView_ItensCompra.RowHeadersWidth = 51;
            this.dataGridView_ItensCompra.RowTemplate.Height = 24;
            this.dataGridView_ItensCompra.Size = new System.Drawing.Size(921, 228);
            this.dataGridView_ItensCompra.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Os seus itens atuais:";
            // 
            // label_NomeCompra
            // 
            this.label_NomeCompra.AutoSize = true;
            this.label_NomeCompra.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NomeCompra.Location = new System.Drawing.Point(26, 18);
            this.label_NomeCompra.Name = "label_NomeCompra";
            this.label_NomeCompra.Size = new System.Drawing.Size(282, 40);
            this.label_NomeCompra.TabIndex = 18;
            this.label_NomeCompra.Text = "Nome da Compra";
            // 
            // textBox_Observacoes
            // 
            this.textBox_Observacoes.Location = new System.Drawing.Point(189, 479);
            this.textBox_Observacoes.Multiline = true;
            this.textBox_Observacoes.Name = "textBox_Observacoes";
            this.textBox_Observacoes.Size = new System.Drawing.Size(249, 64);
            this.textBox_Observacoes.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Observações:";
            // 
            // AdicionarItensNaoPrevistosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 652);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Observacoes);
            this.Controls.Add(this.textBox_ID_NP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownQuantidade);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.comboBox_TipoArtigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(label1);
            this.Controls.Add(this.button_Voltar);
            this.Controls.Add(this.buttonAlterarQuantNP);
            this.Controls.Add(this.buttonApagarItemNP);
            this.Controls.Add(this.buttonAdicionarItemNP);
            this.Controls.Add(this.label_TotalCompra);
            this.Controls.Add(this.dataGridView_ItensCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_NomeCompra);
            this.Name = "AdicionarItensNaoPrevistosForm";
            this.Text = "AdicionarItensNaoPrevistosForm";
            this.Load += new System.EventHandler(this.AdicionarItensNaoPrevistosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItensCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ID_NP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantidade;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.ComboBox comboBox_TipoArtigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Voltar;
        private System.Windows.Forms.Button buttonAlterarQuantNP;
        private System.Windows.Forms.Button buttonApagarItemNP;
        private System.Windows.Forms.Button buttonAdicionarItemNP;
        private System.Windows.Forms.Label label_TotalCompra;
        private System.Windows.Forms.DataGridView dataGridView_ItensCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_NomeCompra;
        private System.Windows.Forms.TextBox textBox_Observacoes;
        private System.Windows.Forms.Label label5;
    }
}
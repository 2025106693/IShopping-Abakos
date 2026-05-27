namespace iShopping_Abakos.View
{
    partial class AdicionarItensPrevistosForm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2_Artigos = new System.Windows.Forms.ComboBox();
            this.comboBox_TiposArtigos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Voltar = new System.Windows.Forms.Button();
            this.button_AlterarQuantidade = new System.Windows.Forms.Button();
            this.button_ApagarItem = new System.Windows.Forms.Button();
            this.button_AdicionarItem = new System.Windows.Forms.Button();
            this.label_TotalCompra = new System.Windows.Forms.Label();
            this.dataGridView_ItensCompra = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_NomeCompra = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItensCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(54, 384);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 20);
            label1.TabIndex = 26;
            label1.Text = "Tipo de Artigo: ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(361, 522);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(327, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "ID:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(212, 458);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(249, 22);
            this.numericUpDown1.TabIndex = 31;
            // 
            // comboBox2_Artigos
            // 
            this.comboBox2_Artigos.FormattingEnabled = true;
            this.comboBox2_Artigos.Location = new System.Drawing.Point(212, 421);
            this.comboBox2_Artigos.Name = "comboBox2_Artigos";
            this.comboBox2_Artigos.Size = new System.Drawing.Size(249, 24);
            this.comboBox2_Artigos.TabIndex = 30;
            // 
            // comboBox_TiposArtigos
            // 
            this.comboBox_TiposArtigos.FormattingEnabled = true;
            this.comboBox_TiposArtigos.Location = new System.Drawing.Point(212, 381);
            this.comboBox_TiposArtigos.Name = "comboBox_TiposArtigos";
            this.comboBox_TiposArtigos.Size = new System.Drawing.Size(249, 24);
            this.comboBox_TiposArtigos.TabIndex = 29;
            this.comboBox_TiposArtigos.SelectedIndexChanged += new System.EventHandler(this.comboBox_TiposArtigos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Quantidade:\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Artigo:\r\n";
            // 
            // button_Voltar
            // 
            this.button_Voltar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Voltar.Location = new System.Drawing.Point(862, 575);
            this.button_Voltar.Name = "button_Voltar";
            this.button_Voltar.Size = new System.Drawing.Size(116, 29);
            this.button_Voltar.TabIndex = 25;
            this.button_Voltar.Text = "Voltar";
            this.button_Voltar.UseVisualStyleBackColor = true;
            this.button_Voltar.Click += new System.EventHandler(this.button_Voltar_Click);
            // 
            // button_AlterarQuantidade
            // 
            this.button_AlterarQuantidade.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AlterarQuantidade.Location = new System.Drawing.Point(623, 505);
            this.button_AlterarQuantidade.Name = "button_AlterarQuantidade";
            this.button_AlterarQuantidade.Size = new System.Drawing.Size(355, 32);
            this.button_AlterarQuantidade.TabIndex = 24;
            this.button_AlterarQuantidade.Text = "Alterar Quantidade ";
            this.button_AlterarQuantidade.UseVisualStyleBackColor = true;
            // 
            // button_ApagarItem
            // 
            this.button_ApagarItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ApagarItem.Location = new System.Drawing.Point(623, 445);
            this.button_ApagarItem.Name = "button_ApagarItem";
            this.button_ApagarItem.Size = new System.Drawing.Size(355, 32);
            this.button_ApagarItem.TabIndex = 23;
            this.button_ApagarItem.Text = "Apagar Item";
            this.button_ApagarItem.UseVisualStyleBackColor = true;
            // 
            // button_AdicionarItem
            // 
            this.button_AdicionarItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AdicionarItem.Location = new System.Drawing.Point(623, 384);
            this.button_AdicionarItem.Name = "button_AdicionarItem";
            this.button_AdicionarItem.Size = new System.Drawing.Size(355, 32);
            this.button_AdicionarItem.TabIndex = 22;
            this.button_AdicionarItem.Text = "Adicionar Item";
            this.button_AdicionarItem.UseVisualStyleBackColor = true;
            this.button_AdicionarItem.Click += new System.EventHandler(this.button_AdicionarItem_Click);
            // 
            // label_TotalCompra
            // 
            this.label_TotalCompra.AutoSize = true;
            this.label_TotalCompra.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalCompra.Location = new System.Drawing.Point(782, 96);
            this.label_TotalCompra.Name = "label_TotalCompra";
            this.label_TotalCompra.Size = new System.Drawing.Size(196, 20);
            this.label_TotalCompra.TabIndex = 21;
            this.label_TotalCompra.Text = "Total da Compra: 000.00€";
            // 
            // dataGridView_ItensCompra
            // 
            this.dataGridView_ItensCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ItensCompra.Location = new System.Drawing.Point(57, 119);
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
            this.label2.Location = new System.Drawing.Point(54, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Os seus itens atuais:";
            // 
            // label_NomeCompra
            // 
            this.label_NomeCompra.AutoSize = true;
            this.label_NomeCompra.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NomeCompra.Location = new System.Drawing.Point(49, 35);
            this.label_NomeCompra.Name = "label_NomeCompra";
            this.label_NomeCompra.Size = new System.Drawing.Size(282, 40);
            this.label_NomeCompra.TabIndex = 18;
            this.label_NomeCompra.Text = "Nome da Compra";
            // 
            // AdicionarItensPrevistosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 668);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox2_Artigos);
            this.Controls.Add(this.comboBox_TiposArtigos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(label1);
            this.Controls.Add(this.button_Voltar);
            this.Controls.Add(this.button_AlterarQuantidade);
            this.Controls.Add(this.button_ApagarItem);
            this.Controls.Add(this.button_AdicionarItem);
            this.Controls.Add(this.label_TotalCompra);
            this.Controls.Add(this.dataGridView_ItensCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_NomeCompra);
            this.Name = "AdicionarItensPrevistosForm";
            this.Text = "AdicionarItensPrevistosForm";
            this.Load += new System.EventHandler(this.AdicionarItensPrevistosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItensCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox2_Artigos;
        private System.Windows.Forms.ComboBox comboBox_TiposArtigos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Voltar;
        private System.Windows.Forms.Button button_AlterarQuantidade;
        private System.Windows.Forms.Button button_ApagarItem;
        private System.Windows.Forms.Button button_AdicionarItem;
        private System.Windows.Forms.Label label_TotalCompra;
        private System.Windows.Forms.DataGridView dataGridView_ItensCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_NomeCompra;
    }
}
namespace iShopping_Abakos
{
    partial class PaginaInicialForm
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
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Sair = new System.Windows.Forms.Button();
            this.button_VisualizarDetalhes = new System.Windows.Forms.Button();
            this.button_ExportarCSV = new System.Windows.Forms.Button();
            this.label_Compras = new System.Windows.Forms.Label();
            this.label_Orcamento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_NomeUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Estatisticas = new System.Windows.Forms.Button();
            this.button_Compras = new System.Windows.Forms.Button();
            this.button_Artigos = new System.Windows.Forms.Button();
            this.button_TipoArtigos = new System.Windows.Forms.Button();
            this.button_Orcamento = new System.Windows.Forms.Button();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label_Estado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompras.Location = new System.Drawing.Point(337, 206);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.RowHeadersWidth = 51;
            this.dataGridViewCompras.RowTemplate.Height = 24;
            this.dataGridViewCompras.Size = new System.Drawing.Size(634, 278);
            this.dataGridViewCompras.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(337, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(638, 2);
            this.label6.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(292, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 532);
            this.label5.TabIndex = 34;
            // 
            // button_Sair
            // 
            this.button_Sair.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sair.Location = new System.Drawing.Point(90, 503);
            this.button_Sair.Name = "button_Sair";
            this.button_Sair.Size = new System.Drawing.Size(102, 39);
            this.button_Sair.TabIndex = 33;
            this.button_Sair.Text = "Sair";
            this.button_Sair.UseVisualStyleBackColor = true;
            this.button_Sair.Click += new System.EventHandler(this.button_Sair_Click);
            // 
            // button_VisualizarDetalhes
            // 
            this.button_VisualizarDetalhes.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_VisualizarDetalhes.Location = new System.Drawing.Point(788, 503);
            this.button_VisualizarDetalhes.Name = "button_VisualizarDetalhes";
            this.button_VisualizarDetalhes.Size = new System.Drawing.Size(183, 39);
            this.button_VisualizarDetalhes.TabIndex = 32;
            this.button_VisualizarDetalhes.Text = "Visualizar Detalhes";
            this.button_VisualizarDetalhes.UseVisualStyleBackColor = true;
            this.button_VisualizarDetalhes.Click += new System.EventHandler(this.button_VisualizarDetalhes_Click);
            // 
            // button_ExportarCSV
            // 
            this.button_ExportarCSV.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportarCSV.Location = new System.Drawing.Point(599, 503);
            this.button_ExportarCSV.Name = "button_ExportarCSV";
            this.button_ExportarCSV.Size = new System.Drawing.Size(183, 39);
            this.button_ExportarCSV.TabIndex = 31;
            this.button_ExportarCSV.Text = "Exportar para CSV";
            this.button_ExportarCSV.UseVisualStyleBackColor = true;
            // 
            // label_Compras
            // 
            this.label_Compras.AutoSize = true;
            this.label_Compras.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Compras.Location = new System.Drawing.Point(334, 173);
            this.label_Compras.Name = "label_Compras";
            this.label_Compras.Size = new System.Drawing.Size(88, 24);
            this.label_Compras.TabIndex = 30;
            this.label_Compras.Text = "Compras:";
            // 
            // label_Orcamento
            // 
            this.label_Orcamento.AutoSize = true;
            this.label_Orcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Orcamento.Location = new System.Drawing.Point(904, 107);
            this.label_Orcamento.Name = "label_Orcamento";
            this.label_Orcamento.Size = new System.Drawing.Size(67, 20);
            this.label_Orcamento.TabIndex = 28;
            this.label_Orcamento.Text = "400.00€";
            this.label_Orcamento.Click += new System.EventHandler(this.label_Orcamento_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(334, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Orçamento Atual:";
            // 
            // label_NomeUsername
            // 
            this.label_NomeUsername.AutoSize = true;
            this.label_NomeUsername.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NomeUsername.Location = new System.Drawing.Point(330, 36);
            this.label_NomeUsername.Name = "label_NomeUsername";
            this.label_NomeUsername.Size = new System.Drawing.Size(356, 40);
            this.label_NomeUsername.TabIndex = 26;
            this.label_NomeUsername.Text = "Bem vindo, Username!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 40);
            this.label1.TabIndex = 25;
            this.label1.Text = "IShopping";
            // 
            // button_Estatisticas
            // 
            this.button_Estatisticas.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Estatisticas.Location = new System.Drawing.Point(41, 397);
            this.button_Estatisticas.Name = "button_Estatisticas";
            this.button_Estatisticas.Size = new System.Drawing.Size(198, 42);
            this.button_Estatisticas.TabIndex = 24;
            this.button_Estatisticas.Text = "Estatísticas";
            this.button_Estatisticas.UseVisualStyleBackColor = true;
            this.button_Estatisticas.Click += new System.EventHandler(this.button_Estatisticas_Click);
            // 
            // button_Compras
            // 
            this.button_Compras.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Compras.Location = new System.Drawing.Point(41, 322);
            this.button_Compras.Name = "button_Compras";
            this.button_Compras.Size = new System.Drawing.Size(198, 42);
            this.button_Compras.TabIndex = 23;
            this.button_Compras.Text = "Compras";
            this.button_Compras.UseVisualStyleBackColor = true;
            this.button_Compras.Click += new System.EventHandler(this.button_Compras_Click);
            // 
            // button_Artigos
            // 
            this.button_Artigos.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Artigos.Location = new System.Drawing.Point(41, 249);
            this.button_Artigos.Name = "button_Artigos";
            this.button_Artigos.Size = new System.Drawing.Size(198, 42);
            this.button_Artigos.TabIndex = 22;
            this.button_Artigos.Text = "Artigos";
            this.button_Artigos.UseVisualStyleBackColor = true;
            this.button_Artigos.Click += new System.EventHandler(this.button_Artigos_Click);
            // 
            // button_TipoArtigos
            // 
            this.button_TipoArtigos.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TipoArtigos.Location = new System.Drawing.Point(41, 178);
            this.button_TipoArtigos.Name = "button_TipoArtigos";
            this.button_TipoArtigos.Size = new System.Drawing.Size(198, 42);
            this.button_TipoArtigos.TabIndex = 21;
            this.button_TipoArtigos.Text = " Tipos de Artigos";
            this.button_TipoArtigos.UseVisualStyleBackColor = true;
            this.button_TipoArtigos.Click += new System.EventHandler(this.button_TipoArtigos_Click);
            // 
            // button_Orcamento
            // 
            this.button_Orcamento.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Orcamento.Location = new System.Drawing.Point(41, 107);
            this.button_Orcamento.Name = "button_Orcamento";
            this.button_Orcamento.Size = new System.Drawing.Size(198, 42);
            this.button_Orcamento.TabIndex = 20;
            this.button_Orcamento.Text = "Orçamento";
            this.button_Orcamento.UseVisualStyleBackColor = true;
            this.button_Orcamento.Click += new System.EventHandler(this.button_Orcamento_Click);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Todos",
            "Abertas",
            "Fechadas"});
            this.comboBoxEstado.Location = new System.Drawing.Point(788, 173);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(183, 24);
            this.comboBoxEstado.TabIndex = 37;
            this.comboBoxEstado.Text = "Selecione o estado";
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_Estado
            // 
            this.label_Estado.AutoSize = true;
            this.label_Estado.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Estado.Location = new System.Drawing.Point(729, 173);
            this.label_Estado.Name = "label_Estado";
            this.label_Estado.Size = new System.Drawing.Size(53, 19);
            this.label_Estado.TabIndex = 38;
            this.label_Estado.Text = "Estado:";
            // 
            // PaginaInicialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 575);
            this.Controls.Add(this.label_Estado);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.dataGridViewCompras);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Sair);
            this.Controls.Add(this.button_VisualizarDetalhes);
            this.Controls.Add(this.button_ExportarCSV);
            this.Controls.Add(this.label_Compras);
            this.Controls.Add(this.label_Orcamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_NomeUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Estatisticas);
            this.Controls.Add(this.button_Compras);
            this.Controls.Add(this.button_Artigos);
            this.Controls.Add(this.button_TipoArtigos);
            this.Controls.Add(this.button_Orcamento);
            this.Name = "PaginaInicialForm";
            this.Text = "PaginaInicial";
            this.Load += new System.EventHandler(this.PaginaInicialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Sair;
        private System.Windows.Forms.Button button_VisualizarDetalhes;
        private System.Windows.Forms.Button button_ExportarCSV;
        private System.Windows.Forms.Label label_Compras;
        private System.Windows.Forms.Label label_Orcamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_NomeUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Estatisticas;
        private System.Windows.Forms.Button button_Compras;
        private System.Windows.Forms.Button button_Artigos;
        private System.Windows.Forms.Button button_TipoArtigos;
        private System.Windows.Forms.Button button_Orcamento;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label_Estado;
    }
}
namespace iShopping_Abakos.View
{
    partial class VisualizarCompraForm
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
            this.label_Descricao_FormCompras = new System.Windows.Forms.Label();
            this.labelComprasVisualizar = new System.Windows.Forms.Label();
            this.dataGridViewItensCompra = new System.Windows.Forms.DataGridView();
            this.buttonAdicionarItemNaoP = new System.Windows.Forms.Button();
            this.buttonFecharCompra = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Descricao_FormCompras
            // 
            this.label_Descricao_FormCompras.AutoSize = true;
            this.label_Descricao_FormCompras.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Descricao_FormCompras.Location = new System.Drawing.Point(56, 102);
            this.label_Descricao_FormCompras.Name = "label_Descricao_FormCompras";
            this.label_Descricao_FormCompras.Size = new System.Drawing.Size(210, 24);
            this.label_Descricao_FormCompras.TabIndex = 3;
            this.label_Descricao_FormCompras.Text = "Nome da compra: -----\r\n";
            // 
            // labelComprasVisualizar
            // 
            this.labelComprasVisualizar.AutoSize = true;
            this.labelComprasVisualizar.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComprasVisualizar.Location = new System.Drawing.Point(51, 41);
            this.labelComprasVisualizar.Name = "labelComprasVisualizar";
            this.labelComprasVisualizar.Size = new System.Drawing.Size(359, 50);
            this.labelComprasVisualizar.TabIndex = 2;
            this.labelComprasVisualizar.Text = "Vizualizar Compra";
            // 
            // dataGridViewItensCompra
            // 
            this.dataGridViewItensCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItensCompra.Location = new System.Drawing.Point(60, 171);
            this.dataGridViewItensCompra.Name = "dataGridViewItensCompra";
            this.dataGridViewItensCompra.RowHeadersWidth = 51;
            this.dataGridViewItensCompra.RowTemplate.Height = 24;
            this.dataGridViewItensCompra.Size = new System.Drawing.Size(717, 309);
            this.dataGridViewItensCompra.TabIndex = 4;
            // 
            // buttonAdicionarItemNaoP
            // 
            this.buttonAdicionarItemNaoP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarItemNaoP.Location = new System.Drawing.Point(499, 504);
            this.buttonAdicionarItemNaoP.Name = "buttonAdicionarItemNaoP";
            this.buttonAdicionarItemNaoP.Size = new System.Drawing.Size(278, 35);
            this.buttonAdicionarItemNaoP.TabIndex = 5;
            this.buttonAdicionarItemNaoP.Text = "Adicionar Item Não Previsto";
            this.buttonAdicionarItemNaoP.UseVisualStyleBackColor = true;
            this.buttonAdicionarItemNaoP.Click += new System.EventHandler(this.buttonAdicionarItemNaoP_Click);
            // 
            // buttonFecharCompra
            // 
            this.buttonFecharCompra.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFecharCompra.Location = new System.Drawing.Point(499, 559);
            this.buttonFecharCompra.Name = "buttonFecharCompra";
            this.buttonFecharCompra.Size = new System.Drawing.Size(278, 35);
            this.buttonFecharCompra.TabIndex = 6;
            this.buttonFecharCompra.Text = "Fechar Compra";
            this.buttonFecharCompra.UseVisualStyleBackColor = true;
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoltar.Location = new System.Drawing.Point(651, 636);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(126, 31);
            this.buttonVoltar.TabIndex = 8;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista de Itens da Compra";
            // 
            // VisualizarCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 710);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonFecharCompra);
            this.Controls.Add(this.buttonAdicionarItemNaoP);
            this.Controls.Add(this.dataGridViewItensCompra);
            this.Controls.Add(this.label_Descricao_FormCompras);
            this.Controls.Add(this.labelComprasVisualizar);
            this.Name = "VisualizarCompraForm";
            this.Text = "VisualizarCompraForm";
            this.Load += new System.EventHandler(this.VisualizarCompraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Descricao_FormCompras;
        private System.Windows.Forms.Label labelComprasVisualizar;
        private System.Windows.Forms.DataGridView dataGridViewItensCompra;
        private System.Windows.Forms.Button buttonAdicionarItemNaoP;
        private System.Windows.Forms.Button buttonFecharCompra;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label label1;
    }
}
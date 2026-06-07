using iShopping_Abakos.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class ComprasForm : Form
    {
        public static DataGridView dataGridView;
        public static ComprasForm instance;
        public ComprasForm()
        {
            InitializeComponent();
            instance = this;
            dataGridView = dataGridView_Compras;
        }



        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.MostrarEstadoCompras(0, PaginaInicialForm.comprasPaginaPrincipal);
            ControllerCompras.VoltarPaginaPrincipal();
        }



        private void ComprasForm_Load(object sender, EventArgs e)
        {
            dataGridView_Compras.AutoGenerateColumns = true;
            dataGridView_Compras.RowHeadersWidth = 60;
            ControllerCompras.MostrarCompras(dataGridView_Compras);
            dataGridView_Compras.ClearSelection();
        }



        private void button_CriarCompra_Click(object sender, EventArgs e)
        {
            ControllerCompras.CriarCompra(textBox_Nome.Text.Trim(), textBox_Descricao.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerCompras.MostrarCompras(dataGridView_Compras);
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }



        private void button_AlterarInfo_Click(object sender, EventArgs e) // botão para alterar informações de compra
        {
            ControllerCompras.EditarInformacoesCompra(textBox_ID.Text.Trim(), textBox_Nome.Text.Trim(), textBox_Descricao.Text.Trim(), out string mensagem);
            MessageBox.Show(mensagem);
            ControllerCompras.MostrarCompras(dataGridView_Compras);
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }



        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            ControllerCompras.EliminarCompra(textBox_ID.Text.Trim(), out string mensagem); 
            MessageBox.Show(mensagem);
            ControllerCompras.MostrarCompras(dataGridView_Compras);
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }



        private void button_AdicionarItem_Click(object sender, EventArgs e)
        {
            Compra compra = ControllerCompras.DevolverCompra(textBox_ID.Text.Trim(), out string mensagem);

            if (!string.IsNullOrEmpty(mensagem))
            MessageBox.Show(mensagem);
            
            ControllerAdicionarItensPrevistos.AbrirAdicionarItensPrevistosForm(compra);
            ControllerCompras.LimparCampos(textBox_Nome, textBox_Descricao, textBox_ID, dataGridView_Compras);
        }
    }
}

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
            string nomeCompra = textBox_Nome.Text.Trim();
            string descricao  = textBox_Descricao.Text.Trim();
            string mensagem;

            ControllerCompras.CriarCompra(nomeCompra, descricao, out mensagem);
            MessageBox.Show(mensagem);
            ControllerCompras.MostrarCompras(dataGridView_Compras);

        }

        private void button_AlterarInfo_Click(object sender, EventArgs e) // botão para alterar informações de compra
        {
            string id = textBox_ID.Text.Trim();
            string nomeCompra = textBox_Nome.Text.Trim();
            string descricao = textBox_Descricao.Text.Trim();
            string mensagem;

            ControllerCompras.EditarInformacoesCompra(id, nomeCompra, descricao, out mensagem);
            MessageBox.Show(mensagem);
            ControllerCompras.MostrarCompras(dataGridView_Compras);

        }


        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            string id = textBox_ID.Text.Trim();
            string mensagem;

            ControllerCompras.EliminarCompra(id, out mensagem); 
            MessageBox.Show(mensagem);
            ControllerCompras.MostrarCompras(dataGridView_Compras);
        }

        private void button_AdicionarItem_Click(object sender, EventArgs e)
        {

            Compra compra = ControllerCompras.DevolverCompra(textBox_ID.Text.Trim());
            ControllerAdicionarItensPrevistos.AbrirAdicionarItensPrevistosForm(compra);

        }
    }
}

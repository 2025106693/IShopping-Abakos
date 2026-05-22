using iShopping_Abakos.Controller;
using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos
{
    public partial class PaginaInicialForm : Form
    {
        public PaginaInicialForm()
        {
            InitializeComponent();

            Orcamento orcamento = ControllerPaginaInicial.MostrarOrcamento();
            label_Orcamento.Text = orcamento.Valor.ToString();
            label_NomeUsername.Text = "Bem vindo, " + Sessao.UtilizadorAtual + "!";
        }

        private void PaginaInicialForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Orcamento_Click(object sender, EventArgs e)
        {
            ControllerPaginaInicial.AbrirFormOrcamentos();
        }

        private void label_Orcamento_Click(object sender, EventArgs e)
        {


            

        }
    }
}

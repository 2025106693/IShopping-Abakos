using iShopping_Abakos.Controller;
using iShopping_Abakos.Model;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos.View
{
    public partial class EstatisticasForm : Form
    {
        //DataGridView utilizada para apresentar o histórico de orçamentos
        public static DataGridView historicoOrcamentos;

        //DataGridView utilizada para apresentar as estatísticas dos Itens
        public static DataGridView ListagemPercentagem;

        //Instância do formulário para acesso a partir de outras classes
        public static EstatisticasForm instance;
        public EstatisticasForm()
        {
            InitializeComponent();

            //Guarda a instância atual do formulário
            instance = this;

            //Associa os componentes gráficos às variáveis estáticas
            historicoOrcamentos = dataGridView_Orcamentos;
            ListagemPercentagem = dataGridView_EstatisticasCompras;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            //Regressa à página principal
            ControllerEstatisticas.VoltarPaginaPrincipal();
        }

        private void button_GerarEstatisticasOrcamento_Click(object sender, EventArgs e)
        {
            //// Variável que irá armazenar a mensagem devolvida pelo controlador
            string mensagem;

            //Gera uma sugestão de orçamento com base nos últimos 6 meses
            SugestaoOrcamento sugestao = ControllerEstatisticas.SugerirOrcamento(out mensagem);
            
            //Mostra a mensagem do resultado da operação ao utilizador
            MessageBox.Show(mensagem);

            //Mostra a média dos últimos meses utilizados no cálculo
            label_Sugestao.Text = sugestao.SugestaoProximoMes.ToString("F2");
            label_Media.Text = "Média dos últimos meses (baseado até aos últimos 6):\n" +
                                   
                                sugestao.MediaUltimosMeses.ToString("F2");
        }

        private void EstatisticasForm_Load(object sender, EventArgs e)
        {
            //Carrega o histórico de orçamentos para a DataGridView
            ControllerEstatisticas.MostrarHistoricoOrcamento();

            //Carrega as estatísticas dos artigos para o DataGridView
            ControllerEstatisticas.MostrarEstatisticasArtigos();

        }
    }
}

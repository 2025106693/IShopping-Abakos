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

namespace iShopping_Abakos.View
{
    public partial class EstatisticasForm : Form
    {
        public static DataGridView historicoOrcamentos;
        public static DataGridView ListagemPercentagem;

        public static EstatisticasForm instance;
        public EstatisticasForm()
        {
            InitializeComponent();
            instance = this;
            historicoOrcamentos = dataGridView_Orcamentos;
            ListagemPercentagem = dataGridView_EstatisticasCompras;
        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            ControllerEstatisticas.VoltarPaginaPrincipal();
        }

        private void button_GerarEstatisticasOrcamento_Click(object sender, EventArgs e)
        {
            SugestaoOrcamento sugestao = ControllerEstatisticas.SugerirOrcamento();

            label_Sugestao.Text = sugestao.SugestaoProximoMes.ToString("F2");
            label_Media.Text = "Média dos últimos meses (baseado até aos últimos 6):\n" +
                                   
                                sugestao.MediaUltimosMeses.ToString("F2");
        }

        private void EstatisticasForm_Load(object sender, EventArgs e)
        {
            ControllerEstatisticas.MostrarHistoricoOrcamento();
            ControllerEstatisticas.MostrarEstatisticasArtigos();

        }

        private void button_ExportarEstatisticas_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Ficheiros CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Guardar Estatísticas";
            saveFileDialog.FileName = "Estatisticas.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ControllerEstatisticas.ExportarEstatisticasCsv(saveFileDialog.FileName);

                MessageBox.Show(
                    "Estatísticas exportadas com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}

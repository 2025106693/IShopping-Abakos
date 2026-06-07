using iShopping_Abakos.Controller;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Inicializa os componentes gráficos do formulário
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            //Variável que irá armazenar a mensagem resultante  da autenticação
            string mensagem;

            //Tenta autenticar o utilizador com as credenciais introduzidas
            bool ok = Form1Controller.Autenticar(
                textBox_Username.Text.Trim(),
                textBox_Password.Text,
                out mensagem);

            //Apresenta ao utilizador o resultado da autenticação
            MessageBox.Show(mensagem);

            //Caso a autenticação tenha sido bem sucedida abre o formulário da página principal
            //e fecha o do login
            if(ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }



        private void button_Sair_Click(object sender, EventArgs e)
        {
            //Fecha o formulário
            this.Close();
        }
    }
}

using iShopping_Abakos.Controller;
using System;
using System.Windows.Forms;

namespace iShopping_Abakos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            string mensagem;

            bool ok = Form1Controller.Autenticar(
                textBox_Username.Text.Trim(),
                textBox_Password.Text,
                out mensagem);

            MessageBox.Show(mensagem);

            if(ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }



        private void button_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

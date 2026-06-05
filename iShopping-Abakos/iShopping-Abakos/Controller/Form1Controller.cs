using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Controller
{
    //Controlador responsável pela autenticação do utilizador

    internal class Form1Controller
    {
        //Valida as credenciais introduzidas pelo utilizador.
        //parâmetro login : input da textbox do username
        //parâmetro password : input da textbox da password
        //parâmetro mensagem : mensagem de resultado da autenticação 
        public static bool Autenticar (string login, string password, 
            out string mensagem)
        {
            mensagem = "";

            //Verifica se os campos obrigatórios foram preenchidos
            if(login.Trim() == "" || password.Trim() == "")
            {
                mensagem = "Deve introduzir o login e a password";
                return false;
            }

            //Cria a ligação à base de dados
            using (IShoppingContext db = new IShoppingContext())
            {
                //procura um utilizador com o login e passwords 
                //iguais aos inputs
                Utilizador utilizador = db.DBUtilizadores
                    .FirstOrDefault(u => u.Username == login
                    && u.Password == password);

                //caso não exista nenhum utilizador válido
                if(utilizador == null)
                {
                    mensagem = "Login ou password incorretos.";
                    return false;
                }

                else
                {
                    //Guarda o utilizador autenticado na sessão atual
                    Sessao.UtilizadorAtual = utilizador.Username;
                    mensagem = "Autenticação efetuada com sucesso.";
                    return true;
                }


            }
        }
    }
}

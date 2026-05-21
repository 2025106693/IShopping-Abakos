using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Controller
{
    internal class Form1Controller
    {
        public static bool Autenticar (string login, string password, 
            out string mensagem)
        {
            mensagem = "";
            if(login.Trim() == "" || password.Trim() == "")
            {
                mensagem = "Deve introduzir o login e a password";
                return false;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                Utilizador utilizador = db.DBUtilizadores
                    .FirstOrDefault(u => u.Username == login
                    && u.Password == password);

                if(utilizador == null)
                {
                    mensagem = "Login ou password incorretos.";
                    return false;
                }

                Sessao.UtilizadorAtual = utilizador.Username;
                mensagem = "Autenticação efetuada com sucesso.";
                return true;

            }
        }
    }
}

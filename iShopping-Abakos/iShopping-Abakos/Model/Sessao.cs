using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    //Classe responsável por armazenar informação da sessão atual (utilizador)
    internal class Sessao
    {
        // guarda o nome do utilizador que efetuou login
        // e que está a usar a aplicação
        public static string UtilizadorAtual { get; set; }
    }
}

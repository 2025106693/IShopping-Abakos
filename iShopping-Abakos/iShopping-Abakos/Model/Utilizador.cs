using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace iShopping_Abakos
{
    // como os utilizadores são pré-definidos adicionamos esta linha de código
    [Table("DBUtilizadores")]
    internal class Utilizador
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace iShopping_Abakos
{
    // [Table] --> Mapeia a entidade Utilizador para a tabela DBUtilizadores
    // onde se encontram armazenados utilizadores previamente inseridos através do Seed

    [Table("DBUtilizadores")]
    internal class Utilizador
    {
        //Identificador único do Utilizador
        public int Id { get; set; }

        //Username definido para o Utilizador
        public string Username { get; set; }

        //Password que permite o login (sem encriptação)
        public string Password { get; set; }

    }
}

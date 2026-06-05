using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{

    //Representa o contexto da base de dados da aplicação,
    //permitindo o acesso e a gestão das entidades através do Entity Framework
    
    
    internal class IShoppingContext : DbContext
    {
        //Inicializa o contexto utilizando a connection string IShoppingContext
        public IShoppingContext() : base("IShoppingContext"){ }
        
        //Tabela de Utilizadores
        public DbSet<Utilizador> DBUtilizadores {  get; set; }

        //Tabela de Orçamentos
        public DbSet<Orcamento> DBOrcamentos { get; set; }

        //Tabela de Compras
        public DbSet<Compra> DBCompras { get; set; }

        //Tabela de Artigos
        public DbSet<Artigo> DBArtigos { get; set; }

        //Tabela de Tipos de Artigos
        public DbSet<TipoArtigo> DBTipoArtigos { get; set; }

        //Tabela de Itens de Compra (podendo ser do tipo itensprevistos ou não previstos)
        public DbSet <ItemCompra> DBItensCompra { get; set; }
  
    }
}

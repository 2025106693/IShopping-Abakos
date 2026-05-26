using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    internal class IShoppingContext : DbContext
    {
        public IShoppingContext() : base("IShoppingContext"){ }

        public DbSet<Utilizador> DBUtilizadores {  get; set; }
        public DbSet<Orcamento> DBOrcamentos { get; set; }
        public DbSet<Compra> DBCompras { get; set; }
        public DbSet<Artigo> DBArtigos { get; set; }
        public DbSet<TipoArtigo> DBTipoArtigos { get; set; }
        public DbSet <ItemCompra> DBItensCompra { get; set; }

    }
}

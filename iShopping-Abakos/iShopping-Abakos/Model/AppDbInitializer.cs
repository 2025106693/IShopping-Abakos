using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace iShopping_Abakos.Model
{

    // Apaga os residuos e cria uma nova DB
    internal class AppDbInitializer : DropCreateDatabaseIfModelChanges<IShoppingContext>
    {
        protected override void Seed(IShoppingContext context)
        {
            // utilizadores

            context.DBUtilizadores.Add(new Utilizador
            {
                Username = "andre",
                Password = "1234"
            });

            context.DBUtilizadores.Add(new Utilizador
            {
                Username = "filipe",
                Password = "1234"
            });

            context.DBUtilizadores.Add(new Utilizador
            {
                Username = "mariana",
                Password = "1234"
            });


            // Tipos de artigo

            context.DBTipoArtigos.Add(new TipoArtigo
            {
                Nome = "Higiene",
                Descricao = "Artigos higiene e cuidado pessoal"
            });

            context.DBTipoArtigos.Add(new TipoArtigo
            {
                Nome = "Alimentação",
                Descricao = "Produtos alimentares e bebidas"
            });

            context.DBTipoArtigos.Add(new TipoArtigo
            {
                Nome = "Limpeza",
                Descricao = "Artigos de limpeza"
            });

            context.DBTipoArtigos.Add(new TipoArtigo
            {
                Nome = "Saúde",
                Descricao = "Produtos farmacêuticos e de bem-estar"
            });

            context.DBTipoArtigos.Add(new TipoArtigo
            {
                Nome = "Roupa",
                Descricao = "Vestuário"
            });

            context.DBTipoArtigos.Add(new TipoArtigo
            {
                Nome = "Acessórios",
                Descricao = "Carteiras, joias, cintos, relógios..."
            });



            context.SaveChanges();
            base.Seed(context);
        }
    }
}

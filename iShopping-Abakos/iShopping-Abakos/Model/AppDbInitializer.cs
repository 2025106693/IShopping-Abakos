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

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

using iShopping_Abakos;
using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Database.SetInitializer(new AppDbInitializer());
            using (IShoppingContext db = new IShoppingContext())
            {
                db.Database.Initialize(false);
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Form1 login = new Form1())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
                //ApplicationConfiguration.Initialize();
                //Application.Run(new Form1());
            }

        }
    }
}

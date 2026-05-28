using iShopping_Abakos.Model;
using iShopping_Abakos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping_Abakos.Controller
{
    internal class ControllerAdicionarItensPrevistos
    {
        public static void AbrirAdicionarItensPrevistosForm()
        {
            ComprasForm.instance.Hide();
            AdicionarItensPrevistosForm form = new AdicionarItensPrevistosForm();
            form.ShowDialog();
            
        }

        public static void AdicionarItemPrevisto(int tipoArtigo, int Artigo, int quantidade, out string message)
        {
            message = ""; 


            
        }

        public static void CarregarTiposArtigo(ComboBox comboBox)
        {
            using (IShoppingContext db = new IShoppingContext())
            {

                var tiposArtigo = db.DBTipoArtigos
                              .OrderBy(t => t.Id).ToList();

                comboBox.DataSource = tiposArtigo;
                comboBox.DisplayMember = "Nome";  // o que o utilizador vê
                comboBox.ValueMember = "Id";// valor associado fica escondigo
            }
        }

        public static void CarregarArtigos(ComboBox comboBox, int tipoArtigoSelecionado)
        {

            using (IShoppingContext db = new IShoppingContext())
            {

                var artigo = db.DBArtigos
                              .Where(t => t.TipoArtigoId == tipoArtigoSelecionado)
                              .OrderBy(t => t.Nome).
                              ToList();

                comboBox.DataSource = artigo;
                comboBox.DisplayMember = "Nome";  // o que o utilizador vê
                comboBox.ValueMember = "Id";// valor associado fica escondigo
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    [Table("DBItensNaoPrevistos")]
    internal class ItemNaoPrevisto : ItemCompra
    {
        public string Descricao { get; set; }

    }


}

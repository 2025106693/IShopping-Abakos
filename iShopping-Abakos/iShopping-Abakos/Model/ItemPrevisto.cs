using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos.Model
{
    [Table("DBItensPrevistos")]
    internal class ItemPrevisto : ItemCompra
    {
        public int QuantPrevista { get; set; }

    }
}

using iShopping_Abakos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping_Abakos
{
    internal class Compra
    {
        //PK
        public int Id { get; set; }

        public string NomeCompra { get; set; }

        // FK
        public int IdCriadoPor { get; set; }
        public int? IdAlteradoPor { get; set; }

        public int? IdFechadoPor { get; set; }
        
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFecho { get; set; }
        public bool Fechado { get; set; }
        
        public decimal TotalGasto { get; set; }

        public ICollection<ItemCompra> ItensCompras { get; set; }


        
    }

}

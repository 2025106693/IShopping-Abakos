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

        public string Descricao { get; set; }

        // FK
        public string CriadoPor { get; set; }
        public string AlteradoPor { get; set; }

        public string FechadoPor { get; set; }
        
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFecho { get; set; }
        public bool Fechado { get; set; }
        
        public decimal TotalGasto { get; set; }

        public decimal TotalPrevisto { get; set; }

        public virtual ICollection<ItemCompra> ItensCompra { get; set; } 
       

        public Compra()
        {
            ItensCompra = new List<ItemCompra>();
        }        
    }
}

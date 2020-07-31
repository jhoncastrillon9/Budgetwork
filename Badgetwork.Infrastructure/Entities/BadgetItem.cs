using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badgetwork.Infrastructure.Entities
{
    [Table("BadgetItem", Schema = "Badgets")]
    public class BadgetItem
    {
        [Key]
        public int BadgetItemId { get; set; }
        [ForeignKey("BadgetId")]
        public int BadgetId { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        public string Descripcion { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal Subtotal { get; set; }

        public virtual Badget Badget { get; set; }

    }
}

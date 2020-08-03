using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badgetwork.Infrastructure.Entities
{
    [Table("UnitaryPrice", Schema = "Aup")]
    public class UnitaryPrice
    {
        [Key]
        public int UnitaryPriceId { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        public string Chapter { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo de 500 caracteres")]
        public string Item { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Measure { get; set; }
        public decimal Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int CompanyId { get; set; } 
    }
}

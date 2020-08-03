using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badgetwork.Infrastructure.Entities
{
    [Table("Badget", Schema = "Badgets")]
    public class Badget
    {
        [Key]
        public int BadgetId { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string BadgetName { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string CustomerName { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string TypeDocument { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Document { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Address { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal Total { get; set; }
        public DateTime DateCreation { get; set; }
        public int CompanyId { get; set; }
        public virtual ICollection<BadgetItem> BadgetItems { get; set; }
    }
}

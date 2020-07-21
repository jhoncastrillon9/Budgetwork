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
        public string Name { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreation { get; set; }        
    }
}

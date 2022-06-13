using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class BasketDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//Bir bir arttırmayı engelliyor.
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}

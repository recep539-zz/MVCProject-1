using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class FatDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//Bir bir arttırmayı engelliyor.
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string WhoUpdated { get; set; }
        [ForeignKey("Id")]
        public FatMaster FatMaster { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public bool Deleted { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Models {
    public class Product {

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public long Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, ForeignKey("ProductId")]
        public IList<ImagePath> Images { get; set; } = new List<ImagePath>();

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public Product() {
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}

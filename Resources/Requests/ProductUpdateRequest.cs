using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class ProductUpdateRequest {

        [Required]
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public long Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class ProductSaveRequest {

        [Required]
        public string ProductName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public long Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, MaxLength(5)]
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        [Required]
        public Guid CategoryId { get; set; }
    }
}

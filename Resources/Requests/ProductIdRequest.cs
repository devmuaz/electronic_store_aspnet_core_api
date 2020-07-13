using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class ProductIdRequest {

        [Required]
        public Guid ProductId { get; set; }
    }
}

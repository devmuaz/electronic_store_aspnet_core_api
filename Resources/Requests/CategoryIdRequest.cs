using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources {
    public class CategoryIdRequest {

        [Required]
        public Guid Id { get; set; }
    }
}

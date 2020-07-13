using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class CategoryUpdateRequest {

        [Required]
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}

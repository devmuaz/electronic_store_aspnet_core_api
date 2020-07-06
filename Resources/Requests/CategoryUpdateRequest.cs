using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Resources.Requests {
    public class CategoryUpdateRequest {

        [Required]
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}

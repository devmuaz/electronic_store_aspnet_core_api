using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Resources {
    public class CategorySaveRequest {

        [Required]
        public string CategoryName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }
    }
}

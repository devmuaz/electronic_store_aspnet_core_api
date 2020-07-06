using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Resources.Requests {
    public class ProductIdRequest {

        [Required]
        public Guid ProductId { get; set; }
    }
}

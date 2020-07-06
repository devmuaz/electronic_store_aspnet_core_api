using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Models {
    public class ImagePath {

        [Key]
        public string Filename { get; set; }
    }
}

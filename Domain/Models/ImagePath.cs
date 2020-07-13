using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Domain.Models {
    public class ImagePath {

        [Key]
        public string Filename { get; set; }
    }
}

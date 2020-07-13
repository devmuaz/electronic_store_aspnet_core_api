using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources {
    public class CategorySaveRequest {

        [Required]
        public string CategoryName { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }
    }
}

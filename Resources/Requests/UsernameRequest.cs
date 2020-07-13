using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class UsernameRequest {

        [Required]
        public string username { get; set; }
    }
}

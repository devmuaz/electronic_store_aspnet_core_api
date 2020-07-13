using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class UserSignInRequest {

        [Required, RegularExpression(@"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$")]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}

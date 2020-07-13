using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class UserSignUpRequest {

        [Required, RegularExpression(@"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$")]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public IFormFile AvatarImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public UserSignUpRequest() {
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}

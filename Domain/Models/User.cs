using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicsStore.Domain.Models {
    public class User {

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required, RegularExpression(@"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$")]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string AvatarImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public User() {
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}

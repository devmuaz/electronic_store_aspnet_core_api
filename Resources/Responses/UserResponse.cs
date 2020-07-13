using System;

namespace ElectronicsStore.Resources.Responses {
    public class UserResponse {

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string AvatarImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

using ElectronicsStore.Resources.Responses;

namespace ElectronicsStore.Domain.Services.Communication {

    public class AuthStatusResponse {

        public bool Status { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }

        public UserResponse User { get; set; }
    }
}

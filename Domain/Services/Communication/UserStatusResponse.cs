using ElectronicsStore.Domain.Models;

namespace ElectronicsStore.Domain.Services.Communication {
    public class UserStatusResponse : BaseStatusResponse<User> {

        public UserStatusResponse(User user) : base(user) { }

        public UserStatusResponse(string Message) : base(Message) { }
    }
}

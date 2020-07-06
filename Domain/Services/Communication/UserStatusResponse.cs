using ElectronicsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services.Communication {
    public class UserStatusResponse : BaseStatusResponse<User> {

        public UserStatusResponse(User user) : base(user) { }

        public UserStatusResponse(string Message) : base(Message) { }
    }
}

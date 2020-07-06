using ElectronicsStore.Domain.Models;
using ElectronicsStore.Resources;
using ElectronicsStore.Resources.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services.Communication {

    public class AuthStatusResponse {

        public bool Status { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }

        public UserResponse User { get; set; }
    }
}

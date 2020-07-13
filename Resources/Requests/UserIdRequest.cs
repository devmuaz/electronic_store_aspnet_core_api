using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsStore.Resources.Requests {
    public class UserIdRequest {

        [Required]
        public Guid userId { get; set; }
    }
}

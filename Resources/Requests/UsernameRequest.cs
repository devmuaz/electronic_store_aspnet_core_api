using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Resources.Requests {
    public class UsernameRequest {

        [Required]
        public string username { get; set; }
    }
}

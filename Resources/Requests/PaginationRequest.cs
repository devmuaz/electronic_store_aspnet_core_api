using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Resources.Requests {
    public class PaginationRequest {

        public int startIndex { get; set; }

        public int perPage { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ElectronicsStore.Resources.Responses {
    public class ProductResponse {

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public int Quantity { get; set; }

        public List<string> Images { get; set; }

        public CategoryResponse Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

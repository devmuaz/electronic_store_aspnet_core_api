using System;

namespace ElectronicsStore.Resources {
    public class CategoryResponse {

        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}

using ElectronicsStore.Domain.Models;

namespace ElectronicsStore.Domain.Services.Communication {
    public class ProductStatusResponse : BaseStatusResponse<Product> {

        public ProductStatusResponse(Product product) : base(product) { }

        public ProductStatusResponse(string Message) : base(Message) { }
    }
}

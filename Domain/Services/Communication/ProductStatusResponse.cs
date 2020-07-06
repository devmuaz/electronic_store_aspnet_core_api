using ElectronicsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services.Communication {
    public class ProductStatusResponse : BaseStatusResponse<Product> {

        public ProductStatusResponse(Product product) : base(product) { }

        public ProductStatusResponse(string Message) : base(Message) { }
    }
}

using ElectronicsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services.Communication {
    public class CategoryStatusResponse : BaseStatusResponse<Category> {

        public CategoryStatusResponse(Category category) : base(category) { }

        public CategoryStatusResponse(string Message) : base(Message) { }
    }
}

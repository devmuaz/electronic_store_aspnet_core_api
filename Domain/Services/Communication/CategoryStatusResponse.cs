using ElectronicsStore.Domain.Models;

namespace ElectronicsStore.Domain.Services.Communication {
    public class CategoryStatusResponse : BaseStatusResponse<Category> {

        public CategoryStatusResponse(Category category) : base(category) { }

        public CategoryStatusResponse(string Message) : base(Message) { }
    }
}

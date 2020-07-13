using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ElectronicsStore.System {
    public interface IFileService {

        public Task<string> StoreImage(string folderName, IFormFile file);
    }
}

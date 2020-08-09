using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ElectronicsStore.System {
    public class FileService : IFileService {

        private readonly IWebHostEnvironment environment;

        public FileService(IWebHostEnvironment environment) {
            this.environment = environment;
        }

        public async Task<string> StoreImage(string folderName, IFormFile file) {
            string filename = SetUniqueFilename(file);
            string path = Path.Combine(environment.WebRootPath, folderName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, filename);
            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return filename;
        }

        private string SetUniqueFilename(IFormFile file) {
            return Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        }
    }
}

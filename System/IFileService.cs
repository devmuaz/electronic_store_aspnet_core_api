using ElectronicsStore.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.System {
    public interface IFileService {

        public Task<string> StoreImage(string folderName, IFormFile file);
    }
}

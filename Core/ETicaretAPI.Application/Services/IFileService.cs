using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
        Task<string> FİleRenameAsync(string fileName);
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}

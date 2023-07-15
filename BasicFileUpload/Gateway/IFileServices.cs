using BasicFileUpload.Models;

namespace BasicFileUpload.Gateway;

public interface IFileServices
{
    Task<FileModel> GetFilesAsync(IFormFile file);
}

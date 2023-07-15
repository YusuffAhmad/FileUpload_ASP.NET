using BasicFileUpload.Models;

namespace BasicFileUpload.Gateway;

public class FileServices : IFileServices
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileServices(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<FileModel> GetFilesAsync(IFormFile file)
    {
        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

        if (file != null && filePath != null)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileName = Guid.NewGuid().ToString().Replace('-', 's') + Path.GetExtension(file.FileName);
            var file1 = file.FileName;
            var file2 = file.ContentType;
            var file3 = file.Length;
            var originalpath = Path.GetFileName(file.FileName);
            var fullPath = Path.Combine(filePath, fileName);
            var fileExtension = Path.GetExtension(file.FileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileDetails = new FileModel
            {
                Name = fileName,
                CreatedOn = DateTime.Now,
                Extension = fileExtension,
            };

            using (var dataStream = new MemoryStream())
            {
                await file.CopyToAsync(dataStream);
                fileDetails.FileStream = dataStream.ToArray();
            }

            return fileDetails;
        }
        return null;
    }
}

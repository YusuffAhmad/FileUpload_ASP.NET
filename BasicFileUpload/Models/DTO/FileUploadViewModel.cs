namespace BasicFileUpload.Models.DTO;

public class FileUploadViewModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public List<IFormFile> Files { get; set; }

}

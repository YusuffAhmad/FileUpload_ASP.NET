namespace BasicFileUpload.Models;

public class FileModel : BaseEntity
{
    public string Name { get; set; }
    public string FileType { get; set; }
    public string Extension { get; set; }
    public IFormFile File{ get; set; }
    public byte[] FileStream { get; set; }
    public string UploadedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
}

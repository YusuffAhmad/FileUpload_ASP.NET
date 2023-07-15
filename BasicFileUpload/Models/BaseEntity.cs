namespace BasicFileUpload.Models;

public abstract class BaseEntity
{
    public string Id { get; set; } = Ulid.NewUlid().ToString();
    // var t = new Ulid(Guid.Empty);

}

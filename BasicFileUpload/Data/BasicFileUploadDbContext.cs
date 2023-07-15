using BasicFileUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicFileUpload.Data;

public class BasicFileUploadDbContext : DbContext
{
    public BasicFileUploadDbContext(DbContextOptions<BasicFileUploadDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<FileModel> FileModels{ get; set; }
}

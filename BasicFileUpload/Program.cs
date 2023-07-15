using BasicFileUpload.Data;
using BasicFileUpload.Gateway;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration.GetConnectionString("BasicFileUpload");
builder.Services.AddDbContext<BasicFileUploadDbContext>(options => options.UseSqlServer(configuration));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileServices, FileServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

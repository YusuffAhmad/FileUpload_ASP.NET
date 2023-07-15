using System.Diagnostics;
using BasicFileUpload.Data;
using BasicFileUpload.Gateway;
using BasicFileUpload.Migrations;
using BasicFileUpload.Models;
using BasicFileUpload.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BasicFileUpload.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFileServices _fileServices;
    private readonly BasicFileUploadDbContext _context;
    public HomeController(ILogger<HomeController> logger, IFileServices fileServices, BasicFileUploadDbContext context)
    {
        _logger = logger;
        _fileServices = fileServices;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(FileUploadViewModel fileUploadViewModel)
    {
        foreach (var item in fileUploadViewModel.Files)
        {
            var response = await _fileServices.GetFilesAsync(item);
        }

        return View();
    }


    [HttpGet]
    public IActionResult Privacy(int id)
    {
        var file = GetFileDetails(id);

        if (file == null)
        {
            return NotFound(); // File not found
        }

        return View(file);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private FileModel GetFileDetails(int id)
    {
        // Retrieve the file from the database based on the provided ID
        var file = _context.FileModels.Find(id);

        return file;
    }
}

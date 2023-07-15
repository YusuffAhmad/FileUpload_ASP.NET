using System.Diagnostics;
using BasicFileUpload.Gateway;
using BasicFileUpload.Models;
using BasicFileUpload.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BasicFileUpload.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFileServices _fileServices;
    public HomeController(ILogger<HomeController> logger, IFileServices fileServices)
    {
        _logger = logger;
        _fileServices = fileServices;
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using AutoDealer.Interfaces;
using AutoDealer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    public class ImageController : Controller
    {
        private readonly IimagesService _imagesService;
        private readonly AppDataContext _context;

        public ImageController(IimagesService imagesService, AppDataContext context)
        {
            _imagesService = imagesService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var galleryItems = await _imagesService.GetAllImageItemsAsync();
            return View(galleryItems);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imageFile, string title, string description)
        {
            if (ModelState.IsValid)
            {
                await _imagesService.UploadImageAsync(imageFile, title, description);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

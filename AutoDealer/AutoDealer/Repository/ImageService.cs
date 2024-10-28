using AutoDealer.Interfaces;
using AutoDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Repository
{
    public class ImageService : IimagesService
    {
        private readonly AppDataContext _context;

        public ImageService(AppDataContext context)
        {
            _context = context;
        }
        public async Task<List<Photo>> GetAllImageItemsAsync()
        {
            return await _context.Kenneth_Cars.ToListAsync();
        }

        public async Task<Photo> UploadImageAsync(IFormFile imageFile, string title, string description)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid image file");
            }

            Photo image;
            using(var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);

                image = new Photo
                {
                    Title = title,
                    Description = description,
                    ImageMimeType = imageFile.ContentType,
                    ImageData = memoryStream.ToArray()

                };
                await _context.Kenneth_Cars.AddAsync(image);
                await _context.SaveChangesAsync();
                
            }
            return image;
        }
    }
}

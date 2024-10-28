using AutoDealer.Models;

namespace AutoDealer.Interfaces
{
    public interface IimagesService
    {
        Task<Photo> UploadImageAsync(IFormFile imageFile, string title, string description);
        Task<List<Photo>> GetAllImageItemsAsync();
    }
}

using CloudinaryDotNet.Actions;

namespace TurboGateTickets.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhoto(IFormFile file);
        Task<DeletionResult> DeletePhoto(string publicId);

    }
}

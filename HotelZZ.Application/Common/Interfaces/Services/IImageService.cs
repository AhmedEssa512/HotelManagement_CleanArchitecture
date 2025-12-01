using HotelZZ.Application.Common.Files.Models;
using HotelZZ.Application.Common.Models;

namespace HotelZZ.Application.Common.Interfaces.Services
{
    public interface IImageService
    {
        Task<Result<ImageUploadInfo>> UploadAsync(Stream stream, string fileName,string folderName ,CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(string publicId);
    }
}
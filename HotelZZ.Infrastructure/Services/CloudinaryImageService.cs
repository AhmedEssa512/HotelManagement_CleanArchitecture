using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HotelZZ.Application.Common.Files.Models;
using HotelZZ.Application.Common.Interfaces.Services;
using HotelZZ.Application.Common.Models;

namespace HotelZZ.Infrastructure.Services
{
    public class CloudinaryImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryImageService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }


        public async Task<Result<ImageUploadInfo>> UploadAsync(Stream stream, string fileName, string folderName, CancellationToken cancellationToken = default)
        {
                try
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(fileName, stream),
                        Folder = folderName
                    };

                    var result = await _cloudinary.UploadAsync(uploadParams, cancellationToken);

                    if (result.StatusCode != System.Net.HttpStatusCode.OK)
                        return Result<ImageUploadInfo>.Failure(result.Error?.Message ?? "Upload failed");

                    return Result<ImageUploadInfo>.Success(
                        new ImageUploadInfo(result.SecureUrl.ToString(), result.PublicId)
                    );
                }
                catch (Exception ex)
                {
                    return Result<ImageUploadInfo>.Failure(ex.Message);
                }
        }

        public async Task<Result> DeleteAsync(string publicId)
        {
                try
                {
                    var result = await _cloudinary.DestroyAsync(new DeletionParams(publicId));

                    if (result.StatusCode != System.Net.HttpStatusCode.OK)
                        return Result.Failure(result.Error?.Message ?? "Delete failed");

                    return Result.Success();
                }
                catch (Exception ex)
                {
                    return Result.Failure(ex.Message);
                }
        }
    }
}
using FluentValidation;

namespace HotelZZ.Application.Common.Files.Validators
{
    public class ImageValidator : AbstractValidator<IImage>
    {
        private static readonly HashSet<string> AllowedContentTypes = new()
        {
            "image/jpeg",
            "image/png",
            "image/webp"
        };

        private static readonly HashSet<string> AllowedExtensions = new()
        {
            ".jpg", ".jpeg", ".png", ".webp"
        };

        public ImageValidator()
        {
            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("Image file name is required.")
                .Must(HaveValidExtension)
                .WithMessage("Invalid file extension. Only JPG, PNG, WEBP are allowed.");

            RuleFor(x => x.ContentType)
                .Must(ct => AllowedContentTypes.Contains(ct))
                .WithMessage("Invalid image type. Only JPG, PNG, WEBP are allowed.");

            RuleFor(x => x)
                .Must(HaveValidSize)
                .WithMessage("Image size must not exceed 5 MB.");
        }

        private bool HaveValidExtension(string fileName)
        {
            return Path.GetExtension(fileName)?.ToLower() is string ext
                && AllowedExtensions.Contains(ext);
        }

        private bool HaveValidSize(IImage image)
        {
            try
            {
                using var stream = image.OpenReadStream();
                return stream.Length <= 5 * 1024 * 1024; // 5MB
            }
            catch
            {
                return false;
            }
        }
    }
}
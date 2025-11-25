using HotelZZ.Application.Common.Files;

namespace HotelZZ.Api.Models
{
    public class FormFileImage : IImage
    {
        private readonly IFormFile _file;

        public FormFileImage(IFormFile file)
        {
            _file = file;
        }
        
        public string FileName => _file.FileName;
        public string ContentType => _file.ContentType;
        public Stream OpenReadStream() => _file.OpenReadStream();
    }
}
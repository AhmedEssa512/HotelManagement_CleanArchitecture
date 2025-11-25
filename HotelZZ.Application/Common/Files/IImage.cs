
namespace HotelZZ.Application.Common.Files
{
    public interface IImage
    {
        string FileName { get; }
        string ContentType { get; }
        Stream OpenReadStream();
    }
}
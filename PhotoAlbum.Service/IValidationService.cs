using PhotoAlbum.Service.Models;

namespace PhotoAlbum.Service
{
    public interface IValidationService
    {
        ValidationResult GetValidationResult(string[] args);
    }
}

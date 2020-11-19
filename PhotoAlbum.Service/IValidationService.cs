using PhotoAlbum.Service.Models;

namespace PhotoAlbum.ConsoleApp
{
    public interface IValidationService
    {
        ValidationResult GetValidationResult(string[] args);
    }
}

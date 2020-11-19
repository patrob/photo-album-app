using System.Linq;
using PhotoAlbum.Service.Models;

namespace PhotoAlbum.ConsoleApp
{
    public class ValidationService : IValidationService
    {
        public ValidationService()
        {
        }

        public ValidationResult GetValidationResult(string[] args)
        {
            var validationResult = new ValidationResult
            {
                Description = "Valid",
                IsValid = true,
                HasWarning = false
            };

            if (args == null || args.Length == 0)
            {
                validationResult.Description = "No arguments provided. Please specify a number.";
                validationResult.IsValid = false;
                return validationResult;
            }

            if (args.Length > 1)
            {
                validationResult.Description = "Too many arguments. Taking first argument and truncating the rest.";
                validationResult.HasWarning = true;
            }

            if (!int.TryParse(args.First(), out int albumId) || albumId < 0)
            {
                validationResult.Description = "Invalid Album ID provided.";
                validationResult.IsValid = false;
                return validationResult;
            }

            validationResult.Result = albumId;

            return validationResult;
        }
    }
}

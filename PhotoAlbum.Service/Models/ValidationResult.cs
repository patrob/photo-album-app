using System;
namespace PhotoAlbum.Service.Models
{
    public class ValidationResult
    {
        public string Description { get; set; } = "Valid";
        public bool IsValid { get; set; } = true;
        public bool HasWarning { get; set; } = false;
        public int Result { get; set; } = 0;
    }
}

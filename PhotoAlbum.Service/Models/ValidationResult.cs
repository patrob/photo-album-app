using System;
namespace PhotoAlbum.Service.Models
{
    public class ValidationResult
    {
        public string Description { get; set; }
        public bool IsValid { get; set; }
        public bool HasWarning { get; set; }
        public int Result { get; set; }
    }
}

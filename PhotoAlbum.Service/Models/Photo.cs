namespace PhotoAlbum.Service.Models
{
    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

        public override string ToString()
        {
            if (Id < 0)
            {
                return $"[{Id}] Invalid Id";
            }
            else if (string.IsNullOrEmpty(Title))
            {
                return $"[{Id}] No Title Provided";
            }
            return $"[{Id}] {Title}";
        }
    }
}

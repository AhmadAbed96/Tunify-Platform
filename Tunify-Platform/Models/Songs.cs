namespace Tunify_Platform.Models
{
    public class Songs
    {
        public int SongsId { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; } = null!;

    }
}

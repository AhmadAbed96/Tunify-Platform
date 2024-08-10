namespace Tunify_Platform.Models
{
    public class Artist
    {

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string? Bio {  get; set; }
        public ICollection<Songs>? songs { get; set; } = new List<Songs>();
    }
}

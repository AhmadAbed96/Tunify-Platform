namespace Tunify_Platform.Models
{
    public class Album
    {

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string Release_Date{ get; set; }
        public int? ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public ICollection<Songs>? songs { get; set; } = new List<Songs>();


    }
}

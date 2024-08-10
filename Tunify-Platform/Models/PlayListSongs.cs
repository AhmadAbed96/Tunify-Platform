namespace Tunify_Platform.Models
{
    public class PlayListSongs
    {
        public string Id { get; set; }
        public int? PlaylistId { get; set; }
        public PlayList? Playlist { get; set; }
        public int SongsId { get; set; }
        public Songs? Song { get; set; }
    }
}

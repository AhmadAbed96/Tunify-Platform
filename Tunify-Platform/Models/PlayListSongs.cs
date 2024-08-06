namespace Tunify_Platform.Models
{
    public class PlayListSongs
    {
        public int PlaylistSongId { get; set; }
        public int PlaylistId { get; set; }
        public PlayList Playlist { get; set; }
        public int SongId { get; set; }
        public Songs Song { get; set; }
    }
}

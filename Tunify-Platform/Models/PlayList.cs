namespace Tunify_Platform.Models
{
    public class PlayList
    {

        public int PlayListId { get; set; }
        public string PlayList_Name { get; set; }
        public string? Created_date { get; set; }
        public int? UserId { get; set; }
        public Users? user { get; set; }
        public ICollection<PlayListSongs>? PlayListSongs { get; set; } = new List<PlayListSongs>();
    }
}

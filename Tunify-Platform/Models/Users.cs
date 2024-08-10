using System.ComponentModel.DataAnnotations;

namespace Tunify_Platform.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string UserName { get; set; }

        public string Join_Date { get; set; }
        public string Email { get; set; }
        public int? SubId { get; set; }
        public Subscription? Subscription { get; set; }
        public ICollection<PlayList>? playLists { get; set; } = new List<PlayList>();


    }
}

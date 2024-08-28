namespace Tunify_Platform.Models.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Token { get; set; }
         
        public IList<string> Roles { get; set; }

    }
}

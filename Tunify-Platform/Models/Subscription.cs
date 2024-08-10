using System.ComponentModel.DataAnnotations.Schema;

namespace Tunify_Platform.Models
{
    public class Subscription
    {

        public int SubscriptionId { get; set; }
        public string Subscription_Type { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        
        public Users? users { get; set; }
    }
}

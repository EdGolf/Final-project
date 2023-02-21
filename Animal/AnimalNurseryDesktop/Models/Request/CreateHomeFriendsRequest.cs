using AnimalNursery.Models.Commands;

namespace AnimalNursery.Models.Request
{
    public class CreateHomeFriendsRequest
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Commands { get; set; }
        public string Type { get; set; }
    }
}
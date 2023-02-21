using AnimalNursery.Models.Commands;

namespace AnimalNursery.Models.Request
{
    public class UpdateHomeFriendsRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Commands { get; set; }
        public string Type { get; set; }
    }
}
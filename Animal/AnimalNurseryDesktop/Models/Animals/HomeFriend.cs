using System.Data.SQLite;
using AnimalNursery.Models.Commands;

namespace AnimalNursery.Models.Animals
{
    public class HomeFriend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public List<string> Commands { get; set; }
        //public CommandsList<String> Commands { get; set; }
        public string Type { get; set; }

        public HomeFriend() {
            Name= string.Empty;
            Commands = new List<string>();
        }
       
        public void Voise()
        {
        }
        public void Sleep()
        {
        }
        public void Eat()
        {
        }
    }
}
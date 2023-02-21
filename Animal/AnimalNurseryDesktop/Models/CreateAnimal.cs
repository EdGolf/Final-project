using AnimalNursery.Models.Animals;
using AnimalNursery.Models.Animals.ImpPackAnimals;
using AnimalNursery.Models.Animals.ImpPets;

namespace AnimalNursery.Models
{
    public class CreateAnimal
    {
        public static HomeFriend create(string item) {
            switch (item) {
                case "Camel": return new Camel();
                   
                case "Donkey": return new Donkey();
                case "Horse": return new Horse();
                case "Dog": return new Dog();
                case "Cat": return new Cat();
                case "Hamster": return new Hamster();
                default: return new HomeFriend();

            }

            
        }
    }
}
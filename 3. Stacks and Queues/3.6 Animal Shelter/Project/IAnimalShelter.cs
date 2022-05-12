using System.Collections.Generic;

namespace Project;

public interface IAnimalShelter
{
    public void EnqueueAny(Animal animal);
    public Animal DequeueAny();
    public Animal DequeueDog();
    public Animal DequeueCat();
    public IList<Animal> CatsList { get; }
    public IList<Animal> DogsList { get; }
}


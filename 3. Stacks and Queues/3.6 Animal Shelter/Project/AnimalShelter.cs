using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class AnimalShelter : IAnimalShelter
{
    LinkedList<Animal> _dogsLinkedList = new();
    LinkedList<Animal> _catsLinkedList = new();
    public IList<Animal> DogsList => _dogsLinkedList.ToList();
    public IList<Animal> CatsList => _catsLinkedList.ToList();

    public Animal DequeueAny()
    {
        Animal oldestCat = _catsLinkedList.FirstOrDefault();
        Animal oldestDog = _dogsLinkedList.FirstOrDefault();

        if (oldestCat?.JoinDate >= oldestDog?.JoinDate)
            return oldestDog;

        if (oldestCat?.JoinDate <= oldestDog?.JoinDate)
            return oldestCat;

        // not found any animall
        return null;
    }

    public Animal DequeueCat()
    {
        Animal cat = _catsLinkedList.FirstOrDefault();
        _catsLinkedList.RemoveFirst();
        return cat;
    }

    public Animal DequeueDog()
    {
        Animal dog = _dogsLinkedList.FirstOrDefault();
        _dogsLinkedList.RemoveFirst();
        return dog;
    }

    public void EnqueueAny(Animal animal)
    {
        if (animal is null)
            throw new ArgumentNullException();

        if (animal is Dog)
        {
            _dogsLinkedList.AddLast(animal);
            return;
        }

        if (animal is Cat)
        {
            _catsLinkedList.AddLast(animal);
            return;
        }

        throw new Exception();
    }
}


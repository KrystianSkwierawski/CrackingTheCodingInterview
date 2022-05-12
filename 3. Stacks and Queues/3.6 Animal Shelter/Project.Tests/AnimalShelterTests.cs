using FluentAssertions;
using NUnit.Framework;
using Project.Models;
using System;

namespace Project.Tests
{
    public class AnimalShelterTests
    {
        [Test]
        public void EnqueueAny_ShouldEnqueueDog()
        {
            //Arrange
            IAnimalShelter animalShelter = new AnimalShelter();
            Animal animal = new Dog();

            //Act
            animalShelter.EnqueueAny(animal);

            //Assert
            animalShelter.DogsList.Count.Should().Be(1);
            animalShelter.CatsList.Count.Should().Be(0);
            animalShelter.DogsList[0].Should().BeEquivalentTo(animal);
        }

        [Test]
        public void EnqueueAny_ShouldEnqueueCat()
        {
            //Arrange
            IAnimalShelter animalShelter = new AnimalShelter();
            Animal animal = new Cat();

            //Act
            animalShelter.EnqueueAny(animal);

            //Assert
            animalShelter.CatsList.Count.Should().Be(1);
            animalShelter.DogsList.Count.Should().Be(0);
            animalShelter.CatsList[0].Should().BeEquivalentTo(animal);
        }

        [Test]
        public void ShouldDequeueAny()
        {
            //Arrange
            IAnimalShelter animalShelter = new AnimalShelter();
            Animal oldestAnimal = new Cat { Name = "abc" };
            animalShelter.EnqueueAny(oldestAnimal);
            animalShelter.EnqueueAny(new Cat());
            animalShelter.EnqueueAny(new Dog());
            animalShelter.EnqueueAny(new Dog());


            //Act
            var result = animalShelter.DequeueAny();

            //Assert
            result.Should().BeEquivalentTo(oldestAnimal);
            result.Should().BeOfType<Cat>();
        }

        [Test]
        public void ShouldDequeueCat()
        {
            //Arrange
            IAnimalShelter animalShelter = new AnimalShelter();
            Animal cat = new Cat { Name = "abc" };
            animalShelter.EnqueueAny(cat);


            //Act
            var result = animalShelter.DequeueCat();


            //Assert
            result.Should().BeOfType<Cat>();
            result.Should().BeEquivalentTo(cat);
            animalShelter.CatsList.Count.Should().Be(0);
        }

        [Test]
        public void ShouldDequeueDog()
        {
            //Arrange
            IAnimalShelter animalShelter = new AnimalShelter();
            Animal dog = new Dog { Name = "abc" };
            animalShelter.EnqueueAny(dog);


            //Act
            var result = animalShelter.DequeueDog();


            //Assert
            result.Should().BeOfType<Dog>();
            result.Should().BeEquivalentTo(dog);
            animalShelter.DogsList.Count.Should().Be(0);
        }

        [Test]
        public void EnqueueAnyShouldThrowExceptionIfAnimalIsEmpty()
        {
            FluentActions.Invoking(() => new AnimalShelter().EnqueueAny(null))
                .Should().Throw<ArgumentNullException>();
        }
    }
}

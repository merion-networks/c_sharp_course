﻿namespace InheritanceLibrary
{
    public class Animal
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name} ест.");
        }
    }
}

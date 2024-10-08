﻿namespace GenericLibrary
{
    public class Pair <TFirst,  TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        public Pair(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"First: {First} (Type: {typeof(TFirst)})");
            Console.WriteLine($"Second: {Second} (Type: {typeof(TSecond)})");
        }
    }
}

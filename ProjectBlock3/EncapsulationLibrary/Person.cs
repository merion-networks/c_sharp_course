namespace EncapsulationLibrary
{
    public class Person
    {
        public string Name { get; private set; }

        private int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void HaveBirthday()
        {
            Age++;
        }
    }
}

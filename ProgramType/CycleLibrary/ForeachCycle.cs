using static VariablesLibrary.Record;

namespace CycleLibrary
{

    public class ForeachCycle
    {
        void Example()
        {
            List<Person> list = new List<Person>();

            list.Add(new Person("Test", "Test", 20));
            list.Add(new Person("Test", "Test", 21));
            list.Add(new Person("Test", "Test", 22));
            list.Add(new Person("Test", "Test", 23));
            list.Add(new Person("Test", "Test", 24));
            list.Add(new Person("Test", "Test", 25));


            List<string> strings = new List<string>() { "test1", "test2", "test3", "test4", "test5" };


            foreach (var item in list)
            {
                Console.WriteLine($"Итерация - {item.FirstName} - [{item.LastName}]  ({item.Age})");
                foreach (var str in strings)
                {
                    Console.WriteLine($"{str} - {item}");
                }
            }

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }

        void ExampleSyntax()
        {
            int i = 0;

            foreach (var x in Enumerable.Range(0, 10))
            {
                i++;
            }

            //foreach (int item in collectionNumbers)
            //{

            //}

            //foreach (var stringName in collectionString)
            //{

            //}

            //foreach (KeyValuePair<string, int> item in dictionary)
            //{

            //}

            //foreach (MyObject obj in myColection)
            //{

            //}


            IEnumerator<int> enumerator = Enumerable.Range(0, 10).GetEnumerator();

            try
            {
                while (enumerator.MoveNext())
                {
                    int element = enumerator.Current;
                }
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                    disposable.Dispose();
            }

        }

        public ForeachCycle() { Example(); }
    }
}

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CollectionLibrary
{
    public class CollectionClass
    {
        public void ArrayListCollection() {
        ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("1");
            arrayList.Add(3.5);


            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }

        public void NameValueCollectionMethod()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("ЯП","C#");
            collection.Add("ЯП","Java");
            collection.Add("ЯП","GoLang");
            collection.Add("Framework",".Net");

            foreach (string key in collection)
            {
                Console.WriteLine($"{key} : {collection[key]}");
            }
        }

        public void BitArrayCollection()
        {
            BitArray bits = new BitArray(4);
            bits[0] = true;
            bits[1] = false;
            bits[2] = true;
            bits[3] = false;

            //Проверяйте размерность инача ошибка рантайма
            //bits[4] = true;
            //bits[5] = true;

            for (int i = 0; i < bits.Length; i++)
            {
                Console.WriteLine($"{i} : {bits[i]} ");
            }
        }


        public void ImmutableCollection()
        {
            ImmutableList<int>  immutableList = ImmutableList.Create<int>(1,2,3);
            ImmutableList<int>  immutableNewList = immutableList.Add(5);

            Console.WriteLine("Первый лист");
            foreach (var item in immutableList)
            {
                Console.WriteLine (item);
            }

            Console.WriteLine("Новый лист");
            foreach (var item in immutableNewList)
            {
                Console.WriteLine(item);
            }

        } 

        public void ConcurrentColection()
        {
            ConcurrentDictionary<int, string> cuncurrentDict = new ConcurrentDictionary<int, string>();
            cuncurrentDict.TryAdd(1, "Первый");
            cuncurrentDict.TryAdd(2, "Второй");

            Console.WriteLine(cuncurrentDict[2]);

            ConcurrentQueue<int> cuncurrentQueueDict = new ConcurrentQueue<int>();

            cuncurrentQueueDict.Enqueue(1);
            cuncurrentQueueDict.Enqueue(2);

            if (cuncurrentQueueDict.TryDequeue(out int result))
            {
                Console.WriteLine(result);
            }

           // ConcurrentStack 

        }

        public void OСCollection()
        {
            ObservableCollection<string> data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add("Item 1");
            data.Remove("Item 1");

        }

        private void Data_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Action - {e.Action}");
        }

        public void HashSetCollection()
        {
            HashSet<int> a = new HashSet<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3); a.Add(3); a.Add(3); a.Add(3);
            a.Add(4);
            a.Add(5); a.Add(5); a.Add(5);
            a.Add(6);

            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
        }
        public void StackColection()
        {
            Stack<int> colrction = new Stack<int>();

            colrction.Push(15);
            colrction.Push(40);
            colrction.Push(60);
            colrction.Push(100);


            while (colrction.Count > 0)
            {
                Console.WriteLine(colrction.Pop());
            }

        }

        public void QueueColrction()
        {
            Queue<int> colrction = new Queue<int>();
            colrction.Enqueue(1);
            colrction.Enqueue(2);
            colrction.Enqueue(10);
            colrction.Enqueue(3);

            while (colrction.Count > 0)
            {
                Console.WriteLine(colrction.Dequeue());
            }
        }

        public void SortedSetColection()
        {
            SortedSet<string> fruits = new SortedSet<string>();
            fruits.Add("Яблоко");
            fruits.Add("Мандарин");
            fruits.Add("Апельсин");

            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }

        public void SortedDictionaryCollection()
        {
            SortedDictionary<int, string> sortedDict = new SortedDictionary<int, string>();


            sortedDict[0] = "1";
            sortedDict[2] = "Второй";
            sortedDict[1] = "Первый";
            sortedDict[4] = "Четвертый";
            sortedDict[3] = "Третий";


            foreach (var collection in sortedDict)
            {
                Console.WriteLine($"Возраст {collection.Key} - {collection.Value}");
            }
        }

        public void SortedListCollection()
        {
            SortedList<int, string> collections = new SortedList<int, string>();

            collections.Add(2, "Второй");
            collections.Add(1, "Первый");
            collections.Add(4, "Четвертый");
            collections.Add(3, "Третий");


            foreach (var collection in collections)
            {
                Console.WriteLine($"Возраст {collection.Key} - {collection.Value}");
            }
        }


        public void DictionaryCollection()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>();

            ages["Алиса"] = 25;
            ages["Макс"] = 40;

            Console.WriteLine($"Возраст Алисы - {ages["Алиса"]}");

            Console.WriteLine("---------------");

            foreach (var item in ages)
            {
                Console.WriteLine($"Возраст {item.Key} - {item.Value}");
            }
        }

        public void LinkedListCollection()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddFirst("A");
            list.AddFirst("B");
            list.AddLast("C");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


        public void ListCollection()
        {
            List<string> fruits = new List<string>();
            fruits.Add("Яблоко");
            fruits.Add("Мандарин");
            fruits.Add("Апельсин");

            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            fruits.Remove("Яблоко");


            // Сравнение с массивом строк

            string[] fruitsArray = new string[4] { "Яблоко", "Мандарин", "Апельсин", "" };

            foreach (var fruit in fruitsArray)
            {
                Console.WriteLine(fruit);
            }

            List<int> nunbers = new List<int>() { 1, 2, 3, 4, 5 };
            nunbers.Add(6);
            nunbers.Insert(5, 7);

            foreach (var nunber in nunbers)
            {
                Console.WriteLine(nunber);
            }

        }

        public CollectionClass(string name)
        {

            /**
             * Обзор основных коллекций:
             * 
             * List<T> - список элементов определенного типа с возможностью динамического изменения размера.
             * Dictionary<TKey, TValue> - коллекция пар "ключ-значение", обеспечивающая быстрый доступ к значениям по ключам.
             * Queue<T> — очередь, представляющая собой структуру данных типа FIFO (First-In-First-Out)
             * Stack<T> - стек, представляющий структуру данных типа LIFO (Last-In-First-Out) 
             * HashSet<T> — коллекция уникальных элементов, не допускающая дубликатов.
             * 
             * 
             * Обобщенные и необобщенные коллекции 
             * 
             * Обобщенные (Generic Collections) пространстве имен `System.Collections.Generic`
             *  `List<T>`, `Dictionary<TKey, TValue>`, `Queue<T>`, `Stack<T>`, `HashSet<T>`.
             *  
             *Необощенные (Non - Generic Collections)  пространстве имен `System.Collections`
             *
             *  `ArrayList`, `Hashtable`, `Queue`, `Stack`.
             *  
             * Интерфейсы коллекций
             * - IEnumerator  - определяет функционал для перебора внутренних объектов в контейнере (коллекции)
             * - IEnumerable: Предоставляет итератор для перебора коллекции. (IEnumerator GetEnumerator())
             * - ICollection: Наследует от `IEnumerable` и предоставляет размер коллекции, методы для добавления и удаления элементов.
             * - IList: Наследует от `ICollection` и позволяет доступ к элементам по индексу.
             * - IDictionary: Наследует от `ICollection` и используется для коллекций пар "ключ-значение"
             **/


        }
    }
}

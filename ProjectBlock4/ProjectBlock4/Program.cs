// See https://aka.ms/new-console-template for more information
using CollectionLibrary;
using FileLibrary;
using GenericLibrary;
using GenericLibrary.Model;
using LINQLibrary;

Console.WriteLine("Hello, World!");



#region Collection
CollectionClass collection = new CollectionClass("List");
//collection.ListCollection();
//collection.LinkedListCollection();
//collection.DictionaryCollection();
//collection.SortedListCollection();
//collection.SortedDictionaryCollection();
//collection.SortedSetColection();
//collection.QueueColrction();
//collection.StackColection();

//collection.HashSetCollection();
//collection.OСCollection();

//collection.ConcurrentColection();
//collection.ImmutableCollection();
//collection.BitArrayCollection();
//collection.NameValueCollectionMethod();
//collection.ArrayListCollection();

#endregion

#region Generic

//var pair = new Pair<int, string>(1, "Test");
//pair.DisplayInfo();

//var factory = new Factory<MyClass>();
//var instance = factory.CreateInstance();

//Console.WriteLine(instance);


//var userRepository = new Repository<User>();
//userRepository.Save(new User { Id = 10, Name = "Test" });


//var collectionGeneric = new MyCollection<int>() { 1, 2, 3 };

//foreach (var item in collectionGeneric)
//{
//    Console.WriteLine(item);
//}

//IEnumerable<string> strings = new List<string>();
//IEnumerable<object> objects = strings;

//Action<object> actionObject = obj => Console.WriteLine(obj);
//Action<string> actionString = actionObject;


//string[] stringsArray = new string[] { "а", "б", "с" };
//object[] objectsArray = stringsArray; //Ковариантность массивов

//objectsArray[0]  = 1; // Ошибка во время выполнения: ArrayTypeMismatchException


//public interface IProducer<out T>
//{
//    T Produce();
//    //void Consume(T item);  Ошибка: : нельзя использовать T в качестве
//    //входного параметра при ковариантности
//}

#endregion

#region LINQ

//LenguageIntegratedQuery query = new LenguageIntegratedQuery();
//query.ExampleinqExtension();

#endregion

//FileClass fileClass = new FileClass();
StreamClass streamClass = new StreamClass();
//streamClass.ExampleStreamWriter();
//streamClass.ExampleStreamReader();
streamClass.ExampleBufferedStream();

//var result = await streamClass.ReadFileAsync("example.txt");
//Console.WriteLine(result);

//BinaryClass binaryClass = new BinaryClass();
//binaryClass.ExampleBinaryWrite();
//binaryClass.ExampleBinaryRead();

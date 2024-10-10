using GenericLibrary.Model;

namespace GenericLibrary
{
    public class MyGenericClass<T>
    {
        private T value;

        public MyGenericClass(T value)
        {
            this.value = value;
        }

        public T GetValue() => value;
    }



    /**
     * Типы ограничений:
     * - `where T : class` — параметр типа должен быть ссылочным типом (классом).
     * - `where T : struct` — параметр типа должен быть значимым типом (структурой), кроме `Nullable<T>`.
     * - `where T : new()` — параметр типа должен иметь публичный конструктор без параметров. 
     * - `where T : BaseClass` — параметр типа должен быть `BaseClass` или наследовать от `BaseClass`.
     * - `where T : InterfaceName` — параметр типа должен реализовывать интерфейс `InterfaceName`.
     * - Ограничения могут комбинироваться, например: `where T : class, new()`. 
     * 
     * **/


    public class Factory<T> where T : new()
    {
        public T CreateInstance() { return new T(); }
    }


    public class Repository<T> where T : Entity
    {

        public void Save(T entity)
        {
            Console.WriteLine($"Сохраняем сущность с ID = {entity.Id}");
        }
    }
}

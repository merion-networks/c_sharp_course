namespace IndicesAndRangesLibrary
{
    /// <summary>
    /// Оператор "^"
    /// </summary>
    public class ExampleIndices
    {

        public void PractickMetod()
        {
            Console.WriteLine("Задание 1.0:");

            int[] data = { 5, 10, 15, 20, 25, 30, 35 };

            Console.WriteLine(data[^1]);
            Console.WriteLine(data[^2]);

        }

        public void ExampleMetodIndices() {
            int[] indices = { 1, 2, 3 };
            int lastNumber = indices[^1]; // 3
            int penultimateNumber = indices[^2];// 2

            Console.WriteLine(lastNumber + " |" + penultimateNumber);
        }
    }
}

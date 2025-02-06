

int[] numbers = { 5, 2, 8, 4, 1 };

BubbleSort(numbers);

Console.WriteLine("Отсортированный массив:");
Console.WriteLine(string.Join(", ", numbers));


void BubbleSort(int[] numbers)
{
    int n = numbers.Length;
    bool swapped;

    for (int i = 0; i < n - 1; i++)
    {
        swapped = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            if (numbers[j] > numbers[j + 1])
            {
                Swap(ref numbers[j], ref numbers[j + 1]);
                swapped = true;
            }
        }

        if (!swapped) { break; }
    }
}

void Swap(ref int v1, ref int v2)
{
    int temp = v1; v1 = v2; v2 = temp;
}
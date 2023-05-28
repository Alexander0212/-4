using System;

class Program
{
    static void Main()
    {
        int K = 19; // Номер студента у журналі

        int N = (int)(20 + 0.6 * K); // Розмір масиву

        int[] array = new int[N]; // Одновимірний масив

        Random random = new Random();

        // Заповнення масиву випадковими числами
        for (int i = 0; i < N; i++)
        {
            array[i] = random.Next(10, 101);
        }

        // Виведення початкового масиву
        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Сортування масиву методом злиття
        MergeSort(array, 0, N - 1);

        // Виведення відсортованого масиву
        Console.WriteLine("\nВiдсортований масив:");
        PrintArray(array);

        // Введення ключового значення
        Console.Write("\nВведiть ключове значення: ");
        int key = int.Parse(Console.ReadLine());

        // Підрахунок кількості входжень ключового значення в масиві
        int count = CountOccurrences(array, key);

        Console.WriteLine("\nКiлькiсть входжень ключового значення {0} в масивi: {1}", key, count);
    }

    // Метод для сортування масиву методом злиття
    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    // Метод для злиття підмасивів під час сортування злиттям
    static void Merge(int[] array, int left, int middle, int right)
    {
        int[] temp = new int[array.Length];
        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right)
        {
            if (array[i] <= array[j])
            {
                temp[k] = array[i];
                i++;
            }
            else
            {
                temp[k] = array[j];
                j++;
            }
            k++;
        }

        while (i <= middle)
        {
            temp[k] = array[i];
            i++;
            k++;
        }

        while (j <= right)
        {
            temp[k] = array[j];
            j++;
            k++;
        }

        for (k = left; k <= right; k++)
        {
            array[k] = temp[k];
        }
    }

    // Метод для виведення масиву
    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    // Метод для підрахунку кількості входжень ключового значення в масиві
    static int CountOccurrences(int[] array, int key)
    {
        int count = 0;

        foreach (int element in array)
        {
            if (element == key)
            {
                count++;
            }
        }

        return count;
    }
}

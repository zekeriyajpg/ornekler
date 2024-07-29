using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            // Kullanıcıya menüyü göster
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1. İki sayıyı toplama");
            Console.WriteLine("2. Dizideki en büyük sayıyı bulma");
            Console.WriteLine("3. Dizideki elemanların ortalamasını hesaplama");
            Console.WriteLine("4. Faktöriyel hesaplama");
            Console.WriteLine("5. Fibonacci serisi hesaplama (iteratif)");
            Console.WriteLine("6. Merge sort ile dizi sıralama");
            Console.WriteLine("7. Çıkış");
            Console.Write("Seçiminiz: ");

            // Kullanıcıdan seçim yapmasını iste
            int choice = int.Parse(Console.ReadLine());

            // Kullanıcının seçimine göre ilgili methodu çağır
            switch (choice)
            {
                case 1:
                    AddNumbers();
                    break;
                case 2:
                    FindMaxInArray();
                    break;
                case 3:
                    CalculateArrayAverage();
                    break;
                case 4:
                    CalculateFactorial();
                    break;
                case 5:
                    CalculateFibonacci();
                    break;
                case 6:
                    SortArrayWithMergeSort();
                    break;
                case 7:
                    return; // Programdan çık
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    // İki sayıyı toplama methodu
    public static void AddNumbers()
    {
        Console.Write("Birinci sayıyı girin: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("İkinci sayıyı girin: ");
        int num2 = int.Parse(Console.ReadLine());

        int result = Add(num1, num2);
        Console.WriteLine($"Sonuç: {result}");
    }

    // İki sayıyı toplayan method
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Dizideki en büyük sayıyı bulma methodu
    public static void FindMaxInArray()
    {
        Console.Write("Dizi elemanlarını aralarında boşluk bırakarak girin: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int max = FindMax(numbers);
        Console.WriteLine($"En büyük sayı: {max}");
    }

    // Bir dizideki en büyük sayıyı bulan method
    public static int FindMax(int[] numbers)
    {
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        return max;
    }

    // Dizideki elemanların ortalamasını hesaplama methodu
    public static void CalculateArrayAverage()
    {
        Console.Write("Dizi elemanlarını aralarında boşluk bırakarak girin: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        double average = CalculateAverage(numbers);
        Console.WriteLine($"Ortalama: {average}");
    }

    // Bir dizideki elemanların ortalamasını hesaplayan method
    public static double CalculateAverage(int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return (double)sum / numbers.Length;
    }

    // Faktöriyel hesaplama methodu
    public static void CalculateFactorial()
    {
        Console.Write("Bir sayı girin: ");
        int num = int.Parse(Console.ReadLine());

        int factorial = Factorial(num);
        Console.WriteLine($"Faktöriyel: {factorial}");
    }

    // Bir sayının faktöriyelini hesaplayan method
    public static int Factorial(int n)
    {
        if (n <= 1)
        {
            return 1;
        }
        return n * Factorial(n - 1);
    }

    // Fibonacci serisi hesaplama methodu (iteratif)
    public static void CalculateFibonacci()
    {
        Console.Write("Bir sayı girin: ");
        int num = int.Parse(Console.ReadLine());

        int fibonacci = FibonacciIterative(num);
        Console.WriteLine($"Fibonacci: {fibonacci}");
    }

    // Fibonacci serisindeki n'inci sayıyı hesaplayan iteratif method
    public static int FibonacciIterative(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int a = 0, b = 1, c = 0;

        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }

    // Merge sort ile dizi sıralama methodu
    public static void SortArrayWithMergeSort()
    {
        Console.Write("Dizi elemanlarını aralarında boşluk bırakarak girin: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        MergeSort(numbers);
        Console.WriteLine("Sıralı dizi: " + string.Join(", ", numbers));
    }

    // Merge sort algoritması ile diziyi sıralayan method
    public static void MergeSort(int[] array)
    {
        if (array.Length <= 1)
        {
            return;
        }

        int mid = array.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];

        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);

        MergeSort(left);
        MergeSort(right);
        Merge(array, left, right);
    }

    // İki diziyi birleştirerek sıralı bir dizi oluşturan method
    private static void Merge(int[] array, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k++] = left[i++];
            }
            else
            {
                array[k++] = right[j++];
            }
        }

        while (i < left.Length)
        {
            array[k++] = left[i++];
        }

        while (j < right.Length)
        {
            array[k++] = right[j++];
        }
    }
}

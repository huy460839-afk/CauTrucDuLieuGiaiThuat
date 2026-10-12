using System;
using System.Diagnostics;
namespace Cautrucdulieu
{
    internal class Program
    {
            static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Bai 2
            Bai3();
        }
            static void Bai1()
        {
                //Bai 1 nhap 3 so nguyen va xuat so lon nhat nho nhat tong va trung binh cong cua 3 so
            Console.WriteLine("Nhap 3 so nguyen: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            int max = Math.Max(a, Math.Max(b, c));
            int min = Math.Min(a, Math.Min(b, c));
            int sum = a + b + c;
            double avg = sum / 3.0;

            Console.WriteLine($"So lon nhat: {max}");
            Console.WriteLine($"So nho nhat: {min}");
            Console.WriteLine($"Tong: {sum}");
            Console.WriteLine($"Trung binh cong: {avg:F2}");
        }
        static void Bai2()
{
    int n = int.Parse(Console.ReadLine()!);
    string[] a = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    int max1 = int.Parse(a[0]);
    int max2 = 0;
    bool coMax2 = false;

    for (int i = 1; i < n; i++)
    {
        int x = int.Parse(a[i]);

        if (x > max1)
        {
            max2 = max1;
            coMax2 = true;
            max1 = x;
        }
        else if (x < max1 && (!coMax2 || x > max2))
        {
            max2 = x;
            coMax2 = true;
        }
    }

    if (!coMax2) Console.WriteLine("NO");
    else Console.WriteLine(max1 + " " + max2);
}
    static void Bai3()
        {
            static int PhienBanA(int[] a)
{
    int best = a[0];
    for (int i = 0; i < a.Length; i++)
    {
        int sum = 0;
        for (int j = i; j < a.Length; j++)
        {
            sum += a[j];
            if (sum > best) best = sum;
        }
    }
    return best;
}

            static int PhienBanB(int[] a)
{
    int cur = a[0];
    int best = a[0];
    for (int i = 1; i < a.Length; i++)
    {
        cur = Math.Max(a[i], cur + a[i]);
        if (cur > best) best = cur;
    }
    return best;
}

static void Bai3()
{
    int[][] tests =
    {
        new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 },
        new[] { -8, -3, -6, -2, -5, -4 },
        new[] { 1, 2, 3 }
    };
    foreach (var t in tests)
    {
        int a = PhienBanA(t), b = PhienBanB(t);
        Console.WriteLine($"A = {a}, B = {b}, giong nhau: {a == b}");
    }

    int[] sizes = { 100, 1000, 10000 };
    int soLan = 5;
    Random rnd = new Random(123);

    Console.WriteLine("\nn\tA (ms)\tKadane (ms)");
    foreach (int n in sizes)
    {
        int[] data = new int[n];
        for (int i = 0; i < n; i++) data[i] = rnd.Next(-100, 101);

        double tongA = 0, tongB = 0;
        for (int k = 0; k < soLan; k++)
        {
            var sw = Stopwatch.StartNew();
            int ra = PhienBanA(data);
            sw.Stop();
            tongA += sw.Elapsed.TotalMilliseconds;

            sw.Restart();
            int rb = PhienBanB(data);
            sw.Stop();
            tongB += sw.Elapsed.TotalMilliseconds;

            if (ra != rb) Console.WriteLine("KHAC KET QUA!");
        }
        Console.WriteLine($"{n}\t{tongA / soLan:F4}\t{tongB / soLan:F4}");
    }
}
        }
    }
}

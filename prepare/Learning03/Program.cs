using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Fraction whole = new Fraction(6);
        Fraction fraction = new Fraction(6, 7);
        Console.WriteLine($"{one.Top} {one.Bottom}");
        Console.WriteLine($"{whole.Top} {whole.Bottom}");
        Console.WriteLine($"{fraction.Top} {fraction.Bottom}");

        one.Top = 2; one.Bottom = 2;
        whole.Top = 12; whole.Bottom = 2;
        fraction.Top = 12; fraction.Bottom = 14;

        Console.WriteLine($"{one.Top} {one.Bottom}");
        Console.WriteLine($"{whole.Top} {whole.Bottom}");
        Console.WriteLine($"{fraction.Top} {fraction.Bottom}");
    }
}
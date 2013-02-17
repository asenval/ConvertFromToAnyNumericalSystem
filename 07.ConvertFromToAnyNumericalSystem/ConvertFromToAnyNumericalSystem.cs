using System;

class ConvertFromToAnyNumericalSystem
{
    static void Main()
    {
        ConvertNumeralSystem NS = new ConvertNumeralSystem();
        Console.WriteLine("Enter Number in Numerical System with base s to convert in Numeric System with base d (2 ≤ s, d ≤  16):");
        string n = Console.ReadLine();
        Console.WriteLine("Enter base s for Numeric System:");
        int s = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter base d for Numeric System:");
        int d = int.Parse(Console.ReadLine());
        string result;

        NS.DecimalToBinary(n, s, d, out result);
        Console.WriteLine(result);
    }
}

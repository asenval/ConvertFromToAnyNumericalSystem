using System;
using System.Collections.Generic;
using System.Text;


public class ConvertNumeralSystem
{
    public void DecimalToBinary(string number, int baseinput, int baseoutput, out string numberResult)
    {
        numberResult = String.Empty;
        if (baseinput >= 2 && baseinput <= 16 && baseoutput >= 2 && baseoutput <= 16)
        {

            if (baseinput == 10)
            {
                numberResult = ConvertFromDecimal(Convert.ToInt32(number), baseoutput);
            }
            else if (baseoutput == 10)
            {
                numberResult = ConvertToDecimal(number, baseinput).ToString();

            }
            else
            {
                try
                {
                    int n = ConvertToDecimal(number, baseinput);
                    numberResult = (ConvertFromDecimal(n, baseoutput));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Message: ..... Input number out of Numerical System range < {0}", baseinput);
                }

            }
        }
        else
        {
            Console.WriteLine("Message: ..... Number for base is out of range (2-16)");
        }
    }

    public int CheckBitsOfNumber(int number, int baseoutput)
    {
        if (Math.Abs(number) < Math.Pow(2, 8))
        {
            return 8 / (int)Math.Sqrt(baseoutput);
        }
        else if (Math.Abs(number) < Math.Pow(2, 16))
        {
            return 16 / (int)Math.Sqrt(baseoutput);
        }
        else if (Math.Abs(number) < Math.Pow(2, 32))
        {
            return 32 / (int)Math.Sqrt(baseoutput);
        }
        else
        {
            return 64 / (int)Math.Sqrt(baseoutput);
        }

    }

    private string ReturnBase(int simbol)
    {
        switch (simbol)
        {
            case 0:
                return "0";                
            case 1:
                return "1";                
            case 2:
                return "2";                
            case 3:
                return "3";                
            case 4:
                return "4";                
            case 5:
                return "5";                
            case 6:
                return "6";                
            case 7:
                return "7";                
            case 8:
                return "8";                
            case 9:
                return "9";                
            case 10:
                return "A";                
            case 11:
                return "B";                
            case 12:
                return "C";                
            case 13:
                return "D";                
            case 14:
                return "E";                
            case 15:
                return "F"; 
            default:
                return "0";
        }
    }

    private string ConvertFromDecimal(int number, int baseoutput)
    {
        List<string> remeinder = new List<string>();
        int bits = CheckBitsOfNumber(number, baseoutput);
        int count = 1;
        bool negativ = false;
        if (number < 0)
        {
            negativ = true;
        }
        //string basestring = ReturnBase(baseoutput);

        while (number != 0)
        {
            int result = number % baseoutput;

            // Check and calc Hexadecimal number if decimal is negativ
            if (negativ && baseoutput == 16)
            {

                if (result != 0)
                {
                    result = baseoutput - 1 + result + count;
                    count = 0;
                }
                else
                {
                    count = 1;
                }
            }
            // Check and calc Binary number if decimal is negativ
            if (negativ && baseoutput == 2)
            {
                result = (Math.Abs(result) ^ count) ^ 1;
                if (result != 0)
                {
                    count = 0;
                }
            }
            if (result < 10)
            {
                remeinder.Add(result.ToString());
            }
            else if (result == 10)
            {
                remeinder.Add("A");
            }
            else if (result == 11)
            {
                remeinder.Add("B");
            }
            else if (result == 12)
            {
                remeinder.Add("C");
            }
            else if (result == 13)
            {
                remeinder.Add("D");
            }
            else if (result == 14)
            {
                remeinder.Add("E");
            }
            else if (result == 15)
            {
                remeinder.Add("F");
            }

            number = number / baseoutput;
        }

        // Check and calc Hexadecimal number if decimal is negativ
        if (negativ && baseoutput == 16)
        {
            int index = remeinder.Count;
            for (int i = 0; i < bits - index; i++)
            {
                remeinder.Add("F");
            }
        }
        // Check and calc Binary number if decimal is negativ
        if (negativ && baseoutput == 2)
        {
            int index = remeinder.Count;
            for (int i = 0; i < bits - index; i++)
            {
                remeinder.Add("1");
            }
        }

        remeinder.Reverse();
        StringBuilder builder = new StringBuilder();
        foreach (string n in remeinder)
        {
            builder.Append(n);
        }
        if (builder.ToString() != "")
        {
            return builder.ToString();
        }
        else
        {
            return "0";
        }
    }

    private int ConvertToDecimal(string str, int baseinput)
    {
        int result = 0;
        string simbol;
        int number = 0;
        for (int i = 0; i < str.Length; i++)
        {
            simbol = str.Substring(i, 1);
            if (simbol == "A")
            {
                number = 10;
            }
            else if (simbol == "B")
            {
                number = 11;
            }
            else if (simbol == "C")
            {
                number = 12;
            }
            else if (simbol == "D")
            {
                number = 13;
            }
            else if (simbol == "E")
            {
                number = 14;
            }
            else if (simbol == "F")
            {
                number = 15;
            }
            else
            {
                number = Convert.ToInt32(simbol);
            }
            if (number >= baseinput)
            {
                throw new ArgumentOutOfRangeException();
            }
            result += number * (int)Math.Pow(baseinput, str.Length - 1 - i);
        }
        return result;
    }

    public string ConvertFractionFromDecimalToBinary(double number, int baseoutput = 2)
    {
        StringBuilder builder = new StringBuilder();
                
        while (number != 0.0 && builder.Length<24)
        {
            number = number * baseoutput;
            if (number >= 1)
            {
                number = number - 1;
                builder.Append("1");
            }
            else
            {
                builder.Append("0");
            }
        }
        if (builder.Length == 24)
        {
            if (builder[23] == '1')
            {
                builder[22] = '1';
            }
            builder.Remove(builder.Length - 1, 1);

        }

        return builder.ToString();
    }

    public string ConvertDigit(int number)
    {
        string result = "";
        List<string> Letters = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
        result = Letters[number - 1];
        return result;
        //abcdefghijklmnopqrstuvwxyz
    }
    public int ConvertDigit(string number)
    {
        int result = 0;
        List<string> Letters = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        result = Letters.IndexOf(number) + 1;
        return result;
        //abcdefghijklmnopqrstuvwxyz
    }
}

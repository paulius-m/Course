﻿namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.Console.ReadLine();
            string maybeNumber = System.Console.ReadLine();
            int number;
            int i = 0;

            string uperCaseText = text.ToUpper();
            if (int.TryParse(maybeNumber, out number))
            {
                while (i < number)
                {
                    System.Console.WriteLine(uperCaseText);
                    i = i + 1;
                }
            }
            System.Console.ReadLine();
        }
    }
}

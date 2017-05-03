
namespace ConsoleApp2
{
    class Task2
    {
        static void Main1(string[] args)
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

using ForwardChaining;

class Program
{
    public static void Main(string[] args)
    {
        Class1 c = new Class1();

        while (true)
        {
            Console.WriteLine("\nPress [F] to input a Fact");
            Console.WriteLine("Press [R] to generate a Rule");
            Console.WriteLine("Press [P] to print all the Facts");
            Console.WriteLine("Press [Q] to quit");

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            switch (char.ToLower(keyInfo.KeyChar))
            {
                case 'f':
                    c.addFact();
                    break;
                case 'r':
                    c.addRules();
                    break;
                case 'p':
                    bool newFactAdded = true;
                    while (newFactAdded)
                    {
                        newFactAdded = c.addNewFact();
                    }
                    c.print();
                    break;
                case 'q':
                    return;
                case 'l':
                    c.printR();
                    break;
                case 'm':
                    c.print();
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

}

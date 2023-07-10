using ex0079;

internal class Program
{
    private static void Main(string[] args)
    {
        // Only missing digits are 4 and 5 and there are no obvious repeating digits,
        // so absolute minimum length is 8.

        string filePath = Path.Combine(Environment.CurrentDirectory, @"0079_keylog.txt");
        string[] logs = File.ReadAllLines(filePath);
        long password = 0;
        int digits = 8;
        long limit = 100_000_000;
        
    Looper:
        while (password < limit)
        {
            string passwordString = password.ToString().PadLeft(digits,'0');
            bool valid = true;
            foreach (string log in logs)
            {
                if (!ValidityChecker.CheckValidity(log, passwordString))
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                Console.WriteLine("------------------");
                Console.WriteLine($"Password: {passwordString}");
                Environment.Exit(0);
            }

            password++;
        }

        Console.WriteLine($"Password has more than {digits} digits.");
        digits++;
        limit *= 10;
        goto Looper;
    }
}
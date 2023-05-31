using ex0024;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> digits = new List<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        
        IEnumerable<IEnumerable<string>> permutations = Permutations.GetPermutations(digits, 10);
        List<long> numbers = new List<long>();
        foreach (var permutation in permutations)
        {
            string numberString = "";
            foreach (string digit in permutation)
            {
                numberString += digit;
            }
            Console.WriteLine(numberString);
            numbers.Add(long.Parse(numberString));
        }
        numbers.Sort();
        Console.WriteLine(numbers[999999]);
    }
}
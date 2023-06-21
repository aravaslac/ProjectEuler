internal class Program
{
    private static void Main(string[] args)
    {
        //FileStream filestream = new FileStream(@"C:\Estudo\repositorio\ProjectEuler\ex0059\out.txt", FileMode.Create);
        //var streamwriter = new StreamWriter(filestream);
        //streamwriter.AutoFlush = true;
        //Console.SetOut(streamwriter);
        //Console.SetError(streamwriter);

        //int spaceASCIIValue = ' ';
        //int aASCIIValue = 'a';
        //int zASCIIValue = 'z';
        //string filePath = Path.Combine(Environment.CurrentDirectory, @"0059_cipher.txt");
        //string cipher = File.ReadAllText(filePath);
        //string[] cipherCharacters = cipher.Split(',');
        //List<int> cipherNumbers = new List<int>();
        //foreach (string cipherCharacter in cipherCharacters)
        //{
        //    cipherNumbers.Add(int.Parse(cipherCharacter));
        //}

        //for (int firstLetter = aASCIIValue; firstLetter <= zASCIIValue; firstLetter++)
        //{
        //    for (int secondLetter = aASCIIValue; secondLetter <= zASCIIValue; secondLetter++)
        //    {
        //        for (int thirdLetter = aASCIIValue; thirdLetter <= zASCIIValue; thirdLetter++)
        //        {
        //            int[] key = new int[] { firstLetter, secondLetter, thirdLetter };
        //            List<int> decryptedNumbers = new List<int>();
        //            int keyIndex = 0;
        //            foreach (int cipherNumber in cipherNumbers)
        //            {
        //                decryptedNumbers.Add(cipherNumber ^ key[keyIndex]);
        //                keyIndex = (keyIndex + 1) % 3;
        //            }

        //            if (!decryptedNumbers.Contains(spaceASCIIValue))
        //            {
        //                continue;
        //            }

        //            string decryptedText = "";
        //            foreach (int decryptedNumber in decryptedNumbers)
        //            {
        //                decryptedText += $"{(char)decryptedNumber}";
        //            }

        //            if (decryptedText.Contains("the") || decryptedText.Contains("THE") || decryptedText.Contains("The"))
        //            {
        //                Console.WriteLine($"Key: {key[0]} {key[1]} {key[2]}");
        //                Console.WriteLine(decryptedText);
        //                Console.WriteLine();
        //            }
        //        }
        //    }
        //}

        //From analysis of the output, 101 120 112 is the correct key.
        string filePath = Path.Combine(Environment.CurrentDirectory, @"0059_cipher.txt");
        string cipher = File.ReadAllText(filePath);
        string[] cipherCharacters = cipher.Split(',');
        List<int> cipherNumbers = new List<int>();
        foreach (string cipherCharacter in cipherCharacters)
        {
            cipherNumbers.Add(int.Parse(cipherCharacter));
        }
        int[] key = new int[] { 101, 120, 112 };
        List<int> decryptedNumbers = new List<int>();
        int keyIndex = 0;
        foreach (int cipherNumber in cipherNumbers)
        {
            decryptedNumbers.Add(cipherNumber ^ key[keyIndex]);
            keyIndex = (keyIndex + 1) % 3;
        }
        int sum = 0;
        foreach (int decryptedNumber in decryptedNumbers)
        {
            sum += decryptedNumber;
        }
        Console.WriteLine(sum);
    }
}
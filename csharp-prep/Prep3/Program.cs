using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        int guess_number = -1;

        while (guess_number != magicNumber)
        {
            Console.Write ("What is your guess? ");
            guess_number = int.Parse(Console.ReadLine());

            if (magicNumber > guess_number)
            {
                Console.WriteLine("Go higher");
            }

            else if  (magicNumber < guess_number)
            {
                Console.WriteLine("Go lower");
            }

            else
            {
                Console.WriteLine("Excellent you guessed the number!");
            }

        }

    }
}

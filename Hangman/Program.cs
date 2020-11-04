using System;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Hangman application! Let's Play");
            
            Console.Write("Please enter a word: ");
            string secretWord = Console.ReadLine();

            bool wordTest = secretWord.All(char.IsLetter);

            while(wordTest == false || secretWord.Length == 0)
            {
                Console.Write("Your word can only contain letters. Please enter a new word: ");
                secretWord = Console.ReadLine();
                wordTest = secretWord.All(char.IsLetter);
            }

            secretWord = secretWord.ToUpper();

            Console.Clear();

            int lives = 5;
            int counter = -1;
            int wordLength = secretWord.Length;
            char[] secretArray = secretWord.ToCharArray();
            char[] printArray = new char[wordLength];
            char[] guessedLetters = new char[26];
            int numberStore = 0;
            bool victory = false;

            foreach(char letter in printArray)
            {
                counter++;
                printArray[counter] = '-';
            }

            while(lives > 0)
            {
                counter = -1;
                string printProgress = string.Concat(printArray);
                bool letterFound = false;
                int mulitples = 0;

                if(printProgress == secretWord)
                {
                    victory = true;
                    break;
                }

                if(lives > 1)
                {
                    Console.WriteLine($"You have {lives} left!");
                }
                else
                {
                    Console.WriteLine($"You only have {lives} left");
                }

                Console.WriteLine("currentprogress: " + printProgress);
                Console.Write("\n\n\n");
                Console.Write("Guess a letter: ");
                string playerGuess = Console.ReadLine();

                bool guessTest = playerGuess.All(char.IsLetter);

                while(guessTest == false || playerGuess.Length != 1)
                {
                    Console.Write("Your word can only 1 letter. Please try again: ");
                    playerGuess = Console.ReadLine();
                    guessTest = secretWord.All(char.IsLetter);
                }

                playerGuess = playerGuess.ToUpper();
                char playerChar = Convert.ToChar(playerGuess);

                if(guessedLetters.Contains(playerChar) == false)
                {
                    guessedLetters[numberStore] = playerChar;
                    numberStore++;

                    foreach(char letter in secretArray)
                    {
                        counter++;
                        if(letter == playerChar)
                        {
                            printArray[counter] = playerChar;
                            letterFound = true;
                            mulitples++;
                        }
                    }

                    if(letterFound)
                    {
                        Console.WriteLine($"Found {mulitples} letter {playerChar}.");
                    }
                    else
                    {
                        Console.WriteLine($"No letter {playerChar}!");
                        lives--;
                    }
                    Console.WriteLine(GallowView(lives));
                }
                else
                {
                    Console.WriteLine($"You already guessed {playerChar}!");
                }
            }

            if (victory)
            {
                Console.WriteLine($"The word was {secretWord}!");
                Console.WriteLine("You win, congrats!");
            }
            else
            {
                Console.WriteLine($"The word was {secretWord}!");
                Console.WriteLine("You lose...");
            }
        }

        private static string GallowView(int livesLeft)
        {
            string drawHangman = "";

            if (livesLeft < 5)
            {
                drawHangman += "--------\n";
            }

            if (livesLeft < 4)
            {
                drawHangman += "       |\n";
            }

            if (livesLeft < 3)
            {
                drawHangman += "       O\n";
            }

            if (livesLeft < 2)
            {
                drawHangman += "      /|\\ \n";
            }

            if (livesLeft == 0 )
            {
                drawHangman += "      / \\ \n";
            }

            return drawHangman;
        }
    }
}

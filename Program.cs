using System;

namespace MastermindGameApp
{
    class MastermindGame
    {
        private readonly string _secretCode;
        private readonly int _maxAttempts;
        private int _attemptsUsed;

        public MastermindGame(string code, int attempts)
        {
            _secretCode = code;
            _maxAttempts = attempts;
            _attemptsUsed = 0;
        }

        public MastermindGame() : this(GenerateRandomCode(), 10) { }

        // Generates a random 4-digit code using digits from 0 to 7 without duplication
        private static string GenerateRandomCode()
        {
            Random rnd = new Random();
            char[] code = new char[4];
            int count = 0;

            while (count < 4)
            {
                char digit = (char)('0' + rnd.Next(0, 8));
                if (Array.IndexOf(code, digit) == -1)
                {
                    code[count++] = digit;
                }
            }

            return new string(code);
        }

        // Checks a user's guess against the secret code and returns whether the game should end
        public bool CheckGuess(string guess)
        {
            _attemptsUsed++;

            int wellPlaced = 0;
            int misplaced = 0;

            bool[] secretMatched = new bool[4];
            bool[] guessMatched = new bool[4];

            // First pass: count well-placed digits
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == _secretCode[i])
                {
                    wellPlaced++;
                    secretMatched[i] = true;
                    guessMatched[i] = true;
                }
            }

            // Second pass: count misplaced digits
            for (int i = 0; i < 4; i++)
            {
                if (guessMatched[i]) continue;

                for (int j = 0; j < 4; j++)
                {
                    if (!secretMatched[j] && guess[i] == _secretCode[j])
                    {
                        misplaced++;
                        secretMatched[j] = true;
                        break;
                    }
                }
            }

            Console.WriteLine($"Well placed pieces: {wellPlaced}");
            Console.WriteLine($"Misplaced pieces: {misplaced}");

            if (wellPlaced == 4)
            {
                Console.WriteLine("Congratz! You did it!");
                return true;
            }

            if (_attemptsUsed >= _maxAttempts)
            {
                Console.WriteLine("Game over. You've used all attempts.");
                Console.WriteLine($"The secret code was: {_secretCode}");
                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string code = null;
            int attempts = 10;

            // Parse command-line arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-c" && i + 1 < args.Length)
                {
                    code = args[i + 1];
                    i++;
                }
                else if (args[i] == "-t" && i + 1 < args.Length && int.TryParse(args[i + 1], out int parsedAttempts) && parsedAttempts > 0)
                {
                    attempts = parsedAttempts;
                    i++;
                }
            }

            // Validate provided code
            if (!IsValidCode(code))
            {
                code = null;
            }

            MastermindGame game = code != null
                ? new MastermindGame(code, attempts)
                : new MastermindGame();

            Console.WriteLine("Can you break the code? Enter a valid guess.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input == null)
                    break; // Handle EOF (Ctrl+D)

                input = input.Trim();

                if (!IsValidCode(input))
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }

                if (game.CheckGuess(input))
                    break;
            }
        }

        // Validates that the input is a 4-digit number from 0 to 7 with no duplicates
        static bool IsValidCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || code.Length != 4)
                return false;

            foreach (char c in code)
            {
                if (c < '0' || c > '7')
                    return false;
            }

            return HasNoDuplicates(code);
        }

        static bool HasNoDuplicates(string code)
        {
            for (int i = 0; i < code.Length; i++)
                for (int j = i + 1; j < code.Length; j++)
                    if (code[i] == code[j])
                        return false;

            return true;
        }
    }
}


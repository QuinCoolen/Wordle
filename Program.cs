namespace Wordle
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string word = ChooseRandomWord();
      string guess = "";
      char[] progress = new string('_', word.Length).ToCharArray();
      int attempts = 0;

      while (guess != word)
      {
        guess = PromptForGuess();

        if (guess.Length != 5)
        {
          Console.WriteLine("Your guess must be 5 characters long.");
          continue;
        }

        attempts++;
        CompareWords(word, guess, ref progress);

        if (guess == word)
        {
          Console.WriteLine($"You guessed the word {word} in {attempts} attempts!");
          break;
        }
        else
        {
          Console.WriteLine($"Progress: {new string(progress)}");
        }
      }
    }

    public static string ChooseRandomWord()
    {
      string[] words = new string[] {
        "apple",
        "brush",
        "crane",
        "drake",
        "eagle",
        "flame",
        "grape",
        "haste",
        "inbox",
        "jolly",
        "knock",
        "lemon",
        "mango",
        "night",
        "ocean",
        "pilot",
        "quill",
        "river",
        "scale",
        "trace"
      };

      Random random = new();
      int index = random.Next(words.Length);
      string word = words[index];
      return word;
    }

    public static string PromptForGuess()
    {
      Console.WriteLine("Enter your guess: ");
      string guess = (Console.ReadLine()?.Trim().ToLower()) ?? throw new Exception("Guess cannot be null.");
      return guess;
    }

    static void CompareWords(string hiddenWord, string userGuess, ref char[] progress)
    {
      for (int i = 0; i < userGuess.Length; i++)
      {
        if (hiddenWord[i] == userGuess[i])
        {
          progress[i] = userGuess[i];
        }
      }
    }
  }
}
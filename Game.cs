using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;

namespace Spaceman
{
	class Game
	{
		
		private string[] codeWordOption = new string[] { "Zappata", "Eriksen", "Abrakadabra", "developper"};

		public string CodeWord { get; private set; }
		public string CurrentWord { get; private set; }
		public int MaximumNumberOfGuess { get; private set; }
		public int CurrentNumberOfWrongGuess { get; private set; }
		

		/// <summary>
		///  An instance of the Ufo class — to print the UFO images
		/// </summary>
		private Ufo ufo = new Ufo();


		/// <summary>
		/// a constructor that:
		///Sets the codeword to a random value in the array of strings
		///	Sets the maximum guesses to 5 — there are only 5 wrong guesses before the abduction is complete
		///	Sets the wrong guesses to 0
		///Sets the current word to a string of underscores(_) that is the same length as the codeword
		/// </summary>

		public Game()
		{
			
			Random rnd = new Random();
			int randomIndex = rnd.Next(codeWordOption.Length);
			CodeWord = codeWordOption[randomIndex];

			MaximumNumberOfGuess = 5;
			CurrentNumberOfWrongGuess = 0;
			for (int i = 0; i < CodeWord.Length; i++)
			{

				CurrentWord += "_";
			}
		}

		public void Greet()
		{
			Console.WriteLine("=============");
			Console.WriteLine("UFO: The Game");
			Console.WriteLine("=============");
			Console.WriteLine("Instructions: save your friend from alien abduction by guessing the letters in the codeword.");
		}
		/// <summary>
		/// will return true when the current word matches the codeword.
		/// </summary>
		public bool DidWin()
		{
			if (CodeWord.Equals(CurrentWord))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		///  We also need to check if the player lost
		///  DidLose() method that returns true when the number of wrong guesses is greater than or equal to the max number of guesses.
		/// </summary>
		public bool DidLose()
		{
			if (CurrentNumberOfWrongGuess >= MaximumNumberOfGuess)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// print all the necessary game information to the screen including the UFO, the currentWord, the number of wrong guesses
		/// </summary>
		public void Display()
		{
			Console.WriteLine(ufo.Stringify());
			Console.WriteLine($"Current word is: {CurrentWord}");
			Console.WriteLine($"Remaining Number of Guess: {CurrentNumberOfWrongGuess}");
		}
		///<summary>
		///this method capture the user's input letter(it has to be one letter at a time), checks if that letter is indeed anywhere
		///in the codeword. If yes print those leters at the exact places in the codeword. If the codeword does not contains the user's guess
		///increase the wrongGuess counter by 1
		/// </summary>

		public void Ask()
		{
			Console.WriteLine("Guess a letter: ");
			string userGuess = Console.ReadLine();
			string userGuessWithoutSpace = userGuess.Trim();
			while (userGuessWithoutSpace.Length != 1)
			{
				Console.WriteLine("Please enter one letter at a time");
			}
			char guess = userGuessWithoutSpace.ToCharArray()[0];
			if (CodeWord.Contains(guess))
			{
				Console.WriteLine("Here are your guess in the codeWord!");
				for (int i = 0; i < CodeWord.Length; i++)
				{
					if (guess == CodeWord[i])
					{
						CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
					}
				}
			}
			else
			{
				Console.WriteLine("Sorry, your guess does not appear in the the codeWord");
				CurrentNumberOfWrongGuess++;
				ufo.AddPart();
			}
		}


	}
}
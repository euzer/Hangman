using System;
using System.ComponentModel.DataAnnotations;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
            Game game = new Game();
            game.Greet();
            do
            {
                game.Display();
                game.Ask();
                if (game.DidLose())
                {
                    game.Display();
                    Console.WriteLine("You loose the game!");
                    break;
                }
                else if (game.DidWin())
                {
                    game.Display();
                    Console.WriteLine("Congratulations! You are the Winner and saver!");
                    break;
                }

            } while (true);
    }
  }
}

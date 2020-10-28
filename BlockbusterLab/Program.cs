using System;

namespace BlockbusterLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blockbuster!");
            ConsoleFormatter.MakeLineSpace(1);
            
            // Initiate a BlockBuster instance and prompt the user to pick a movie
            BlockBuster bb = new BlockBuster();
            Movie selectedMovie = bb.Checkout();
            
            selectedMovie.PrintInfo(); // Print the selected movie's information

            // Prompt user if they want to watch that movie
            if(!(ConsoleFormatter.AskToContinue("Would you like to watch this movie?")))
            {
                // Additional prompt to see if they just want to skip all other menus and just watch the move
                //   through calling the PlayWholeMovie method.
                if (!(ConsoleFormatter.AskToContinue("Would you like to watch it all at once?")))
                {
                    selectedMovie.PlayWholeMovie();
                }
                else
                {
                    // Run the appropriate Watch method based on the Movie's subclass type
                    if ((selectedMovie.GetType()).ToString().Contains("VHS"))
                    {
                        VHS selectedVHS = (VHS)selectedMovie;
                        Console.WriteLine("VHS inserted! Movie is done loading!");
                        ConsoleFormatter.PauseByAnyKey();
                        WatchVHS(selectedVHS);
                    }
                    else if ((selectedMovie.GetType()).ToString().Contains("DVD"))
                    {
                        DVD selectedDVD = (DVD)selectedMovie;
                        Console.WriteLine("DVD inserted! Movie is done loading!");
                        ConsoleFormatter.PauseByAnyKey();
                        WatchDVD(selectedDVD);
                    }
                }
            }
            ConsoleFormatter.MakeLineSpace(1);
            Console.WriteLine("Thank you for your patronage! Have a nice day!");
        }

        // Allows the user to play a VHS scene-by-scene, rewind back to the beginning or stop once they decide they are done watching through
        //   menu prompts.
        // Only applies to VHS.
        public static void WatchVHS(VHS vhs)
        {
            while (true)
            {
                // Display available commands and prompt user to enter a keyword
                Console.WriteLine("Enter 'Play' to watch the next scene.");
                Console.WriteLine("Enter 'Rewind' back to the beginning.");
                Console.WriteLine("Enter 'Stop' to stop watching the movie.");
                string movieInput = ConsoleFormatter.PromptForInput("Enter next command: ");
                
                // Run the appropriate action based on the keyword given, invalid inputs will simply prompt again
                if ((movieInput.ToLower()).Equals("play"))
                {
                    vhs.Play();
                }
                else if ((movieInput.ToLower()).Equals("rewind"))
                {
                    vhs.Rewind();
                }
                else if ((movieInput.ToLower()).Equals("stop"))
                {
                    ConsoleFormatter.MakeLineSpace(1);
                    Console.WriteLine("Returning to Menu!");
                    ConsoleFormatter.PauseByAnyKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Action not recognized. Please enter 'Play', 'Rewind' or 'Stop'.");
                }
                ConsoleFormatter.PauseByAnyKey();
            }
        }

        // Allows the user to play a DVD scene-by-scene, with scenes selected through user input. User is then prompted if they want to continue watching.
        // Only applies to DVD.
        public static void WatchDVD(DVD dvd)
        {
            while (true)
            {
                dvd.Play(); // Run the prompt to select a scene

                // Prompt user if they want to watch another scene
                bool watchMore = !(ConsoleFormatter.AskToContinue("Would you like to watch another scene?"));
                if (!watchMore)
                {
                    Console.WriteLine("Returning to Menu!");
                    ConsoleFormatter.PauseByAnyKey();
                    break;
                }
                Console.Clear();
            }
        }
    }
}

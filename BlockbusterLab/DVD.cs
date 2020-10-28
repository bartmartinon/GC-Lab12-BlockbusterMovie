using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    class DVD : Movie
    {
        // Fields/Properties

        // None

        // Constructors

        public DVD(string Title, Genre Category, int RunTime, List<String> Scenes)
            : base(Title, Category, RunTime, Scenes)
        {
            // No other property assignment needed
        }

        // "Plays" the DVD by prompting the user to select a scene from the DVD's Scenes list.
        // Overriden from Movie
        public override void Play()
        {
            while (true)
            {
                PrintScenes();
                string sceneSelection = ConsoleFormatter.PromptForInput("Select a scene from above to view: ");
                try
                {
                    int sceneIndex = int.Parse(sceneSelection);
                    if (sceneIndex < 0 || sceneIndex >= Scenes.Count)
                    {
                        Console.WriteLine("Error: Option not available. Please enter an integer shown above.");
                    }
                    else
                    {
                        ConsoleFormatter.MakeLineSpace(1);
                        Console.WriteLine("---");
                        Console.WriteLine(sceneIndex + ": " + Scenes[sceneIndex]);
                        Console.WriteLine("---");
                        ConsoleFormatter.MakeLineSpace(1);
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Non-integer value. Please enter an integer!");
                }
                ConsoleFormatter.PauseByAnyKey();
            }
        }
    }
}

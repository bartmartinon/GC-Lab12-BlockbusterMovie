using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    class VHS : Movie
    {
        // Fields/Properties
        public int CurrentTime { get; set; } = 0;
        
        // Constructors
        
        public VHS(string Title, Genre Category, int RunTime, List<String> Scenes)
            : base(Title, Category, RunTime, Scenes)
        {
            // No other property assignment needed
        }

        // "Plays" the scene at the current time and then increments the CurrentTime value
        // Increments as long as the movie is "not finished"
        // Overriden from Movie
        public override void Play()
        {
            if (CurrentTime < Scenes.Count) // Movie is not finished
            {
                string scene = Scenes[CurrentTime]; // Grab current scene and display it
                ConsoleFormatter.MakeLineSpace(1);
                Console.WriteLine("---");
                Console.WriteLine(CurrentTime + ": " + scene);
                Console.WriteLine("---");
                ConsoleFormatter.MakeLineSpace(1);
                CurrentTime++; // Iterate for next scene
            }
            else // Movie is finished
            {
                Console.WriteLine("FIN - Movie finished. Please rewind.");
            }

        }

        //"Rewinds" the movie by setting CurrentTime to 0
        public void Rewind()
        {
            CurrentTime = 0; // Scene 0 is up next
            ConsoleFormatter.MakeLineSpace(1);
            Console.WriteLine("---");
            Console.WriteLine("Rewinded!");
            Console.WriteLine("---");
            ConsoleFormatter.MakeLineSpace(1);
        }
    }
}

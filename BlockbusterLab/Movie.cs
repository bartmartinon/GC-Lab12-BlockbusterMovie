using System;
using System.Collections.Generic;
using System.Text;

namespace BlockbusterLab
{
    abstract class Movie
    {
        // Fields/Properties
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int RunTime { get; set; }
        public List<string> Scenes { get; set; }

        // Constructors

        public Movie(string Title, Genre Category, int RunTime, List<string> Scenes)
        {
            this.Title = Title;
            this.Category = Category;
            this.RunTime = RunTime;
            this.Scenes = Scenes;
        }

        // Methods

        // Prints all Movie properties into the console
        public virtual void PrintInfo()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Name: " + Title);
            Console.WriteLine("Category: " + Category);
            Console.WriteLine("Runtime: " + RunTime);
            //PrintScenes();
            Console.WriteLine("-------------------");
        }

        // Prints all scenes ordered by their index
        public void PrintScenes()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Scenes: ");
            for (int i = 0; i < Scenes.Count; i++)
            {
                string scene = Scenes[i];
                Console.WriteLine($"  {i}: {scene}");
            }
            Console.WriteLine("-------------------");
        }

        // "Plays" the whole movie at once, from start to finish by displaying each scene in the appropriate order
        public void PlayWholeMovie()
        {
            Console.WriteLine("Playing whole movie!");
            ConsoleFormatter.MakeLineSpace(1);
            for (int i = 0; i < Scenes.Count; i++)
            {
                Console.WriteLine(i + ": " + Scenes[i]);
            }
            ConsoleFormatter.MakeLineSpace(1);
            Console.WriteLine("Finished!");
        }

        // Abstract Methods (Stubs)
        public abstract void Play();
    }
}

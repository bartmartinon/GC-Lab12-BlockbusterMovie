using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BlockbusterLab
{
    class BlockBuster
    {
        // Fields/Properties
        public List<Movie> Movies { get; set; } 
        public List<string> Genres { get; set; }

        // Constructors
        public BlockBuster()
        {
            // Initialize Data
            Movies = new List<Movie>();

            List<string> scenes1 = new List<string>
            {
                "I'm the lord of the globe!", "Jackson and Maria kiss.", "The ship has sprung a big leak.",
                "The ship has sunk. Jackson is gone.", "It's been 84 years, I think."
            };
            VHS v1 = new VHS("Gigantic", Genre.Romance, 194, scenes1);

            List<string> scenes2 = new List<string>
            {
                "Montana Smith travels to the Amazon.", "He meets his kid and things are awkward.", 
                "There's a skull made of diamonds.", "Evil people go to Amazon to unlock skull's secrets", 
                "Big bad evil lady betrays everyone and is greedy for the secret.", "Suddenly, aliens! ...why not?",
                "Evil lady unlocks secret of the universe and disappears/dies because it's too much.",
                "Montana and son go home."
            };
            VHS v2 = new VHS("Montana Smith and the Diamond Cranium", Genre.Action, 122, scenes2);

            List<string> scenes3 = new List<string>
            {
                "Sir Fantastic saves the day!", "He saved the wrong person.", "Heroes are illegal now.",
                "Sir Fantastic and Rubberwoman retire and start a family.", "Sir Fantastic starts doing secret hero work with Coolplace.",
                "He's recruited by a secret organization that's actually evil.", "Super family comes to the island to save Sir Fantastic",
                "VillainGuy unleashes giant robot in the City of ThatPlace!", "People want superheroes to help, despite the illegal thing.",
                "The Fantastics save the day!", "Superheroes are legal again!"
            };
            VHS v3 = new VHS("The Fantastics", Genre.Action, 115, scenes3);

            List<string> scenes4 = new List<string>
            {
                "The Fantastics lost their home.", "Things are pretty rough. 24/7 Parenting duties, and superheroics kinad illegal, (it's complicated)", 
                "Rubberwoman gets the chance and the tech to do some heroics.", "Sir Fantastic is stuck deal with kids, Mauve and Sprint.", 
                "Rubberwoman is recruited by eccentric billionaire that wants to bring back superheroes to the spotlight.",
                "Rubberwoman's side job allows family to move to new home.", "Rubberwoman meets other superheroes", "Sir Fantastic is becoming a much better dad", 
                "New unknown villain appears and starts hypnotizing people to do crime.", "Surprise! The villain is actually the billionaire's sister.",
                "Sister hate heroes because they made people lazy.", "Her parents were killed in a home invasion while trying to rely on heroes that never came.",
                "Rubberwoman and others are hypnotized.", "The other Fantastics and Coolplace storm in and save everyone."
            };
            DVD d1 = new DVD("The Fantastics 2", Genre.Action, 118, scenes4);

            List<string> scenes5 = new List<string>
            {
                "Spencer Settler meets a girl.", "Settler falls in love with Rayne Fields.", "Rayne tells Spencer that her eight evil ex-boyfriends must be defeated to save their love.",
                "Spencer fights everyone in a video game.", "Spencer dies.", "Spencer gets an extra life through the power of love and friendship!", 
                "The big final boss ex-boyfriend leader is defeated!", "They eat pizza and live happily ever after."
            };
            DVD d2 = new DVD("Spencer Settler Against The Planet", Genre.Comedy, 112, scenes5);

            List<string> scenes6 = new List<string>
            {
                "Someone watches paint dry.", "An hour passes.", "He touches the paint.", "It's still dry.", "Oh no, the horror!", "He needs to wash his hands now.", "The wall changed colors."
            };
            DVD d3 = new DVD("The Paint", Genre.Horror, 112, scenes6);

            Movies.Add(v1);
            Movies.Add(v2);
            Movies.Add(v3);
            Movies.Add(d1);
            Movies.Add(d2);
            Movies.Add(d3);
        }

        // Prints all Movies from the current Movie list
        public void PrintMovies()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Current Viewings:");
            Console.WriteLine("----------------------------------------");
            ConsoleFormatter.MakeLineSpace(1);
            for (int i = 0; i < Movies.Count; i++)
            {
                Movie m = Movies[i];
                Console.WriteLine("  " + i + ": " + m.Title);
            }
            ConsoleFormatter.MakeLineSpace(1);
            Console.WriteLine("========================================");
            ConsoleFormatter.MakeLineSpace(1);
        }

        // Prompts the user to select a movie from the given list by index value
        // Returns the movie in the specified valid index
        public Movie Checkout()
        {
            PrintMovies();
            Movie output;
            while (true) {
                string input = ConsoleFormatter.PromptForInput("Please select a movie from the following list: ");
                try
                {
                    int index = int.Parse(input);
                    if (index < 0 || index >= Movies.Count)
                    {
                        Console.WriteLine("Error: Option not available. Please enter an integer shown above.");
                    }
                    else
                    {
                        output = Movies[index];
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Non-integer value. Please enter an integer!");
                }
            }
            return output;
        }
    }
}

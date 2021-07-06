using System;
using System.Collections.Generic;

namespace Assignment2_ScrabbleScorer_csharp
{
    public class Program
    {
        //Here is the original OldPointStructure dictionay
        public static Dictionary<int, string> oldPointStructure = new Dictionary<int, string>()
        {
            {1, "A, E, I, O, U, L, N, R, S, T"},
            {2, "D, G"},
            {3, "B, C, M, P" },
            {4, "F, H, V, W, Y" },
            {5, "K" },
            {8, "J, X" },
            {10, "Q, Z" }
        };

        public static Dictionary<char, int> newPointStructure = Transform();


        






        //Code your Transform method here
        static Dictionary<char,int> Transform()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>(); // declare dictionary that will be returned 
            foreach (var i in oldPointStructure)
            {
                char[] arr = oldPointStructure[i.Key].ToLower().ToCharArray(); // make the string values into char arrays 

                foreach (char j in arr) 
                {
                    if (j >= 97 && j <= 122) // filter out any nonalphabetical characters 
                    {
                        dict[j] = i.Key; // add to new dictionary, individual characters as keys, keys from old dictionary as values 
                    }
                }


                
            }
            return dict;
        }






        //Code your Scoring Option methods here

        


        //SimpleScorer-----
        public static int SimpleScorer(string word)
        {
            Console.WriteLine($"The word {word} has a score of {word.Length}\n");
            return word.Length; // score is = to the length of the word 

        }
        //public static void SimpleScorer()
        //{

        //}


        //BonusVowels-----
        public static int BonusVowels(string word)
        {
            
            List<char> vowles = new List<char> {'a','e','i','o','u'};
            int score = word.Length;

            foreach (char i in word) // find all vowels in word and add 2 points per 
            {
                if (vowles.Contains(i))
                {
                    score += 2;
                }

            }
            Console.WriteLine($"The word {word} has a score of {score}\n");
            return score;
        }




        //ScrabbleScorer-----
        public static int ScrabbleScorer(string word)
        {
            
            int points = 0;
            foreach (char i in word)
            {
                points += newPointStructure[i]; // add points equal to the value assigned to the character in the new dictionary 
            }
            Console.WriteLine($"The word {word} has a score of {points}\n");
            return points;
        }





        //Code your ScoringAlgorithms method here

        static int ScoringAlgorithms(string word, string choice)
        {
            if (choice == "2") // invokes another method based on arguments 
            {
                return SimpleScorer(word);
            }
            else if (choice == "3")
            {
                return BonusVowels(word);
            }
            else
            {
                return ScrabbleScorer(word);
            }
        }





        //Code your InitialPrompt method here

        static string InitialPrompt()
        {
            List<string> validChoices = new List<string> {"1","2","3","stop"};
            string input;
            do // validate user input 
            {
                Console.WriteLine("Welcome to Scrabble Scorer! \n Please choose a scoring algoriths:\n1-Scrabble\n2-Simple Score\n3-Bonus Vowles\n or type \"stop\"");
                input = Console.ReadLine().ToLower().Trim();
            }
            while (!validChoices.Contains(input));

            return input;
        }






        //Code your RunProgram method here

        static void RunProgram()
        {
            string choice;
            string word;
            bool invalidWord;
            

            while (true) // go until user enters "stop"
            {
                choice = InitialPrompt();
                if (choice.ToLower() == "stop")
                {
                    break;
                }
                do
                {
                    invalidWord = false;
                    Console.WriteLine("Please enter a word");
                    word = Console.ReadLine().ToLower().Trim();
                    foreach (char i in word)
                    {
                        if (i < 97 || i > 122)
                        {
                            invalidWord = true;  // validate user input                          
                        }
                        
                    }
                    if (invalidWord)
                    {
                        Console.WriteLine("Words can only contain letters. Please enter another word: ");
                    }

                }
                while (invalidWord);

                switch(choice)
                {
                    case "3":
                        BonusVowels(word);
                        break;
                    case "2":
                        SimpleScorer(word);
                        break;
                    default:
                        ScrabbleScorer(word);
                        break;

                }    


            }
               

        }






        static void Main(string[] args)
        {
            //Call your RunProgram method here
            Transform();

            RunProgram();

            /*
            ScoringAlgorithms("taxi", "1");
            ScoringAlgorithms("taxi", "2");
            ScoringAlgorithms("taxi", "3");

            
            foreach (var i in newPointStructure)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(ScrabbleScorer("taxi"));
            Console.WriteLine(SimpleScorer("taxi"));
            Console.WriteLine(BonusVowels("taxi"));
            */






        }
    }
}

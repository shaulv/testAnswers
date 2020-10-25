using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3
{
    public class WordGame : Game
    {
        string selectedWord = "";
        string userProgress = "";
        int guessCounter = 0;
        string[] wordsArr = new string[]
        {
            "hello",
            "class",
            "popular",
            "love",
            "hate",
            "olive",
            "mother",
            "father"
        };

        public void SelectWord()
        {
            Random random = new Random();
            int index = random.Next(0, wordsArr.Length - 1);
            selectedWord = wordsArr[index];

            for (int i = 0; i < selectedWord.Length; i++)
            {
                userProgress += "-";
            }
            Console.WriteLine(ToString());
            AskToGuessLetters();
        }

        public void AskToGuessLetters()
        {
            Console.WriteLine("\nGuess a letter:");
            char letter = Convert.ToChar(Console.ReadLine());
            if(Char.IsLetter(letter))
            {
                GuessLetters(letter);
            }
            else
            {
                Console.WriteLine("please guess only a letter, try again...");
                AskToGuessLetters();
            } 

        }

        public void GuessLetters(char letter)
        {
            guessCounter++;

            string gotLetter = "" + letter;
            gotLetter = gotLetter.ToLower();
            letter = gotLetter[0];

            string userProg = "";
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if(userProgress[i] == '-' && letter == selectedWord[i])
                    userProg += selectedWord[i];
                else if(userProgress[i] != '-')
                    userProg += selectedWord[i];
                else
                    userProg += '-';
            }

            userProgress = userProg;
            Console.WriteLine(ToString());

            bool checkIfWon = true;
            foreach (char ltr in userProgress)
            {
                if (ltr == '-')
                    checkIfWon = false;
            }

            if(checkIfWon)
            {
                Won();
            } else
            {
                AskToGuessLetters();
            }
            
        }

        public void Won()
        {
            Console.WriteLine($"You have won!!!!\nYour gussing count is: {guessCounter}\nDo you want to start a new game?\n1.YES\n2.NO");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == 1)
                NewGame();
            else
                Console.WriteLine("Bye Bye");
        }

        public void NewGame()
        {
            Console.Clear();

            selectedWord = "";
            userProgress = "";
            guessCounter = 0;
            SelectWord();
        }

        public override string ToString()
        {
            return userProgress;
        }
    }
}

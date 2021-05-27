using System;
using static System.Console;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {                     
            char a = 'y';
            while (a == 'y') 
            { 
                bool flagGameEnd = false;
                bool flagCorrectlLetter;
                Write("How many letter does the word contain: ");
                int wordLength = Int32.Parse(ReadLine());
                char[] letters = new char[wordLength];
                char[] progress = new char[wordLength];
                Write("Enter the word: ");
                string word = ReadLine();
                int life = letters.Length;
                Clear();
                


                letters = word.ToCharArray();
                int count = 0;
                WriteLine("Guess the letters of the word: ");
                for (int i = 0; i < letters.Length ; i++)           //Mask word with *
                {
                    progress[i] = '*';
                    Write(progress[i]);
                }
                WriteLine();

                while (life > 0)
                {
                    char guess = Char.Parse(ReadLine());
                    Clear();
                    flagCorrectlLetter = false;
                    for (int i =0; i<letters.Length; i++)           //check if letter guessed correctly    
                    {
                        for (int j=0; j<letters.Length; j++)        //flag correctly guessed letter
                        {
                            if (guess == letters[j])
                            {
                                flagCorrectlLetter = true;                               
                            }
                        }
                        if (guess == letters[i])                    //Replace * with correctly guessed letter
                        {
                            count++;                        
                            progress [i] = letters[i];                                                            
                        }
                        
                    }
                    if (!flagCorrectlLetter)                                     //flag wrong letter
                    {
                        WriteLine($"{guess} is not in the word.");
                        life--;                       
                        WriteLine($"Life remaining: {life}");
                        
                    }
                    
                    for (int i = 0; i < letters.Length; i++)        //Display progress 
                    {                      
                        Write(progress[i]);                  
                    }
                    WriteLine();
                    if (flagCorrectlLetter)
                    {
                        WriteLine($"Life remaining: {life}");
                        
                    }

                    for (int i = 0; i < letters.Length; i++)        //Check whether all the correct letters have been guessed
                    {
                        if (progress[i] == letters[i])              //flag is true if all letters are guessed correctly
                        {
                            flagGameEnd = true;
                        }
                        else
                        {
                            flagGameEnd = false;                           //flag when word hasn't been guessed
                            break;
                        }
                    }
                    if (flagGameEnd)
                    {
                        break;
                    }
                }


                if (flagGameEnd)                                          //End game             
                {
                    Write("Congrats! You win! ");
                }

                if (life == 0)
                {
                    WriteLine("Game Over. ");
                    Write("The correct word is: ");
                    foreach (var item in letters)
                    {
                        Write(item);
                    }
                    WriteLine();

                }

                Write("Play Again? Y/N ");                          //Play Again Y/N
                a = Char.Parse(ReadLine());
                Clear();
            }

            ReadKey();

            
        }
    }
}

/* Cole Madeley
 * Assignment 1 
 * This is a small text based game that generates a random integer and allows the user to guess what it could be
 * The user has a limited number of guesses and hints they may use
 */

using System;

class Program
{
    static void Main()
    {
        //declare global variables
        Random random = new Random(); //Random number generator for game
        int randomNum = random.Next(1, 100); //generate number and store
        int hintAmount = 3; //maximum number of hints
        int guessAmount = 20; //maximum amount of guess attempts
        int guess = 0; //converted string data stored as int
        string input = ""; //initial user input stored as string
        bool isMatching = false; ; //stores whether or not input and guess are matching

        Console.WriteLine("This is a number guessing game! You have three hints!");
        Console.WriteLine("You have 20 attempts to find the number. You can type 'hint' at any time to redeem one of your hints! Lets get into it!");

        for (int i = 1; i <= guessAmount; i++) //loops for every guess the user has remaining (20 times)
        {
            if (i == 20) //If loop is on last iteration
            {
                Console.Write("LAST GUESS: ");
            }
            else //any guess number (loop iteration) besides the last one 
            {
                Console.Write($"Guess {i}: ");
            }

            input = Console.ReadLine(); //Take user input and store

            if (input == "hint" && hintAmount > -1) //If the user still has hints, run
            {
                hintAmount = hintAmount - 1; //Take away one hint from count

                if (hintAmount == 2) //If hint was typed one time
                {
                    
                    if (randomNum % 2 == 0) //If the random number is divisible evenly by 2
                    {
                        Console.WriteLine("Your number is even!");
                    } 
                    else if (randomNum % 2 != 0) //If the random number is NOT divisible evenly by 2
                    {
                        Console.WriteLine("Your number is odd!");
                    }
                    Console.WriteLine($"You have {hintAmount} hints left.");
                }
                else if (hintAmount == 1) //If hint was typed twice
                {

                    if(randomNum <= 50) //If the generated number is less than 50 tell the user
                    {
                        Console.WriteLine("Hint: The number is in the lower half (1-50)"); 
                    } else if (randomNum > 50) //If the generated number is greater than 50 tell the user
                    {
                        Console.WriteLine("Hint: The number is in the upper half (51-100).");
                    }
                    
                    Console.WriteLine($"You have {hintAmount} hints left."); //Number of hints appended to string
                }
                else if (hintAmount == 0) //If hint was typed thrice 
                {
                    Console.WriteLine($"Hint: The number is within 15 of {randomNum + 5}."); 
                    Console.WriteLine($"You have {hintAmount} hints left.");
                }
                else if (hintAmount == -1) //If out of hints 
                {
                    Console.WriteLine("Sorry! You're all out of hints ");
                }

                Console.WriteLine(""); //spacing

                i--; //refund a guess chance by looping once more ('i' determines what loop iteration we're on)
                continue; //get out of the loop to next
            }

            guess = int.Parse(input); //convert user string input to int and store
            if (guess == randomNum) //If inputted number is the same as the generated number
            {
                isMatching = true; //Set bool to true
            }

            {
                if (isMatching == true) //If they are matching, end the program
                {
                    Console.WriteLine("Congratulations! You guessed the number!");
                    return; //end
                }
                else if (guess > randomNum) //if user's inputted int is greater than the generated int
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else if (guess < randomNum) //if user's inputted int is less than the generated int
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else  //for exceptions
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100 or type 'hint'.");
                    i--; 
                }
                Console.WriteLine(""); //spacing
            }
        }

        Console.WriteLine("");
        Console.WriteLine($"you've used all your attempts. The number was {randomNum}.");
    }
}

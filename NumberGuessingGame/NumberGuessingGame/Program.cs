using System;

namespace NumberGuessingGame
{
    class Program
    {

        static void Main(string[] args)
        {
            //run through the game at least once.
            do
            {
                //Clear console.
                Console.Clear();

                #region public values
                // the lowest possible value - 1
                var lowerBound = 1;

                // WHighest Number + 1
                var upperBound = 100;

                //declare userGuess as a number outside of the possible range.
                var correct = false;

                // Create random number
                var target = new Random().Next(101);

                #endregion

                //Say Hi
                Greeting();

                //repeat while the user is incorrect
                while (!correct)
                {
                    //ask the user to guess and store in a variable.
                    var userGuess = UserGuess(lowerBound, upperBound);

                    //inform the user if they are higher, lower or correct.
                    correct = IsGuessCorrect(userGuess, target, ref lowerBound, ref upperBound);
                }


                // if the player wants to play again, we return to the start of the game.
            } while (PlayAgain());

            //thank the player for playing.
            ThanksForPlaying();
        }

        /// <summary>
        /// Greets the user to the application.
        /// </summary>
        private static void Greeting()
        {
            //explains the game to the user
            Console.WriteLine("Hi There! Welcome to my Guessing Game");
            Console.WriteLine("I will think of a number between 1 and 100 and you need to try and guess the number!");
            Console.WriteLine("If you guess is incorrect, I'll give you a little hint.");
            Console.WriteLine("Press any key to start");

            //pauses the application until the user inputs a keystroke
            Console.ReadKey();
        }

        /// <summary>
        /// Asks the user to guess a number
        /// </summary>
        /// <remarks>
        /// This will only return a valid integer within the range
        /// </remarks>
        /// <returns></returns>
        private static int UserGuess(int lowerBound, int upperBound)
        {
            //do until the user guesses a valid number
            while (true)
            {
                //asks the user to guess a number between the range
                Console.WriteLine($"I am thinking of a number between {lowerBound} and {upperBound}. Can you Guess What it is?");

                //save the users response as a string
                var userResponse = Console.ReadLine();

                //If the user's response can be turned into a number within the given range...
                if (int.TryParse(userResponse, out int userGuess) && userGuess <= upperBound && userGuess >= lowerBound)
                    //return the user's guess
                    return userGuess;
                //Otherwise
                else
                    // Inform the user that their guess was a number not within the range
                    Console.WriteLine($"Your guess was {userResponse}. This is not a whole number between {lowerBound} and {upperBound}.");

            }
        }

        /// <summary>
        /// Compare the number guessed by the user, to the generated number.
        /// </summary>
        /// <param name="userGuess"> The number guessed by the user. </param>
        /// <param name="target"> The target number. </param>
        /// <param name="lowerBound"> The minimum number + 1. </param>
        /// <param name="upperBound"> The maximum Number - 1. </param>
        /// <returns></returns>
        private static bool IsGuessCorrect(int userGuess, int target, ref int lowerBound, ref int upperBound)
        {
            //if the user guess is higher than the target number...
            if (userGuess > target)
            {
                // set the upperBound to the user's guess - 1
                upperBound = userGuess - 1;
                // tell the user they were incorrect
                Console.WriteLine($"You guessed {userGuess}. This was higher than the number I'm thinking of.");
                //return false
                return false;
            }
            // If the user guess is lower than the target number...
            else if (userGuess < target)
            {

                // set the lowerBound number to the user's guess + 1
                lowerBound = userGuess + 1;
                //tell the user they were incorrect
                Console.WriteLine($"You guessed {userGuess}. This was lower than the number I'm thinking of.");
                //return false
                return false;
            }
            //If we have made it to here then the user is correct
            else
            {
                //inform the user they are correct
                Console.WriteLine($"You guessed {userGuess}... THIS IS CORRECT!! WELL DONE!!");
                //return true
                return true;
            }
        }


        /// <summary>
        /// Asks the user if they would like to play again.
        /// </summary>
        /// <returns> Whether or not the player wants to play again. </returns>
        private static bool PlayAgain()
        {
            //create a continuous loop until a valid iput is received
            while (true)
            {
                Console.WriteLine("Would you like to play Again? Y/N");

                var userResponse = Console.ReadLine();

                switch (userResponse)
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine($"I'm sorry, I don't understand your response: {userResponse}");
                        break;
                }
            }

        }

        /// <summary>
        /// Thanks the user for playing the application.
        /// </summary>
        private static void ThanksForPlaying()
        {
            //thank the user
            Console.WriteLine("Thankyou for playing!");

            //pause until the user enters a keystroke
            Console.ReadKey();
        }

    }
}

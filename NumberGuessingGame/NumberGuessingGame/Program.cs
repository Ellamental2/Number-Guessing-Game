using System;

namespace NumberGuessingGame
{
    class Program
    {

        static void Main(string[] args)
        {
            // Run through the game at least once.
            do
            {
                // Clear console.
                Console.Clear();

                #region public values
                // Lowest possible value
                var lowerBound = 0;

                // Highest posible value
                var upperBound = 100;

                // Declare the users guess to be incorrect.
                var correct = false;

                // Create random number between the lower and upper bound.
                var target = new Random().Next(upperBound + 1) + lowerBound;

                #endregion

                //Say Hi
                Greeting();

                // Repeat while the user is incorrect
                while (!correct)
                {
                    // Ask the user to guess and store in a variable.
                    var userGuess = UserGuess(lowerBound, upperBound);

                    // Inform the user if they are higher, lower or correct.
                    correct = IsGuessCorrect(userGuess, target, ref lowerBound, ref upperBound);
                }


                // If the player wants to play again, we return to the start of the game.
            } while (PlayAgain());

            // Thank the player for playing.
            ThanksForPlaying();
        }

        /// <summary>
        /// Greets the user to the application.
        /// </summary>
        private static void Greeting()
        {
            // Explains the game to the user
            Console.WriteLine("Hi There! Welcome to my Guessing Game");
            Console.WriteLine("I will think of a number between 1 and 100 and you need to try and guess the number!");
            Console.WriteLine("If you guess is incorrect, I'll give you a little hint.");
            Console.WriteLine("Press any key to start");

            // Pauses the application until the user inputs a keystroke
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
            // Do until the user guesses a valid number
            while (true)
            {
                // Asks the user to guess a number between the range
                Console.WriteLine($"I am thinking of a number between {lowerBound} and {upperBound}. Can you Guess What it is?");

                // Save the users response as a string
                var userResponse = Console.ReadLine();

                // If the user's response can be turned into a number within the given range...
                if (int.TryParse(userResponse, out int userGuess) && userGuess <= upperBound && userGuess >= lowerBound)
                    // return the user's guess
                    return userGuess;
                // Otherwise
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
        /// <param name="lowerBound"> The minimum possible number </param>
        /// <param name="upperBound"> The maximum possible Number. </param>
        /// <returns></returns>
        private static bool IsGuessCorrect(int userGuess, int target, ref int lowerBound, ref int upperBound)
        {
            // If the user guess is higher than the target number...
            if (userGuess > target)
            {
                // Set the upperBound to the user's guess - 1
                upperBound = userGuess - 1;
                // Tell the user they were incorrect
                Console.WriteLine($"You guessed {userGuess}. This was higher than the number I'm thinking of.");
                // Return false
                return false;
            }
            // If the user guess is lower than the target number...
            else if (userGuess < target)
            {

                // Set the lowerBound number to the user's guess + 1
                lowerBound = userGuess + 1;
                // Tell the user they were incorrect
                Console.WriteLine($"You guessed {userGuess}. This was lower than the number I'm thinking of.");
                // Return false
                return false;
            }
            // If we have made it to here then the user is correct
            else
            {
                // Inform the user they are correct
                Console.WriteLine($"You guessed {userGuess}... THIS IS CORRECT!! WELL DONE!!");
                // Return true
                return true;
            }
        }


        /// <summary>
        /// Asks the user if they would like to play again.
        /// </summary>
        /// <returns> Whether or not the player wants to play again. </returns>
        private static bool PlayAgain()
        {
            // Create a continuous loop until a valid iput is received
            while (true)
            {
                // Ask the user if they want to play again
                Console.WriteLine("Would you like to play Again? Y/N");

                // Save the users response
                var userResponse = Console.ReadLine();

                switch (userResponse)
                {
                    // If the user said yes
                    case "Y":
                    case "y":
                    case "yes":
                    case "Yes":
                        // Return true
                        return true;
                    // If the user said no
                    case "N":
                    case "n":
                    case "no":
                    case "No":
                        // Return false
                        return false;
                    // If the input is not recognised
                    default:
                        // Inform the user that the response is not understood.
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
            // Thank the user
            Console.WriteLine("Thankyou for playing!");
            System.Console.WriteLine("Press any key to exit.");

            // Pause until the user enters a keystroke
            Console.ReadKey();
        }

    }
}

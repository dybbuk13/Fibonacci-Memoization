/*
 * Author: Jackson A. Kelley
 * Date: August 10, 2022
 * 
 * Summary: This program accepts user input to calculate the nth value of the
 *          Fibonacci Sequence. Two different implementations are included.
 *          The first is a simple recursive implementation without any
 *          optimizations. The second using the memoization method to
 *          reduce the time complexity of the algorithm.
 */

namespace FibMem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            bool test = false;
            int value = 0;
            Dictionary<int, long> memo = new Dictionary<int, long>();

            //Handles the user input. Will continue until the user prompts the program to exit.
            while(true)
            {
                Console.Write("Please enter a value or enter 'Quit' to exit the application: ");
                input = Console.ReadLine();

                //Tests if the user would like to exit the aplication or continue.
                if (input.ToUpper() == "QUIT")
                {
                    Console.WriteLine("Thank you! Have a great day!");
                    break;
                }

                //Tests if the user correctly entered an integer.
                test = int.TryParse(input, out value);
                if (test)
                    Console.WriteLine(FibMemoization(value, memo));
                else
                    Console.WriteLine("Please only enter a number.");
            }

            //Console.WriteLine(FibMemoization(6, memo));
            //Console.WriteLine(FibMemoization(7, memo));
            //Console.WriteLine(FibMemoization(8, memo));
            //Console.WriteLine(FibMemoization(50, memo));
        }

        /// <summary>
        /// Common recursive implementation of the Fibonacci Sequence.
        /// The function will take in an integer and return the integers in
        /// the Fibonacci Sequence. Not ideal for bigger numbers. As n increases,
        /// the runtime increases exponentially.
        /// 
        /// Time: O(2^n)
        /// Space: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The nth value of the Fibonacci Sequence.</returns>
        public static long Fib(int n)
        {
            if (n <= 2) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }

        /// <summary>
        /// An optimized implementation of a recursive Fibonacci Sequence.
        /// This implementation uses memoization. Storing reoccuring values inside
        /// a Dictionary with a key. On each recursive call a check is made for an
        /// existing key and if true the value at that position is returned, otherwise
        /// the recursive process continues. This completely removes redundant traversing
        /// of the Fibonacci Sequence.
        /// 
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="memo"></param>
        /// <returns>The nth value of the Fibonacci Sequence.</returns>
        public static long FibMemoization(int n, Dictionary<int, long> memo)
        {
            if (memo.ContainsKey(n))
                return memo[n];
            if (n <= 2) return 1;

            memo[n] = (FibMemoization(n - 1, memo) + FibMemoization(n - 2, memo));
            return memo[n];
        }
    }
}

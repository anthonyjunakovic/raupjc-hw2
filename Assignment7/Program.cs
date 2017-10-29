using System;
using System.Threading.Tasks;

namespace Assignment7
{
    class Program
    {
        private static async Task LetsSayUserClickedAButtonOnGuiMethodAsync()
        {
            int result = await GetTheMagicNumberAsync();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumberAsync()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }
        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return await Assignment6.Assignment6.FactorialDigitSum(n);
        }
        // Ignore this part.
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async.
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types (like web apps, win apps etc.)
            // Ignore main method, you can just focus on
            // LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy.
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethodAsync());
            Console.Read();
        }
    }
}

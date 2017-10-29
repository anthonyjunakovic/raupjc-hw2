using System.Threading.Tasks;

namespace Assignment6
{
    public static class Assignment6
    {
        public static async Task<int> FactorialDigitSum(int n) // Maybe add Async suffix?
        {
            int fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            int result = 0;
            while (fact > 0)
            {
                result += fact % 10;
                fact /= 10;
            }
            return result;
        }
    }
}

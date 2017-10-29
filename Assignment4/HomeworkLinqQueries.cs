using System.Linq;
using Assignment1;

namespace Assignment4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.Distinct().OrderBy(i => i).Select(i => "Broj " + i.ToString() + " ponavlja se " + intArray.Where(j => j == i).Count().ToString() + " puta").ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.Count() == u.Students.Where(s => s.Gender == Gender.Male).Count()).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            double average = universityArray.Average(u => u.Students.Count());
            return universityArray.Where(u => (double)u.Students.Count() < average).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => (u.Students.Count() == u.Students.Where(s => s.Gender == Gender.Male).Count()) || (u.Students.Count() == u.Students.Where(s => s.Gender == Gender.Female).Count())).SelectMany(u => u.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).GroupBy(s => s).SelectMany(grp => grp.Skip(1)).Distinct().ToArray();
        }
    }
}
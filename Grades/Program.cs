using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            book.Name = "Jeff's Grade Book";
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            book.NameChanged += OnNameChanged; //you can remove new NameChangedDelegate (C# is smart enough to recognize it is tied to a delegate

        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            Console.WriteLine(book.Update);

            foreach  (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Letter Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrade(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(97);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.AddGrade(95);
            book.AddGrade(65);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Input a name for your grade book");
                book.Name = Console.ReadLine();
                book.Update = DateTime.Now;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Name of Grade Book Changed from {args.ExistingName} to {args.NewName}");
        }

    }
}

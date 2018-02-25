using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics");
            float lowestGrade = float.MaxValue;
            foreach(float grade in grades)
            {
                lowestGrade = Math.Min(grade, lowestGrade);
            }
            grades.Remove(lowestGrade);

            return base.ComputeStatistics();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good Work";
                        break;
                    case "C":
                        result = "Keeping Trying";
                        break;
                    case "D":
                        result = "You Can Do Better!";
                        break;
                    default:
                        result = "Let's Discuss Your Work";
                        break;
                }
                return result;
            }
        }
        
        public string LetterGrade
        {
            get
            {
                string result;
                if (Math.Round(AverageGrade) >= 90)
                {
                    result = "A";
                } else if (Math.Round(AverageGrade) >= 80) {
                    result = "B";
                } else if (Math.Round(AverageGrade) >= 70)
                {
                    result = "C";
                } else if (Math.Round(AverageGrade) >= 60)
                {
                    result = "D";
                } else
                {
                    result = "F";
                }
                return result;
            }
         }

        public float AverageGrade;
        public float LowestGrade;
        public float HighestGrade;
    }
}

﻿using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrade(TextWriter destination);
        event NameChangedDelegate NameChanged;
        string Name { get; set; }
        object Update { get; set; }
    }
}
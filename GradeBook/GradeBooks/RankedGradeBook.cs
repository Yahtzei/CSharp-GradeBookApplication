using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var studentsPerBracket = (int)Math.Ceiling(Students.Count * 0.2); // number of students per grade bracket

            // create list of students' average grades in descending order
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (averageGrade >= grades[studentsPerBracket])
                return 'A';

            else if (averageGrade >= grades[studentsPerBracket * 2])
                return 'B';

            else if (averageGrade >= grades[studentsPerBracket * 3])
                return 'C';

            else if (averageGrade >= grades[studentsPerBracket * 4])
                return 'D';

            else
                return 'F';
        }
    }
}

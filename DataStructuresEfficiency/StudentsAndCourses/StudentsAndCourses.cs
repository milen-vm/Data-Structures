using System;
using System.IO;

class StudentsAndCourses
{
    static void Main()
    {
        var coursesPersons = new CoursePersonCollection();
        using (StreamReader sr = File.OpenText("../../students.txt"))
        {
            string line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                var elements = line.Split('|');
                var firstName = elements[0].Trim();
                var lastName = elements[1].Trim();
                var course = elements[2].Trim();

                coursesPersons.AddCoursePerson(firstName, lastName, course);
            }
        }

        coursesPersons.PrintCollection();
    }
}

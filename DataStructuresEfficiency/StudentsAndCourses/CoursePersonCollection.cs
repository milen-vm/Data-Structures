using System;
using System.Collections.Generic;

public class CoursePersonCollection
{
    private SortedDictionary<string, SortedSet<Person>> personsByCourse =
        new SortedDictionary<string, SortedSet<Person>>();

    public void AddCoursePerson(string firstName, string lastName, string course)
    {
        if (!personsByCourse.ContainsKey(course))
        {
            personsByCourse.Add(course, new SortedSet<Person>());
        }

        var person = new Person() { FirstName = firstName, LastName = lastName };
        personsByCourse[course].Add(person);
    }

    public void PrintCollection()
    {
        foreach (var coursePersons in personsByCourse)
        {
            Console.WriteLine(coursePersons.Key + ": " + string.Join(", ", coursePersons.Value));
        }
    }
}

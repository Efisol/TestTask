using System;
using System.Collections.Generic;
using System.Linq;

// Please, do not use internet or any other sources of information during the test
// tast shouldn’t take more than 30 minutes
// There are 3 classes: Student, Subject and Mark
// - Fill the data according to the following conditions (use lists)
// 1. It is known that there are such students in the group: Valery Popov, Semyon Korzhev, Peter Ivanov, Maria Semenova and Kolya Nesterenko
// 2. Mathematics, Physics, Astronomy, History and Ethics are learned by this group and all subjects are mandatory excluding Ethics. It is optional.
// 3. Fill the data about marks if it is known that students have mark 3 for mandatory subjects and Maria has mark 5 for History and Ethics.
// 4. Please print results in a such way:
//   Popova Valeria Mathematics-1 Physics-2 Astronomy-0 History-1 Ethics-3 (do not display the subject info if there is no data about it)

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Subject
{
    public string Name { get; set; }
    public bool IsMandatory { get; set; }
}

public class Mark
{
    public Student Student { get; set; }
    public Subject Subject { get; set; }
    public int Rank { get; set; }
}

public class Program
{

    public static void Main()
    {
        // start #1
        List<Student> students = new List<Student>
        {
            new Student { FirstName = "Valery", LastName = "Popov" },
            new Student { FirstName = "Semyon", LastName = "Korzhev" },
            new Student { FirstName = "Peter", LastName = "Ivanov" },
            new Student { FirstName = "Maria", LastName = "Semenova" },
            new Student { FirstName = "Kolya", LastName = "Nesterenko" }
        };
        // end #1

        // start #2
        List<Subject> subjects = new List<Subject>
        {
            new Subject { Name = "Mathematics", IsMandatory = true },
            new Subject { Name = "Physics", IsMandatory = true },
            new Subject { Name = "Astronomy", IsMandatory = true },
            new Subject { Name = "History", IsMandatory = true },
            new Subject { Name = "Ethics", IsMandatory = false },
        };
        // end #2

        // start #3
        List<Mark> marks = (from student in students
                            from subject in subjects
                            select (new Mark
                            {
                                Student = student,
                                Subject = subject,
                                Rank = (student.FirstName == "Maria" && (subject.Name == "History" || subject.Name == "Ethics") ?
                                            5 : (subject.IsMandatory == true) ? 3 : 0)
                            })).ToList();
        // end #3

        // start #4
        var grouped_marks = marks.GroupBy(m => m.Student);

        foreach (IGrouping<Student, Mark> m in grouped_marks)
        {
            Console.Write("{0} {1} ", m.Key.LastName, m.Key.FirstName);

            foreach (var t in m)
            {
                if (t.Rank > 0)
                    Console.Write("{0}-{1} ", t.Subject.Name, t.Rank);
            }
            Console.WriteLine();
        }
        // end #4

        Console.ReadLine();
    }
}


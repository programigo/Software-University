namespace Student_System
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                db.Database.Migrate();

                //SeedInitialData(db);
                //SeedLicenses(db);
                //PrintStudentsAndHomewoks(db);
                //PrintCoursesWithResources(db);
                //PrintCoursesWithMoreThanFiveResources(db);
                //PrintCoursesActiveOnADate(db);
                //PrintStudents(db);
                //PrintCoursesWithResourcesAndLicenses(db);
                PrintStudentsWithCoursesAndResources(db);
            }
        }

        private static void PrintStudentsWithCoursesAndResources(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    Courses = s.Courses.Count,
                    TotalResources = s.Courses.Sum(c => c.Course.Resources.Count),
                    Licenses = s.Courses.Sum(c => c.Course.Resources.Sum(r => r.Licenses.Count))
                })
                .OrderByDescending(s => s.Courses)
                .ThenByDescending(s => s.TotalResources)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name} - {student.Courses} - {student.TotalResources} - {student.Licenses}");
            }
        }

        private static void PrintCoursesWithResourcesAndLicenses(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .OrderByDescending(c => c.Resources.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Resources = c
                    .Resources
                    .OrderByDescending(r => r.Licenses.Count)
                    .ThenBy(r => r.Name)
                    .Select(r => new
                    {
                        r.Name,
                        License = r.Licenses.Select(l => l.Name)
                    })
                });

            foreach (var course in result)
            {
                Console.WriteLine(course.Name);

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"---{resource.Name}");

                    foreach (var license in resource.License)
                    {
                        Console.WriteLine($"-----{license}");
                    }
                }
            }
        }

        private static void SeedInitialData(StudentSystemDbContext db)
        {
            const int totalStudents = 25;
            const int totalCourses = 10;
            var currentDate = DateTime.Now;

            for (int i = 0; i < totalStudents; i++)
            {
                db.Students.Add(new Student
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDate.AddDays(i),
                    BirthDay = currentDate.AddYears(-20).AddDays(i),
                    PhoneNumber = $"Random phone {i}"
                });
            }

            db.SaveChanges();

            List<Course> addedCourses = new List<Course>();

            for (int i = 0; i < totalCourses; i++)
            {
                var course = new Course
                {
                    Name = $"Course {i}",
                    Description = $"Course Details {i}",
                    Price = 100 * i,
                    StartDate = currentDate.AddDays(i),
                    EndDate = currentDate.AddDays(20 + i)
                };

                addedCourses.Add(course);

                db.Courses.Add(course);
            }
            db.SaveChanges();

            var studentIds = db.Students.Select(s => s.Id).ToList();

            for (int i = 0; i < totalCourses; i++)
            {
                var currentCourse = addedCourses[i];
                var studentsInCourse = random.Next(2, totalStudents / 2);

                for (int j = 0; j < studentsInCourse; j++)
                {
                    var studentId = studentIds[random.Next(0, studentIds.Count)];

                    if (!currentCourse.Students.Any(s => s.StudentId == studentId))
                    {
                        currentCourse.Students.Add(new StudentCourse
                        {
                            StudentId = studentId
                        });
                    }
                    else
                    {
                        j--;
                    }
                }

                var resourcesInCourse = random.Next(2, 20);

                var types = new[] { 1, 2, 999 };

                for (int j = 0; j < resourcesInCourse; j++)
                {
                    currentCourse.Resources.Add(new Resource
                    {
                        Name = $"Resource {i} {j}",
                        Url = $"URL {i} {j}",
                        TypeOfResource = (ResourceType)types[random.Next(0, types.Length)]
                    });
                }
            }

            db.SaveChanges();

            for (int i = 0; i < totalCourses; i++)
            {
                var currentCourse = addedCourses[i];

                var studentsInCourseIds = currentCourse
                    .Students
                    .Select(s => s.StudentId)
                    .ToList();

                for (int j = 0; j < studentsInCourseIds.Count; j++)
                {
                    var totalHomeworks = random.Next(2, 5);

                    for (int k = 0; k < totalHomeworks; k++)
                    {
                        db.Homeworks.Add(new Homework
                        {
                            Content = $"Content Homework {i}",
                            SubmissionDate = currentDate.AddDays(-i),
                            ContentType = ContentType.Zip,
                            StudentId = studentsInCourseIds[j],
                            CourseId = currentCourse.Id
                        });
                    }
                }

                db.SaveChanges();
            }
        }

        private static void SeedLicenses(StudentSystemDbContext db)
        {
            var resourceIds = db
                .Resources
                .Select(r => r.Id)
                .ToList();

            for (int i = 0; i < resourceIds.Count; i++)
            {
                var totalLicenses = random.Next(1, 4);

                for (int j = 0; j < totalLicenses; j++)
                {
                    db.Licenses.Add(new License
                    {
                        Name = $"License {i} {j}",
                        ResourceId = resourceIds[i]
                    });
                }

                db.SaveChanges();
            }
        }

        private static void PrintStudentsAndHomewoks(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks.Select(h => new
                    {
                        h.Content,
                        h.ContentType
                    })
                })
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine(student.Name);

                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($"---{homework.Content} - {homework.ContentType}");
                }
            }
        }

        private static void PrintCoursesWithResources(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resources = c.Resources.Select(r => new
                    {
                        r.Name,
                        r.TypeOfResource,
                        r.Url
                    })
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} - {course.Description}");

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"---{resource.Name} - {resource.TypeOfResource} - {resource.Url}");
                }
            }
        }

        private static void PrintCoursesWithMoreThanFiveResources(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourcesCount = c.Resources.Count
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} - {course.ResourcesCount}");
            }
        }

        private static void PrintCoursesActiveOnADate(StudentSystemDbContext db)
        {
            var date = DateTime.Now.AddDays(25);

            var result = db
                .Courses
                .Where(c => c.StartDate < date && date < c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = c.EndDate.Subtract(c.StartDate),
                    Students = c.Students.Count
                })
                .OrderByDescending(c => c.Students)
                .ThenByDescending(c => c.Duration)
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} - {course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}");
                Console.WriteLine($"---Duration: {course.Duration.TotalDays}");
                Console.WriteLine($"---Students: {course.Students}");
                Console.WriteLine(new string('-', 10));
            }
        }

        private static void PrintStudents(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    NumberOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Course.Price),
                    AveragePrice = s.Courses.Average(c => c.Course.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.NumberOfCourses)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name} - {student.NumberOfCourses} - {student.TotalPrice} - {student.AveragePrice}");
            }
        }
    }
}
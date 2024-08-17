using System;
using CollegeApp.Models;

namespace CollegeApp.Repository;

public class CollegeRepository
{
    public static List<Student> Students { get; set; } = new List<Student>{
                new Student
                {
                    Id = 1,
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    email = "ahmet@yılmaz.com",
                    BirthYear = 1999,
                    Address = "Istanbul"
                },
                new Student
                {
                    Id = 2,
                    Name = "Mehmet",
                    Surname = "Yılmaz",
                    email = "mehmet@yılmaz.com",
                    BirthYear = 1999,
                    Address = "Istanbul"
                }
                
            };
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    // this breaks three different rules, but is okay for now in lecture only
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        // we don't like the "new" keyword here. This breaks rules starting in assignment 6
        // fix this then.
        public static List<Student> students = new List<Student>();

        [HttpGet]
        public List<Student> Get()
        {
            return students;
        }

        [HttpGet("{id:int}")]
        public Student GetOne(int id)
        {
            // this doesn't handle bad indexes

            return students[id];
        }

        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            students.Add(student);

            return student;
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] Student student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            students[id] = student;

            return Json(student);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromBody] Student student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            if (!string.IsNullOrWhiteSpace(student.FirstName))
            {
                students[id].FirstName = student.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(student.LastName))
            {
                students[id].LastName = student.LastName;
            }

            return Json(student);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            students.RemoveAt(id);

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}

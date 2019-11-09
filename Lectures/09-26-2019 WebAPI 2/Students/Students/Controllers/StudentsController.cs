using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Entities;
using Students.Models;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        // we don't like the "new" keyword here. This breaks rules starting in assignment 6
        // fix this then.
        public static List<StudentModel> students = new List<StudentModel>()
        {
            new StudentModel() {FirstName = "Steven", LastName = "Yackel", Views = new List<string>() { "Today" } }
        };

        [HttpGet]
        public IEnumerable<StudentEntity> Get()
        {
            return students.Select(element => new StudentEntity(element));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(new StudentEntity(students[id]));
        }

        [HttpPost]
        public StudentEntity Post([FromBody] StudentEntity student)
        {
            students.Add(student.ToModel());

            return student;
        }

        [HttpPost("{id:int}/views")]
        public ViewEntity PostView([FromBody] ViewEntity entity, int id)
        {
            // add this view entity to the student model at "id"

            return entity;
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] StudentEntity student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            students[id] = student.ToModel();

            return Json(student);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromBody] StudentEntity student, int id)
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

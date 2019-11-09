using Students.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Entities
{
    public class StudentEntity
    {
        [MinLength(3)]
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Views { get; internal set; }

        public StudentModel ToModel()
        {
            return new StudentModel()
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }

        // we always need a no-args constructor in entity classes
        public StudentEntity()
        {

        }

        public StudentEntity(StudentModel studentModel)
        {
            this.FirstName = studentModel.FirstName;
            this.LastName = studentModel.LastName;
            this.Views = studentModel.Views.Count();
        }
    }
}

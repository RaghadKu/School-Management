using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }

        public Subject(int Id ,string Name ,Course Course ,Teacher Teacher  ) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Course= Course;
            this.Teacher= Teacher;

        }
    }
}

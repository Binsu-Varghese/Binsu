using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpPost]
        public object Post([FromBody] Student student)
        {
            Student st = new Student();
            st.FirstName = student.FirstName;
            st.LastName = student.LastName;
            st.ID = student.ID; 
            st.Marks = new List<int>(student.Marks);
            students.Add(st);
            return "Added Successfully"; 
        }

        [HttpGet("student")]
        public IEnumerable<Student> GetstudentDetails()
        {
            return students;
        }

        [HttpPut("{id}")]
        public object Put(int id, [FromBody]Student student)
        {
            var entity = students.FirstOrDefault(s => s.ID == id);
            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.Marks= new List<int>(student.Marks);
            return "Updated Successfully";
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            var itemToRemove = students.SingleOrDefault(r => r.ID == id);
            if (itemToRemove != null)
                students.Remove(itemToRemove);
            return "Deleted Successfully";
        }
    }
}
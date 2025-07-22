using crudProject.Db;
using crudProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace crudProject.Controllers
{
    [Route("api/[controller]")]//base API
    [ApiController]

    public class StudentController : ControllerBase
    {
       
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Create")]//IActionResult -multible data return /return type string int float

        public IActionResult Create([FromBody] Student s1)// create ,update[frombody] pass
        {
            _context.Add(s1);
            _context.SaveChanges();
            return Ok(s1);
        }
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAll()
        {
            List<Student> students = new List<Student>();
            students = _context.students.ToList();
            return Ok(students);

        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Student s1 = _context.students.FirstOrDefault(x => x.Id == id);
            return Ok(s1);
        }
        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody] Student s1)
        {
            _context.Update(s1);
            _context.SaveChanges();
            return Ok(s1);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteById(int id)
        {
            Student s1 = _context.students.FirstOrDefault(x => x.Id == id);
            _context.Remove(s1);
            _context.SaveChanges();
            return Ok(s1);
        }
    }
}

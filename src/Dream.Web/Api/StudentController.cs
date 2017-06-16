using Dream.EntityFramework;
using Dream.EntityFramework.Models;
using Dream.Web.Api.ErrorShow;
using Dream.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Web.Api
{
    [Produces("application/json")]
    [Route("api/Student/[action]")]
    public class StudentController : Controller
    {
        private readonly TestCoreContext _context;

        public StudentController(TestCoreContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<List<Student>> Index()


        {
            var students = from s in _context.Student
                           select s;
            return students.ToList();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ApiReturnResult> Create(StudentDto student)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = ModelState.AllModelStateErrors();
                return new ApiReturnResult()
                {
                    IsValidate = false,
                    ErrorLists = modelErrors.ToList()
                };
            }
            var studentModel = new Student()
            {
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate
            };
            _context.Add(studentModel);
            await _context.SaveChangesAsync();

            return new ApiReturnResult()
            {
                IsValidate = true
            };
        }

        [HttpPost]
        public async Task<bool> Delete(string id)
        {
            int studentId = 0;
            if (!int.TryParse(id, out studentId))
                return await Task.FromResult(false);
            
            var student = await _context.Student.SingleOrDefaultAsync(c => c.ID == studentId);
            if (student == null)
                return false;
            _context.Student.Remove(student);
            return await _context.SaveChangesAsync()>0;

        }

        // GET: Students/Edit/5
        public async Task<Student> Detail(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            return student;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Update(StudentDto studentDto)
        {
            //int studentId = 0;
            //if (!int.TryParse(id, out studentId))
            //    return await Task.FromResult(false);

            //var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == studentId);
            var student = new Student()
            {
                ID = studentDto.ID,
                EnrollmentDate = studentDto.EnrollmentDate,
                Enrollments = studentDto.Enrollments,
                FirstMidName = studentDto.FirstMidName,
                LastName = studentDto.LastName
            };
            _context.Set<Student>().Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
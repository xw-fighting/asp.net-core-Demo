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
            if (ModelState.IsValid)
            {
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

            var modelErrors = ModelState.AllModelStateErrors();
            return new ApiReturnResult()
            {
                IsValidate = false,
                ErrorLists = modelErrors.ToList()
            };
        }

        [HttpPost]
        public async Task<bool> Delete(Student student)
        {
            //var student = await _context.Student.SingleOrDefaultAsync(c => c.ID == id);
            if (student == null)
                return false;
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return true;

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
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Update(Student student)
        {
            //var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            _context.Set<Student>().Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            return _context.SaveChanges() > 0;

        }
    }
}
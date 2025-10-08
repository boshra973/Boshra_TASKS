using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Repositories.Implementations
{
    public class CourseRepository : IReadableRepository<Course>, IWritableRepository<Course>
    {
        private readonly ITIContext _context;
        public CourseRepository(ITIContext context) => _context = context;

        //read all 
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses
                           .Include(c => c.Department)
                           .Include(c => c.Instructor)
                           .ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses
                           .Include(c => c.Department)
                           .Include(c => c.Instructor)
                           .FirstOrDefault(c => c.Id == id);
        }

        // WRITE
        public void Add(Course entity)
        {
            _context.Courses.Add(entity);
            // all changes must be saved 
            _context.SaveChanges();
        }

        public void Update(Course entity)
        {
            _context.Courses.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}

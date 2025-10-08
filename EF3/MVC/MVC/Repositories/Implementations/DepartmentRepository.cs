using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Repositories.Implementations
{
    public class DepartmentRepository : IReadableRepository<Department>, IWritableRepository<Department>
    {
        private readonly ITIContext _context;
        public DepartmentRepository(ITIContext context)
        {
            _context = context;
        }

        // READ ALL with related data
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments
                           .Include(d => d.Instructors)
                           .Include(d => d.Courses)
                           .ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments
                           .Include(d => d.Instructors)
                           .Include(d => d.Courses)
                           .FirstOrDefault(d => d.Id == id);
        }

        // WRITE
        public void Add(Department entity)
        {
            _context.Departments.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Department entity)
        {
            _context.Departments.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dep = _context.Departments.Find(id);
            if (dep != null)
            {
                _context.Departments.Remove(dep);
                _context.SaveChanges();
            }
        }
    }
}

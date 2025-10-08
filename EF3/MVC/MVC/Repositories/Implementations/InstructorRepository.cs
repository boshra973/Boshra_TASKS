using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Repositories.Implementations
{
    public class InstructorRepository : IReadableRepository<Instructor>, IWritableRepository<Instructor>
    {
        private readonly ITIContext _context;
        public InstructorRepository(ITIContext context) => _context = context;

        // read onlu with Department included
        public IEnumerable<Instructor> GetAll()
        {
            return _context.Instructors
                           .Include(i => i.Department)
                           .ToList();
        }

        public Instructor GetById(int id)
        {
            return _context.Instructors
                           .Include(i => i.Department)
                           .FirstOrDefault(i => i.Id == id);
        }

        // WRITE
        public void Add(Instructor entity)
        {
            _context.Instructors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Instructor entity)
        {
            _context.Instructors.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var inst = _context.Instructors.Find(id);
            if (inst != null)
            {
                _context.Instructors.Remove(inst);
                _context.SaveChanges();
            }
        }
    }
}

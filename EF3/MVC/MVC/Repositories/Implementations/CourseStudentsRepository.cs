using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Repositories.Implementations
{
    public class CourseStudentsRepository : IReadableRepository<CourseStudents>, IWritableRepository<CourseStudents>
    {
        private readonly ITIContext context;

        public CourseStudentsRepository(ITIContext context)
        {
            this.context = context;
        }

        // Read
        public CourseStudents GetById(int id)
        {
            // Composite key
            return null;
        }

        public IEnumerable<CourseStudents> GetAll() => context.CourseStudents.ToList();

        // Write
        public void Add(CourseStudents entity)
        {
            context.CourseStudents.Add(entity);
            context.SaveChanges();
        }

        public void Update(CourseStudents entity)
        {
            context.CourseStudents.Update(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // this is a composite key 
        }

        public void Delete(int studentId, int courseId)
        {
            var cs = context.CourseStudents.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
            if (cs != null)
            {
                context.CourseStudents.Remove(cs);
                context.SaveChanges();
            }
        }
    }
}

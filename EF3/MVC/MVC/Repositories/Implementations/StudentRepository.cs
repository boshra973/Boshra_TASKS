using MVC.Models; // Your DbContext and Student model
using MVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class StudentRepository : IReadableRepository<Student>, IWritableRepository<Student>
{
    private readonly ITIContext context;

    public StudentRepository(ITIContext context)
    {
        this.context = context;
    }

    // Reading operations
    public Student GetById(int id)
    {
        return context.Students.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Student> GetAll()
    {
        return context.Students.ToList();
    }

    // Writing operations
    public void Add(Student student)
    {
        context.Students.Add(student);
        context.SaveChanges();
    }

    public void Update(Student student)
    {
        context.Students.Update(student);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var student = context.Students.Find(id);
        if (student != null)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}


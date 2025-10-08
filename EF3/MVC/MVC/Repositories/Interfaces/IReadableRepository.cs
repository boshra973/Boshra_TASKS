using System;
using System.Collections.Generic;

// only read operation --> SRP (dingle repository principble)
public interface IReadableRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}



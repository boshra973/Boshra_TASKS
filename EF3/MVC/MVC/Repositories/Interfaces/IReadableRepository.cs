using System;
using System.Collections.Generic;

public interface IReadableRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}



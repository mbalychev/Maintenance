﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}

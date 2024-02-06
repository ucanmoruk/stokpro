using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public interface IService<T> where T : class
    {
        T Get(string filter = "", params object[] list);
        List<T> GetList(string filter = "", params object[] list);
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}

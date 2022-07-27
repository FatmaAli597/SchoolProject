using System.Collections.Generic;

namespace SchoolProject.Repository
{
    public interface ICRUD_Repository<T> where T : class
    {
        int Delete(int id);
        List<T> Getall();
        T GetById(int id);
        int Insert(T obj);
        int Update(T entity);
    }
}
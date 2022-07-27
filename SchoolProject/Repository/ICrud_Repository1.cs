using System.Collections.Generic;

namespace SchoolProject.Repository
{
    public interface ICrud_Repository1<T> where T : class
    {
        int Delete(string id);
        List<T> Getall();
        T GetById(string id);
        int Insert(T obj);
        int Update(T entity);
        
        //int Update(string id, T item);
    }
}
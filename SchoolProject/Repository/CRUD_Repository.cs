using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Repository
{
    public class CRUD_Repository<T> : ICRUD_Repository<T> where T : class
    {
        Context context;
        private DbSet<T> entities;
        public CRUD_Repository(Context _context)
        {
            this.context = _context;
            this.entities = this.context.Set<T>();
        }
        public List<T> Getall()
        {
            List<T> objs = entities.ToList();
            return objs;
        }
        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public int Insert(T obj)
        {
            entities.Add(obj);
            return context.SaveChanges();
        }
        public int Update(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();
        }
        //   public void Update(T entity) => context.Set<T>().Update(entity);

        public int Delete(int id)
        {
            entities.Remove(GetById(id));
            return context.SaveChanges();
        }


    }
}

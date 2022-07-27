using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProject.Repository
{
    public class Crud_Repository1<T> : ICrud_Repository1<T> where T : class
    {
        Context context;
        private DbSet<T> entities;
        public Crud_Repository1(Context _context)
        {
            this.context = _context;
            this.entities = this.context.Set<T>();
        }
        public List<T> Getall()
        {
            List<T> objs = entities.ToList();
            return objs;
        }
        public T GetById(string id)
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

        //public int Update(string id, T Item)
        //{
        //    //T Itemold = context.Set<T>().Find(id);
        //    if (Item != null)
        //    {
        //        context.Entry(Item).State = EntityState.Modified;
        //        return context.SaveChanges();
        //    }
        //    return 0;

        //}

        public int Delete(string id)
        {
            entities.Remove(GetById(id));
            return context.SaveChanges();
        }
    }
}
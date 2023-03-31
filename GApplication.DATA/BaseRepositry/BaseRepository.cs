using GApplication.DATA.BaseRepositry;
using GApplication.DATA.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.BaseRepositry
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationContext _db;

        public BaseRepository(ApplicationContext Db)
        {
            _db = Db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }
        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }

       
    }
}

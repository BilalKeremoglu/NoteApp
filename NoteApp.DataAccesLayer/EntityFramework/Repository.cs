using NoteApp.DataAccesLayer;
using NoteApp.DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataAccesLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T:class
    {
        //sürekli Set<T> yazmak yerine
        private DbSet<T> _objectset;
        //constructor da bir kere atamay yapıp objectset kullanıyoruz.
        public Repository()
        {
            _objectset = context.Set<T>();
        }


        
        public List<T> List()
        {
            return _objectset.ToList();
        }

        //controllerda orderby kullanırsak c# ile sıralama yapmış oluyoruz
        //ancak burda IQueryble bir sorgu oluşturarak sql tarafında sıralayabiliriz.
        public IQueryable<T> ListQueryable()
        {
            return _objectset.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectset.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            _objectset.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _objectset.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectset.FirstOrDefault(where);
        }


    }
}

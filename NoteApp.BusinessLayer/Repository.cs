using NoteApp.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLayer
{
    public class Repository<T> where T:class
    {
        private DatabaseContext db;

        //sürekli Set<T> yazmak yerine
        private DbSet<T> _objectset;
        //constructor da bir kere atamay yapıp objectset kullanıyoruz.
        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectset = db.Set<T>();
        }
        
        public List<T> List()
        {
            return _objectset.ToList();
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
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectset.FirstOrDefault(where);
        }


    }
}

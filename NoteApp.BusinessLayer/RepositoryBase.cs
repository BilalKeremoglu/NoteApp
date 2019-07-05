using NoteApp.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLayer
{
    public class RepositoryBase
    {
        //nesnenin 1 kere oluşumunu sağlamak için gereken kalıp "singleton pattern"
        private static DatabaseContext _db;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {

        }

        public static DatabaseContext CreateContext()
        {
            if(_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                }
            }

            return _db;
        }
    }
}

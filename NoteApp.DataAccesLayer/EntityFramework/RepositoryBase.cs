using NoteApp.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataAccesLayer.EntityFramework
{
    public class RepositoryBase
    {
        //nesnenin 1 kere oluşumunu sağlamak için gereken kalıp "singleton pattern"
        protected static DatabaseContext context;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
           CreateContext();
        }

        private static void CreateContext()
        {
            if(context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }

        }
    }
}

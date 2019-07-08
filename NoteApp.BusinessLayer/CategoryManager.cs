using NoteApp.DataAccesLayer.EntityFramework;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLayer
{
    public class CategoryManager
    {
        private Repository<Category> repo_cat = new Repository<Category>();

        public List<Category> GetCategories()
        {
            return repo_cat.List();
        }
    }
}

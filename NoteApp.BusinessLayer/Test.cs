using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLayer
{
    public class Test
    {
        private Repository<Category> repo_cat = new Repository<Category>();
        private Repository<NoteAppUser> repo_user = new Repository<NoteAppUser>();
        private Repository<Comment> repo_com = new Repository<Comment>();
        private Repository<Note> repo_note = new Repository<Note>();


        public Test()
        {
            List<Category> cat= repo_cat.List();
            List<Category> cat_filtered = repo_cat.List(x=>x.Id>5);

        }
        public void InsertTest()
        {

            int result = repo_user.Insert(new NoteAppUser() {
                Name = "aaa",
                Surname = "bbb",
                Email = "bilalkeremoglu@windowslive.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "aabb",
                Password = "111",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aabb"
            });
        }
        public void UpdateTest()
        {
            NoteAppUser user = repo_user.Find(x => x.Username == "aabb");

            if (user != null)
            {
                user.Username = "xxx";

                int result = repo_user.Save();
            }
        }
        public void DeleteTest()
        {
            NoteAppUser user = repo_user.Find(x => x.Username == "xxx");

            if (user != null)
            {
                repo_user.Delete(user);
            }
        }

        public void CommentTest()
        {
            NoteAppUser user = repo_user.Find(x => x.Id == 1);
            Note note = repo_note.Find(x => x.Id == 3);

            Comment comment = new Comment()
            {
                Text = "Bu bir testtir.",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "bilalkeremoglu",
                Note = note,
                Owner = user
           
            };
            repo_com.Insert(comment);
        }
    }
}

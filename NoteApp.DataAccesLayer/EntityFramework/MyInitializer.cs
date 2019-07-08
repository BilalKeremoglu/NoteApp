using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NoteApp.DataAccesLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding admin user
            NoteAppUser admin = new NoteAppUser()
            {
                Name = "Bilal",
                Surname = "Keremoğlu",
                Email = "bilalkeremoglu@windowslive.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "bilalkeremoglu",
                Password = "123456",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "bilalkeremoglu"
            };
            //Adding standart user
            NoteAppUser standartUser = new NoteAppUser()
            {
                Name = "Ayça",
                Surname = "Akar",
                Email = "aycaakar@windowslive.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "aycaakar",
                Password = "123456",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "bilalkeremoglu"
            };

            context.NoteAppUsers.Add(admin);
            context.NoteAppUsers.Add(standartUser);

            //Adding fake user
            for (int i = 0; i < 10; i++)
            {
                NoteAppUser user = new NoteAppUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "123",
                    CreateOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}",
                };
                context.NoteAppUsers.Add(user);

            }

            context.SaveChanges();

            //Userlist
            List<NoteAppUser> userlist = context.NoteAppUsers.ToList();

            //adding fake categories..
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreateOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "bilalkeremoglu"
                };

                context.Categories.Add(cat);


                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    NoteAppUser owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreateOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username,

                    };

                    cat.Notes.Add(note);

                    //adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3,8); j++)
                    {
                        NoteAppUser comment_owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Note = note,
                            Owner = comment_owner,
                            CreateOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username,
                        };

                        note.Comments.Add(comment);
                    }


                    //Adding fake likes..
                    for (int m = 0; m < note.LikeCount ; m++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userlist[m]
                        };

                        note.Likes.Add(liked);

                    }

                }
            }
            context.SaveChanges();

        }
    }
}

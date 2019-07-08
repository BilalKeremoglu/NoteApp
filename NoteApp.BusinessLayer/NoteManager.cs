﻿using NoteApp.DataAccesLayer.EntityFramework;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> repo_note = new Repository<Note>();

        public List<Note> GetAllNotes()
        {
            return repo_note.List();
        }
    }
}
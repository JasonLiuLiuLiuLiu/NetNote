using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetNote.ViewModel;

namespace NetNote.Models
{
    public class NoteContext:DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteType> NoteTypes { get; set; }
        public DbSet<NetNote.ViewModel.NoteModel> NoteModel { get; set; }
    }
}

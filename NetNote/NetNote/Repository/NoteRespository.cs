using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetNote.Models;

namespace NetNote.Repository
{
    public class NoteRespository:INoteRespository
    {
        private NoteContext context;

        public NoteRespository(NoteContext _context)
        {
            this.context = _context;
        }

        public Task AddAsync(Note note)
        {
            context.Notes.Add(note);
            return context.SaveChangesAsync();
        }

        public Task<Note> GetByIdAsync(int id)
        {
            return context.Notes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<Note>> ListAsync()
        {
            return context.Notes.ToListAsync();
        }

        public Task UpdateAsync(Note note)
        {
            context.Entry(note).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

    }
}
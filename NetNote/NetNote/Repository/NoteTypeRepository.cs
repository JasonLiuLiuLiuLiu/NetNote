using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetNote.Models;

namespace NetNote.Repository
{
    public class NoteTypeRepository:INoteTypeRepository
    {
        private NoteContext content;

        public NoteTypeRepository(NoteContext context)
        {
            this.content = context;
        }

        public Task<List<NoteType>> ListAsync()
        {
            return content.NoteTypes.ToListAsync();
        }
    }
}
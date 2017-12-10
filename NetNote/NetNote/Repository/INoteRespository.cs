using System.Collections.Generic;
using System.Threading.Tasks;
using NetNote.Models;

namespace NetNote.Repository
{
    public interface INoteRespository
    {
        Task<Note> GetByIdAsync(int id);
        Task<List<Note>> ListAsync();

        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
    }
}
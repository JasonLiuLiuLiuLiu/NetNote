using System.Collections.Generic;
using System.Threading.Tasks;
using NetNote.Models;

namespace NetNote.Repository
{
    public interface INoteTypeRepository
    {
        Task<List<NoteType>> ListAsync();
    }
}
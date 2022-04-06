using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Models;
using ElevenNote.Models.Note;

namespace ElevenNote.Services.Notes
{
    public interface INoteService
    {
        Task<bool> CreateNoteAsync(NoteCreate request);
        Task<IEnumerable<NoteListItems>> GetAllNotesAsync();
        Task<NoteDetail> GetNoteByIdAsync (int noteId);
        Task<bool> UpdateNoteAsync(NoteUpdate request);
        Task<bool> DeleteNoteAsync(int noteId);
    }
}
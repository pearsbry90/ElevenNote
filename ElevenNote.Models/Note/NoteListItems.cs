using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteListItems
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public DateTimeOffset CreatedUtc {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNote.Data.Entities
{
    public class NoteEntity
    {
        [Required]
        public int Id {get;set;}
        public UserEntity Owner {get;set}
        [Required]
        public int OwnerId {get;set;}
        [Required]
        public string Title {get;set;}
        [Required]
        public string Content {get;set;}
        [Required]
        public DateTimeOffset CreatedUtc {get;set;}
        public DateTimeOffset? ModifiedUtc {get;set;}
    }
}
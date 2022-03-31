using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
                    public DbSet<UserEntity> User{get;set;}
                    public DbSet<NoteEntity> Notes{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
// do another Migration bc of this (part 2)
// dotnet ef migration add AddUserEntity -p ElevenNote.Data -s ElevenNote.WebAPI
            modelBuilder.Entity<NoteEntity>()
                .HasOne(n => n.Owner)
                .WithMany(p => p.Notes)
                .HasForeignKey(n => n.OwnerId);
        }
    }
}
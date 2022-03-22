using System;
using System.Collections.Generic;
using ElevenNote.Data;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Data.Entities;
using ElevenNote.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ElevenNote.Services.User
{
    public class UserService : IUserService
    {
    private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context){
        _context = context;
    }
    public async Task<bool> RegisterUserAsync(UserRegister model){ 
        if(await GetUserByEmailAsync(model.Email) != null || await GetUserByUsernameAsync(model.Username) != null)
            return false;
            
        var entity = new UserEntity{
            Email = model.Email,
            Username = model.Username,
            DateCreated = DateTime.Now
        };

        _context.User.Add(entity);
        var passwordHasher = new PasswordHasher<UserEntity>();
        entity.Password = passwordHasher.HashPassword(entity, model.Password);

        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task<UserDetail> GetUserByIdAsync(int userId){
        var entity = await _context.User.FindAsync(userId);
        if (entity is null)
            return null;

        var userDetail = new UserDetail{
            Id = entity.Id,
            Email = entity.Email,
            Username = entity.Username,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            DateCreated = entity.DateCreated,
        };

        return userDetail;
    }

    private async Task<UserEntity> GetUserByEmailAsync(string email){
        return await _context.User.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
    }

    private async Task<UserEntity> GetUserByUsernameAsync(string username){
        return await _context.User.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        }
    }
}


﻿using AdvancedRestApi.Data;
using AdvancedRestApi.Interfaces;
using AdvancedRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedRestApi.Services
{
    public class UserService : IUser
    {
        private UserDbContext _dbContext;

        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> AddUser(User user)
        {
            if(user != null)
            {
                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return (true, null);
            }
            return(false, "Forneça os dados do usuário!");
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> DeleteUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return (true, null);
            }
            return (false, "Usuário não encontrado.");
        }

        public async Task<(bool IsSuccess, List<User> User, string ErrorMessage)> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            if(users != null)
            {
                return (true, users, null);
            }
            return (false,null,"Usuários não encontrados");
        }

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if(user != null)
            {
                return (true, user, null);
            }
            return (false, null, "Usuário não encontrado" );
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> UpdateUser(Guid id, User user)
        {
            var userObj = await _dbContext.Users.FindAsync(id);
            if(userObj != null)
            {
                userObj.Name = user.Name;
                userObj.Address = user.Address;
                userObj.Phone = user.Phone;
                userObj.BloodGroup = user.BloodGroup;
                await _dbContext.SaveChangesAsync();
                return (true, null);
            }
            return (false, "Usuário não existe");
        }
    }
}

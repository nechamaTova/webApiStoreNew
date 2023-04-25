﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
//using 
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    
    public class UserRepository: IUserRepository
    {
        Store214089435Context _store214089435Context;
        public UserRepository(Store214089435Context store214104465Context)
        {
            _store214089435Context = store214104465Context;
        }
        static private string path = "..\\users.JSON";
        public async Task<User> addNewUser(User newUser)
        {
            await _store214089435Context.Users.AddAsync(newUser);
            await _store214089435Context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> getUserById(int id)
        {
            User? user = await _store214089435Context.Users.FindAsync(id);
            return user!=null?user:null;
        }

        public async Task<User> signIn(User userData)
        {
            var users = await _store214089435Context.Users.Where(user=>user.UserEmail==userData.UserEmail && user.UserPassword==user.UserPassword).ToListAsync();
            return users.Count() == 0 ? null : users[0];
        }

        public async Task updateUser(User updatedUser, int id)
        {
            User userToUpdate = await _store214089435Context.Users.FindAsync(id);
            if (userToUpdate != null)
            {
                _store214089435Context.Entry(userToUpdate).CurrentValues.SetValues(updatedUser);
                await _store214089435Context.SaveChangesAsync();
            }
        }
    }
}
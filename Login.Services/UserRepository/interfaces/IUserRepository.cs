﻿using Login.Models;

namespace Login.Services.UserRepository.interfaces
{
    public interface IUserRepository
    {

        List<User> GetAllUsers();

        Task<bool> InsertUser(User user);

        User? GetUser(string email, string password);

        bool ExistsUserEmail(string email);
    }
}

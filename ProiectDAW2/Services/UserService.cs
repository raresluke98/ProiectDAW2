﻿using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using ProiectDAW2.Authorization;
using ProiectDAW2.Helpers;
using ProiectDAW2.Models;
using ProiectDAW2.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Services
{
    public class UserService
    {
        public interface IUserService
        {
            AuthenticateResponse Authenticate(AuthenticateRequest model);
            IEnumerable<User> GetAll();
            User GetById(int id);
        }

        public class UserService : IUserService
        {
            private DataContext _context;
            private IJwtUtils _jwtUtils;
            private readonly AppSettings _appSettings;
            public UserService(
                DataContext context,
                IJwtUtils jwtUtils,
                IOptions<AppSettings> appSettings)
            {
                _context = context;
                _jwtUtils = jwtUtils;
                _appSettings = appSettings.Value;
            }


            public AuthenticateResponse Authenticate(AuthenticateRequest model)
            {
                var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

                // validate
                if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                    throw new AppException("Username or password is incorrect");

                var jwtToken = _jwtUtils.GenerateJwtToken(user);

                return new AuthenticateResponse(user, jwtToken);
            }

            public IEnumerable<User> GetAll()
            {
                return _context.Users;
            }

            public User GetById(int id)
            {
                var user = _context.Users.Find(id);
                if (user == null) throw new KeyNotFoundException("User not found");
                return user;
            }
        }
    }
}

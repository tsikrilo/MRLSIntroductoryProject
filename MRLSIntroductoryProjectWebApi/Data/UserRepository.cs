using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLRSIntroductoryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRLSIntroductoryProjectWebApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;
        public UserRepository(UserContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<ActionResult<User>> GetUserByID(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            var user = _context.User.Where(c => c.Id == userId).FirstOrDefaultAsync();

            return await user;
        }

        public async Task<ActionResult<User>> InsertUser(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return await _context.User.FindAsync(user.Id);
        }

        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            var user = await _context.User.FindAsync(id);

            if (user is null)
            {
                throw new NullReferenceException(nameof(user));
            }

            user.IsActive = false;
            _context.Update(user);

            await _context.SaveChangesAsync();

            return await _context.User.FindAsync(user.Id);
        }

        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userModified = await _context.User.SingleOrDefaultAsync(x => x.Id == id);

            if (userModified is null)
            {
                throw new NullReferenceException(nameof(userModified));
            }

            userModified.Name = user.Name;
            userModified.Surname = user.Surname;
            userModified.Birthdate = user.Birthdate;
            userModified.EmailAddress = user.EmailAddress;
            userModified.UserTitleId = user.UserTitleId;
            userModified.UserTypeId = user.UserTypeId;
            userModified.IsActive = user.IsActive;
            _context.Update(userModified);

            await _context.SaveChangesAsync();

            return await _context.User.FindAsync(user.Id);
        }
    }
}

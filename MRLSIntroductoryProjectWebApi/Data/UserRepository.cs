using AutoMapper;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLRSIntroductoryWebApi.Data
{
    public class UserRepository : IUserRepository
    {
        private UserContext _context;
        private IMapper _iMapper;
        public UserRepository(UserContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of users</returns>
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user which has the specified id</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userId</exception>
        public async Task<ActionResult<User>> GetUserByID(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            var user = _context.User.Where(c => c.Id == userId).FirstOrDefaultAsync();

            return await user;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The created user</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
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

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted user</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            var user = await _context.User.FindAsync(id);

            user.IsActive = false;
            _context.Update(user);

            await _context.SaveChangesAsync();

            return await _context.User.FindAsync(user.Id);
        }

        /// <summary>
        /// Updates the user's data with the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userDto">userDTO</param>
        /// <returns>The updated user.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        /// <exception cref="System.ArgumentNullException">user</exception>
        /// <exception cref="System.NullReferenceException">user modified</exception>
        public async Task<ActionResult<User>> UpdateUser(int id, UserDTO userDto)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (userDto is null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var userModified = await _context.User.SingleOrDefaultAsync(x => x.Id == id);

            if (userModified is null)
            {
                throw new NullReferenceException(nameof(userModified));
            }

            var user = _iMapper.Map<User>(userDto);

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

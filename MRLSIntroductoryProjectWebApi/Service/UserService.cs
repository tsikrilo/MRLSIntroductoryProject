﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;
using MRLSIntroductoryProjectWebApi.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLRSIntroductoryWebApi.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <returns>A list of users</returns>
        public async Task<ActionResult<IEnumerable<User>>> GetUserList()
        {
            return await _userRepository.GetUsers();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user which has the specified id</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userId</exception>
        public async Task<ActionResult<User>> FetchUserByID(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            return await _userRepository.GetUserByID(userId);
        }

        /// <summary>
        /// Updates the user's data with the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userDto">The updated user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        /// <exception cref="System.ArgumentNullException">user</exception>
        /// <exception cref="System.NullReferenceException">user modified</exception>
        public async Task<ActionResult<User>> EditUser(int id, UserDTO userDto)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (userDto is null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            if (userDto.Name.Length > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(userDto.Name));
            }

            if (userDto.Surname.Length > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(userDto.Surname));
            }

            if (userDto.EmailAddress.Length > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(userDto.EmailAddress));
            }
            var user = _mapper.Map<User>(userDto);

            return await _userRepository.UpdateUser(id, user);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The created user</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (user.Name.Length > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(user.Name));
            }

            if (user.Surname.Length > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(user.Surname));
            }

            if (user.EmailAddress.Length > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(user.EmailAddress));
            }

            return await _userRepository.InsertUser(user);
        }


        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted user</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        public async Task<ActionResult<User>> DisableUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return await _userRepository.DeleteUser(id);
        }
    }
}

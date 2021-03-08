using DersYonetimSistemi.Business.Abstract;
using DersYonetimSistemi.Business.Constants;
using DersYonetimSistemi.Core.Utilities.Results;
using DersYonetimSistemi.DataAccess.Abstract;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DersYonetimSistemi.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private UserManager<User> _userManager;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public UserManager(IUserDal userDal, UserManager<User> userManager)
        {
            _userDal = userDal;
            _userManager = userManager;
        }

        public IResult Add(UserRegisterDetailDto registerDto)
        {
            var check = _userDal.IsExist(u => u.UserName == registerDto.UserName && u.Email == registerDto.Email);
            if (check == true)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            User user = new User
            {
                Email = registerDto.Email,
                AddedDate = DateTime.Now,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.UserName
            };

            var res = _userManager.CreateAsync(user, registerDto.Password);
            if (res.Result.Succeeded)
            {
                var res2 = _userManager.AddToRoleAsync(user, "Student");
                if (res2.Result.Succeeded)
                {
                    return new SuccessResult(Messages.RegisterAndRoleAddSuccedd);
                }
                return new SuccessResult(Messages.RegisterSucceeded);

            }
            else
            {
                return new ErrorResult(Messages.RegisterFailed);
            }
        }

        public IDataResult<User> GetById(int userId)
        {
            bool checkDb = _userDal.IsExist(U => U.Id == userId);
            if (checkDb == false)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<UserDetailDto> GetUserDetails(int userId)
        {
            bool checkDb = _userDal.IsExist(U => U.Id == userId);
            if (checkDb == false)
            {
                return new ErrorDataResult<UserDetailDto>(Messages.UserNotFound);
            }
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(userId));

        }

        public IDataResult<List<UserDetailDto>> GetUsersDetails()
        {
            var res = _userDal.GetUsersDetail();
            if (res != null)
            {
                return new SuccessDataResult<List<UserDetailDto>>(res);
            }
            else
            {
                return new ErrorDataResult<List<UserDetailDto>>(Messages.GetUserDetailsFailed);
            }

        }

        public IResult IsUserExists(int userId)
        {
            bool checkDb = _userDal.IsExist(U => U.Id == userId);
            if (checkDb == false)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            else
            {
                return new SuccessResult();
            }
        }

        public IResult Update(UserDetailDto userDetails)
        {
            bool checkDb = _userDal.IsExist(U => U.Id == userDetails.UserId);
            if (checkDb == false)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            User user = _userDal.Get(u => u.Id == userDetails.UserId);
            if (user != null)
            {
                var removeRole = _userManager.RemoveFromRoleAsync(user, _userDal.GetUserRoleName(userDetails.UserId));
                if (removeRole.Result.Succeeded)
                {
                    var addRole = _userManager.AddToRoleAsync(user, userDetails.RoleName);
                    if (addRole.Result.Succeeded)
                    {
                        user.Email = userDetails.Email;
                        user.Name = userDetails.Name;
                        user.Surname = userDetails.Surname;
                        user.UserName = userDetails.Username;
                        bool updateUser = _userDal.Update(user);
                        if (updateUser)
                        {
                            return new SuccessResult(Messages.AllUpdatesSucced);
                        }
                        else
                        {
                            return new ErrorResult(Messages.OnlyRoleUpdated);
                        }
                    }
                    else
                    {
                        return new ErrorResult(Messages.OnlyRoleRemoved);
                    }
                }
                else
                {
                    return new ErrorResult(Messages.AllUpdatesFailed);
                }
            }
            else
            {
                return new ErrorResult(Messages.UserNotFound);
            }

        }
    }
}

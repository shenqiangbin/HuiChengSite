using HuiChengSite.Models;
using HuiChengSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuiChengSite.Service
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public int Add(User model)
        //{
        //    model.ContentLevel = (int)ContentLevel.Common;
        //    model.PublishStatus = (int)PublishStatus.Not;

        //    var time = DateTime.Now;

        //    model.DisplayCreatedTime = time;
        //    model.CreatedTime = time;
        //    model.UpdateTime = time;
        //    model.Enable = 1;

        //    var id = _UserRepository.Add(model);
        //    return id;
        //}

        //public int Update(User model)
        //{
        //    model.UpdateTime = DateTime.Now;
        //    return _UserRepository.Update(model);
        //}

        public User GetById(string UserId)
        {
            return _userRepository.GetById(UserId);
        }

        //public UserListModelResult GetPaged(UserListQuery listModel)
        //{
        //    return _UserRepository.GetPaged(listModel);
        //}

        public void Remove(int id)
        {
            _userRepository.Remove(id);
        }

        public User GetUserByEmail(string email)
        {
            IEnumerable<User> users;
            users = _userRepository.GetUserByEmail(email);
            if (users != null && users.Count() > 1)
                throw new Exception("email有重复：" + email);

            return users.FirstOrDefault();
        }
    }
}
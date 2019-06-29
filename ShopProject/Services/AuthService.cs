using ProjectShopRepository.Model;
using ProjectShopRepository.Repository;
using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Services
{
    public class AuthService
    {
        IRepository<User> _repository;
        public AuthService()
        {
            _repository = new ShopRepository<User>();
        }

        public bool Login(UserAuthModel user)
        {
            if(_repository.GetAll().Where(x => x.Login.ToLower() == user.Name.ToLower() && x.Password == user.Password).FirstOrDefault()!=null)
            {
                return true;
            }
            return false;
        }

        public bool Register(RegisterModel model)
        {
            _repository.Create(new User()
            {
                Login = model.Name,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone
            });
            return true;
        }

        public bool IsUserExist(string Name)
        {
            if(_repository.GetAll().Where(x => x.Login == Name).FirstOrDefault()!=null)
            {
                return true;
            }
            return false;
        }
    }
}
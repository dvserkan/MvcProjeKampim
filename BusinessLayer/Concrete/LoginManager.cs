using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public void AdminAdd(Admin admin)
        {
            _loginDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _loginDal.Update(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _loginDal.Update(admin);
        }

        public List<Admin> GetAdminList(string id = null)
        {
            return _loginDal.List(x => x.AdminStatus == true);
        }

        public Admin GetByID(int id)
        {
            return _loginDal.Get(x => x.AdminID == id);
        }

        public Admin GetLogin(string username, string password)
        {
            return _loginDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }
    }
}
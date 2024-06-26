﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILoginService
    {
        Admin GetLogin(string username, string password);

        List<Admin> GetAdminList(string id = null);
        void AdminAdd(Admin admin);
        Admin GetByID(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);

    }
}

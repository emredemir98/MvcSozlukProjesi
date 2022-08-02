using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminLoginService
    {

        Admin GetAdminIfExist(Admin admin);
        Admin GetAdminByUsername(string username);
        void AdminLoginUpdate(Admin admin);
       
    }
}

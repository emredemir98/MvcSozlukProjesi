using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminLoginDal _adminloginDal;

        public AdminLoginManager(IAdminLoginDal adminloginDal)
        {
            _adminloginDal = adminloginDal;
        }

        public Admin GetAdminIfExist(Admin admin)
        {
            return _adminloginDal.Get(x => x.AdminUserNameEncrypt == admin.AdminUserNameEncrypt && x.AdminPasswordEncrypt == admin.AdminPasswordEncrypt);
        }
        public Admin GetAdminByUsername(string username)
        {
            return _adminloginDal.Get(x => x.AdminUserNameEncrypt == username);
        }

        public void AdminLoginUpdate(Admin admin)
        {
            _adminloginDal.Update(admin);
        }
      
    }
}

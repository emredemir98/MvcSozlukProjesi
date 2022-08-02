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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterLoginDal _writerloginDal;

        public WriterLoginManager(IWriterLoginDal writerloginDal)
        {
            _writerloginDal = writerloginDal;
        }

        public Writer GetWriterIfExist(Writer writer)
        {
            return _writerloginDal.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }
        public Writer GetWriterByUsername(string username)
        {
            return _writerloginDal.Get(x => x.WriterMail == username);
        }

        public void WriterLoginUpdate(Writer writer)
        {
            _writerloginDal.Update(writer);
        }
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public  interface IWriterLoginService
    {
        Writer GetWriterIfExist(Writer writer);
        Writer GetWriterByUsername(string username);
        void WriterLoginUpdate(Writer writer);
    }
}

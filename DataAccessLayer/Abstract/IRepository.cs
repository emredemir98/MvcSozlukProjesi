using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter); // tek değer döndürmek için(Idsi 5 olan yazar)
        void Delete(T p);
        void Update(T p);   

        List<T> List(Expression<Func<T,bool>> filter); // birden fazla değer döndürmek için(İsmi Ali olan yazarlar)
    }
}

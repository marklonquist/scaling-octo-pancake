using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestseller.Database.Interfaces
{
    public interface IRepository<T, Key> where Key : IEquatable<Key>
    {
        List<T> GetMultiple(params Key[] ids);
        List<T> GetAll();
        T Get(Key id);
    }
}

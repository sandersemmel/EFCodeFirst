using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        List<T> GetAll();
        List<T> Find();
        T FindSingle(int? id);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShopRepository.Model
{
    public interface IRepository<T>
    {
        void Create(T item);
        void Remove(int Id);
        void Update(T item);
        T Get(int Id);
        List<T> GetAll();
    }
}

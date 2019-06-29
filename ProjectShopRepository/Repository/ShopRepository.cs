using ProjectShopRepository.Context;
using ProjectShopRepository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShopRepository.Repository
{
    public class ShopRepository<T> : IRepository<T> where T: Item
    {
        ProjectContext _projectContext;
        DbSet<T> _dbSet;

        public ShopRepository()
        {
            _projectContext = new ProjectContext();
            _dbSet = _projectContext.Set<T>();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _projectContext.SaveChanges();
        }

        public T Get(int Id)
        {
            return _dbSet.Find(Id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(int Id)
        {
            T ItemToRemove = _dbSet.Find(Id);
            _dbSet.Remove(ItemToRemove);
            _projectContext.SaveChanges();
        }

        public void Update(T item)
        {
            _projectContext.Entry(item).State = EntityState.Modified;
            _projectContext.SaveChanges();
        }
        ~ShopRepository()
        {
            _projectContext.Dispose();
        }
    }
}

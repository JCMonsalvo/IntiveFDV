using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_BikeRental.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(Func<T, bool> exp);
        IQueryable<T> GetAll(Func<T, bool> exp);
        void Update(T entity);
        void Delete(T entity);
    }
    public interface IRepository
    {
        object GetOne();
        IQueryable GetAll();
        void Update(object entity);
        void Delete(object entity);
    }

    //Should be finnally define when project data provider be defined
    public class Repository<T> : IRepository<T> where T : class
    {
        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public virtual IQueryable<T> GetAll(Func<T, bool> exp)
        {
            throw new NotImplementedException();
        }

        public virtual T GetOne(Func<T, bool> exp)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycore_Week3.Context
{
    public interface IMapperSession<T>
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> query { get; }
       
    }
}

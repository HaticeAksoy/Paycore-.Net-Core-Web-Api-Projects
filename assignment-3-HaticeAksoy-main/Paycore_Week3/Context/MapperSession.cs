using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycore_Week3.Context
{
    public class MapperSession<T> : IMapperSession<T>
    {

        private readonly ISession session;
        private ITransaction transaction;
        public IQueryable<T> query => session.Query<T>();

        public MapperSession(ISession session)
        {
            this.session = session;
        }

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Save(T entity)
        {
            session.Save(entity);
        }
        public void Update(T entity)
        {
            session.Update(entity);
        }
        public void Delete(T entity)
        {
            session.Delete(entity);
        }

       
    }
}

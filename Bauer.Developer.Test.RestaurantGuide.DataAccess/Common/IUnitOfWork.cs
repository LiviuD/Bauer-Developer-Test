using Bauer.Developer.Test.RestaurantGuide.Domain;
using System;

namespace Bauer.Developer.Test.RestaurantGuide.DataAccess.Common
{
    public interface IUnitOfWork :  IDisposable
    {
        int SaveChanges();

        IUnitOfWork GetNewContext(bool disposeExisting = false);
        IBaseRepository<T> Repository<T>() where T : class, IEntity;

        //IDisposable BeginTransaction();
        //void CommitTransaction();
        //void RollbackTransaction();
    }
}

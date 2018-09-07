using Bauer.Developer.Test.RestaurantGuide.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bauer.Developer.Test.RestaurantGuide.Services
{
    public class BaseService : IService
    {
        protected IUnitOfWork UnitOfWork;

        #region Constructor

        public BaseService()
        { }

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

    }
}

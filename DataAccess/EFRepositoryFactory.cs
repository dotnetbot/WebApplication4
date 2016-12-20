using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using Core;
using Models;

namespace DataAccess
{    
    public class EFRepositoryFactory : IRepositoryFactory
    {
        public IRepository MakeRepository()
        {
            var appDbContext = new ApplicationDbContext();

            appDbContext.Database.CommandTimeout = 300;
            appDbContext.Configuration.LazyLoadingEnabled = true;
            return new EFRepository(appDbContext);
        }
    }
}

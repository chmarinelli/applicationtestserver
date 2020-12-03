using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestServer.Core;
using TestServer.DM.Context;

namespace TestServer.BL.UnitOfWork
{
    public partial class UnitOfWork
    {
        private readonly IServiceProvider _container;

        public UnitOfWork(IServiceProvider container)
        {
            _container = container;
        }

        public IEntityBaseRepository<TEntity> Get<TEntity>() where TEntity : class, IEntityBase, new()
        {
            return _container.GetRequiredService<IEntityBaseRepository<TEntity>>();
        }
        public async Task SaveAsync()
        {
            try
            {
                await _container.GetRequiredService<TestServerContext>().SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
    }
}

using SicopataSchool.Core.BaseModel.BaseEntity;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.Model.UnitOfWorks.SicopataSchool
{
    public class SicopataSchoolUnitOfWork : IUnitOfWork<ISicopataSchoolDbContext>
    {
        public ISicopataSchoolDbContext context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public SicopataSchoolUnitOfWork(IServiceProvider serviceProvider, ISicopataSchoolDbContext context)
        {
            _serviceProvider = serviceProvider;
            this.context = context;
        }

        public async Task<int> Commit()
        {
            var result = await context.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity>(this)) as IRepository<TEntity>;
        }
    }
}

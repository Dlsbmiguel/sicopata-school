using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SicopataSchool.Core.BaseModel.BaseEntity;

namespace SicopataSchool.Model.Contexts.SicopataSchool
{
    public interface ISicopataSchoolDbContext : IDisposable
    {
        DatabaseFacade Database { get; }
        DbSet<T> GetDbSet<T>() where T : class, IBaseEntity;
        int SaveChanges();
        ChangeTracker ChangeTracker();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}

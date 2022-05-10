using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using SicopataSchool.Core.BaseModel.BaseEntity;
using SicopataSchool.Core.Models;
using SicopataSchool.Model.Entities;

namespace SicopataSchool.Model.Contexts.SicopataSchool
{
    public class SicopataSchoolDbContext : BaseDbContext, ISicopataSchoolDbContext
    {
        public SicopataSchoolDbContext(DbContextOptions<SicopataSchoolDbContext> options,
            IOptions<AppSettings> appSettings)
            : base(options, appSettings)
        {
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();

        ChangeTracker ISicopataSchoolDbContext.ChangeTracker()
        {
            return base.ChangeTracker;
        }
    }
}

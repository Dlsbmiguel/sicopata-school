using Microsoft.EntityFrameworkCore;
using SicopataSchool.Core.BaseModel.BaseEntity;
using System.Reflection;

namespace SicopataSchool.Model.Extensions
{
    public static class EFFilterExtensions
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EFFilterExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : class, IBaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.Deleted);
        }
    }
}

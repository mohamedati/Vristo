using Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Diagnostics;

using Domain.Common;

namespace API.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor:SaveChangesInterceptor
    {
        private readonly ICurrentUserService currentUser;

        public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
        }
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
      DbContextEventData eventData, 
      InterceptionResult<int> result,
      CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditingEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = currentUser.GetCurrentUser() ;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = currentUser.GetCurrentUser() ;
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
                else if(entry.State == EntityState.Deleted)
                {
                    entry.Entity.DeletedBy = currentUser.GetCurrentUser();
                    entry.Entity.DeletedAt = DateTime.Now;
                }
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }



    
}

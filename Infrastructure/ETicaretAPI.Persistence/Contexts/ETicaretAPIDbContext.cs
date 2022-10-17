using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }


        /*insert ve update yapılan tüm dataları elde edip, işlem gerçekleşmeden,
        üzerinde istediğimiz değişikliği yaparız ve SaveChangesAsync methodunu devreye sokarız.*/
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            /*ChangeTracker:Entityler üzerinde yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan property dir.
            Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlıyor.*/
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate=DateTime.UtcNow,
                    _ => DateTime.UtcNow


                };

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

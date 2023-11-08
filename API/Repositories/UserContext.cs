using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace API.Repositories
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserModel> User { get; set; }

        public async Task<UserModel?> Get(int? id)
        {
            return await User.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<List<UserModel>> Get()
        {
            return await User.ToListAsync();
        }

        public async Task<UserModel?> Create(UserModel entity)
        {
            EntityEntry<UserModel> response = await User.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id);
        }

        public async void Delete(int id)
        {
            UserModel? user = await Get(id);
            User.Remove(user ?? throw new Exception("No se encontró el usuario"));
            await SaveChangesAsync();
        }
    }
}

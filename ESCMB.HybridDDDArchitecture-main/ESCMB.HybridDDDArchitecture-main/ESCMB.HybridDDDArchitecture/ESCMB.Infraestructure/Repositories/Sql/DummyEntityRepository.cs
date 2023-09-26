using Common.Infraestructure.Repositories.Sql;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Domain.Entities;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    /// <summary>
    /// Ejemplo de repositorio SQL de entidad Dummy
    /// Todo repositorio debe implementar la interfaz que hereda de <see cref="Common.Application.Repositories.Sql.IRepository{T}"/>
    /// creada en la capa de aplicacion, y heredar de <see cref="BaseRepository{T}"/>
    /// donde <c T> es la entidad de dominio que queremos persistir
    /// </summary>
    internal sealed class DummyEntityRepository : BaseRepository<DummyEntity>, IDummyEntityRepository
    {
        public DummyEntityRepository(StoreDbContext context) : base(context)
        {
        }

        public async Task<int> AddOneAsync(DummyEntity entity)
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));

            await Repository.AddAsync(entity);
            await Context.SaveChangesAsync();

            return Convert.ToInt32(Context.Entry(entity).Property("Id").CurrentValue);
        }
    }
}

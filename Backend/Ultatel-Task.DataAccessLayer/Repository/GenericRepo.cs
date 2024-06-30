using Ultatel_Task.DataAccessLayer.Repository.Contract;

namespace Ultatel_Task.DataAccessLayer.Repository
{
    public class GenericRepo<T> : IGenericRepo<T>
    {
        private readonly Ultatel_DBContext db;
        public GenericRepo(Ultatel_DBContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task<T?> AddAsync(T entity)
        {
            await db.AddAsync(entity);
            return entity;
        }

    }
}

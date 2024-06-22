namespace Ultatel_Task.DataAccessLayer.Repository.Contract
{
    public interface IGenericRepo<T>
    {
        Task<T?> AddAsync(T entity);
    }
}

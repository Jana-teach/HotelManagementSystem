namespace HotelManagementSystem.Repos.GenericRepo
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetById(int id);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
        public Task Save();
    }
}

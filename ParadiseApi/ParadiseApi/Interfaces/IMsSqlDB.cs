namespace ParadiseApi.Interfaces
{
    public interface IMsSqlDB<T,E>
    {
        public Task<T> CreateEnity(E enity);
        public Task<T> UpdateEnity(E enity);
        public Task<T> DeleteEnity(E enity);
    }
}

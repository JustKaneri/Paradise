using ParadiseApi.Models;

namespace ParadiseApi.Interfaces
{
    public interface IProfileRepository
    {
        public Profile GetProfile(int idUser);
    }
}

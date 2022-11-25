using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _context;

        public ProfileRepository(DataContext context)
        {
            _context = context;
        }

        public Profile GetProfile(int idUser)
        {
            Profile profile = _context.Profiles.Where(pr => pr.User.Id == idUser).DefaultIfEmpty().First();

            return profile;
        }
    }
}

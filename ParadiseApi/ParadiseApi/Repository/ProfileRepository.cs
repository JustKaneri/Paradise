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

        public bool UploadProfleAvatar(IFormFile file, int idUser)
        {
            Profile prof = _context.Profiles.Where(pr => pr.IdUser == idUser).DefaultIfEmpty().First();
            string oldAvatar = null;

            if (prof == null)
                prof = CreateProfile(idUser);
            else
                oldAvatar = prof.PathAvatar;

            try
            {
                string fileName = idUser.ToString() + Guid.NewGuid() + DateTime.Now.ToString("yyyyMMddHHmmssfff")+ Path.GetExtension(file.FileName);
                string patch = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Avatars", fileName);

                using (Stream fs = new FileStream(patch,FileMode.Create))
                {
                    file.CopyTo(fs);
                }

                prof.PathAvatar = "Avatars//" + fileName;
                _context.Profiles.Add(prof);
                _context.SaveChanges();

                if(oldAvatar!=null)
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldAvatar));
            }
            catch 
            {  
                return false;
            }

            return true;
        }

        public Profile UploadProfleFon(IFormFile file, int idUser)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create new profile for user
        /// </summary>
        /// <param name="IdUser"></param>
        private Profile CreateProfile(int IdUser)
        {
            Profile profile = new Profile();
            profile.IdUser = IdUser;

            _context.Profiles.Add(profile);
            _context.SaveChanges();

            return profile;
        }

        
    }
}

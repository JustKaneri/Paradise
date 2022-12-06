using Microsoft.EntityFrameworkCore;
using ParadiseApi.Data;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using ParadiseApi.Other;

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
            Profile profile = ExistenceModel.Profiles(idUser, _context);

            return profile;
        }

        public Profile UploadProfleAvatar(IFormFile file, int idUser)
        {
            Profile prof = ExistenceModel.Profiles(idUser, _context);
            string oldAvatar = null;

            if (prof == null)
                prof = CreateProfile(idUser);
            else
                oldAvatar = prof.PathAvatar;

            try
            {
                string fileName = RootFile.SaveFile(idUser, "Avatars", file);

                if (fileName == null)
                    return null;

                prof.PathAvatar = "Avatars/" + fileName;
                _context.Profiles.Update(prof);
                _context.SaveChanges();

                if (oldAvatar != null)
                    RootFile.DeleteFile(oldAvatar);
            }
            catch 
            {
                return null;
            }

            return prof;
        }

        public Profile UploadProfleFon(IFormFile file, int idUser)
        {
            Profile prof = ExistenceModel.Profiles(idUser, _context);
            string oldFon = null;

            if (prof == null)
                prof = CreateProfile(idUser);
            else
                oldFon = prof.PathFon;

            try
            {
                string fileName = RootFile.SaveFile(idUser, "Fons", file);

                if (fileName == null)
                    return null;

                prof.PathFon = "Fons/" + fileName;
                _context.Profiles.Update(prof);
                _context.SaveChanges();

                if (oldFon != null)
                    RootFile.DeleteFile(oldFon);
            }
            catch
            {
                return null;
            }

            return prof;
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

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

        public Profile GetProfile(int idUser,ref string error)
        {
            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            Profile profile = ExistenceModel.Profiles(idUser, _context);

            return profile;
        }

        public Profile UploadProfleAvatar(IFormFile file, int idUser,ref string error)
        {
            Profile prof = ExistenceModel.Profiles(idUser, _context);
            string oldAvatar = null;

            if (ExistenceModel.User(idUser, _context) == null)
            {
                error = "User not existence";
                return null;
            }

            if (prof == null)
                prof = CreateProfile(idUser);
            else
                oldAvatar = prof.PathAvatar;

            try
            {
                string fileName = RootFile.SaveFile(idUser, "Avatars", file);

                if (fileName == null)
                {
                    error = "Failed to save file";
                    return null;
                }
                    

                prof.PathAvatar = "Avatars/" + fileName;
                _context.Profiles.Update(prof);
                _context.SaveChanges();

                if (oldAvatar != null)
                    RootFile.DeleteFile(oldAvatar);
            }
            catch 
            {
                error = $"Failed save avatar";
                return null;
            }

            return prof;
        }

        public Profile UploadProfleFon(IFormFile file, int idUser, ref string error)
        {
            Profile prof = ExistenceModel.Profiles(idUser, _context);
            string oldFon = null;

            if(ExistenceModel.User(idUser,_context)==null)
            {
                error = "User not existence";
                return null;
            }

            if (prof == null)
                prof = CreateProfile(idUser);
            else
                oldFon = prof.PathFon;

            try
            {
                string fileName = RootFile.SaveFile(idUser, "Fons", file);

                if (fileName == null)
                {
                    error = "Failed to save file";
                    return null;
                }

                prof.PathFon = "Fons/" + fileName;
                _context.Profiles.Update(prof);
                _context.SaveChanges();

                if (oldFon != null)
                    RootFile.DeleteFile(oldFon);
            }
            catch
            {
                error = $"Failed save avatar";
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

using Microsoft.EntityFrameworkCore;
using Paradise.Data.Data;
using ParadiseApi.Interfaces;
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

        public async Task<RequestResult<Profile>> GetProfile(int idUser)
        {
            RequestResult<Profile> requestResult = new RequestResult<Profile>();

            if (ExistenceModel.User(idUser, _context) == null)
            {
                requestResult.SetError("Пользователь не найден");
                return requestResult;
            }

            requestResult.Result = await _context.Profiles.FirstOrDefaultAsync(pr => pr.IdUser == idUser);

            return requestResult;
        }

        public async Task<RequestResult<Profile>> UploadProfleAvatar(IFormFile file, int idUser)
        {
            RequestResult<Profile> requestResult = new RequestResult<Profile>();

            Profile prof = ExistenceModel.Profiles(idUser, _context);
            string oldAvatar = null;

            if (ExistenceModel.User(idUser, _context) == null)
            {
                requestResult.SetError("Пользователь не найден");
                return requestResult;
            }

            if (prof == null)
                prof = await CreateProfile(idUser);
            else
                oldAvatar = prof.PathAvatar;

            try
            {
                string fileName = await RootFile.SaveFile(idUser, "avatars", file);

                if (fileName == null)
                {
                    requestResult.SetError("Не удалось сохранить файл");
                    return requestResult;
                }
                    

                prof.PathAvatar = "avatars/" + fileName;

                _context.Profiles.Update(prof);
                await _context.SaveChangesAsync();

                if (oldAvatar != null)
                    RootFile.DeleteFile(oldAvatar);

                requestResult.Result = prof;
            }
            catch 
            {
                requestResult.SetError("Не удалось установить аватар");
                return requestResult;
            }

            return requestResult;
        }

        public async Task<RequestResult<Profile>> UploadProfleFon(IFormFile file, int idUser)
        {
            RequestResult<Profile> requestResult = new RequestResult<Profile>();

            Profile prof = ExistenceModel.Profiles(idUser, _context);
            string oldFon = null;

            if (ExistenceModel.User(idUser, _context) == null)
            {
                requestResult.SetError("Пользователь не найден");
                return requestResult;
            }

            if (prof == null)
                prof = await CreateProfile(idUser);
            else
                oldFon = prof.PathFon;

            try
            {
                string fileName = await RootFile.SaveFile(idUser, "fons", file);

                if (fileName == null)
                {
                    requestResult.SetError("Не удалось сохранить файл");
                    return requestResult;
                }

                prof.PathFon = "fons/" + fileName;
                _context.Profiles.Update(prof);
                await  _context.SaveChangesAsync();

                if (oldFon != null)
                    RootFile.DeleteFile(oldFon);

                requestResult.Result = prof;
            }
            catch
            {
                requestResult.SetError("Не удалось установить фоновое изображение");
                return requestResult;
            }

            return requestResult;
        }

        /// <summary>
        /// Create new profile for user
        /// </summary>
        /// <param name="IdUser"></param>
        public async Task<Profile> CreateProfile(int IdUser)
        {
            Profile profile = new Profile();
            profile.IdUser = IdUser;

            try
            {
                _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();
            }
            catch 
            {

            }

            return profile;
        }

    }
}

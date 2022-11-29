namespace ParadiseApi.Other
{
    public static class RootFile
    {
        public static string SaveFile(int idUser, string directoryName, IFormFile file)
        {
            string fileName = null;

            try
            {
                fileName = idUser.ToString() + Guid.NewGuid() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);
                string patch = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot//{directoryName}", fileName);

                using (Stream fs = new FileStream(patch, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
            }
            catch
            {
                return null;
            }

            return fileName;
        }

        public static void DeleteFile(string fileName)
        {
            string fullPatch = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            if (File.Exists(fullPatch))
                File.Delete(fullPatch);
        }
    }
}

namespace AulersWebAPI.Services
{
    public class FileSavingService : IFileSavingService
    {
        public Task DeleteFile(string path, string container)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(byte[] content, string extension, string container, string path, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            throw new NotImplementedException();
        }
    }
}

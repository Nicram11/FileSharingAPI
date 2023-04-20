namespace FileSharingAPI.Application.Interfaces
{
    public interface IStoreFiles
    {
        public Task<Stream> ReadFileAsync(string filePath);
        public Task SaveFileAsync(IFormFile file, Guid guid, string fileStoragePath);
        public Task DeleteFileAsync(Guid fileId, string fileStoragePath);
    }
}

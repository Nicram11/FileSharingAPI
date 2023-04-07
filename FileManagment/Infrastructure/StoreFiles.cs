using FileSharingAPI.FileManagment.Core;

namespace FileSharingAPI.FileManagment.Infrastructure
{
    public class StoreFiles : IStoreFiles
    {
        public async Task<Stream> ReadFileAsync(string fileName, string fileStoragePath)
        {
            var filePath = Path.Combine(fileStoragePath, fileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return await Task.FromResult(stream);
        }



        public async Task SaveFileAsync(IFormFile file, Guid fileId, string fileStoragePath)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileStoragePath, fileId.ToString());
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public Task DeleteFileAsync(string fileName, string fileStoragePath)
        {
            throw new NotImplementedException();
        }



    }
}

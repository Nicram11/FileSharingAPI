using FileSharingAPI.FileManagment.Core;

namespace FileSharingAPI.FileManagment.Infrastructure
{
    public class StoreFiles : IStoreFiles
    {
        public async Task<Stream> ReadFileAsync(string filePath)
        {
           
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return await Task.FromResult(stream);
        }

        public async Task SaveFileAsync(IFormFile file, Guid fileGuid, string fileStoragePath)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileStoragePath, fileGuid.ToString() + Extension.GetExtensionFromContentType(file.ContentType));
           
            using FileStream stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        
        }

        public Task DeleteFileAsync(Guid fileName, string fileStoragePath)
        {
            throw new NotImplementedException();
        }



    }
}

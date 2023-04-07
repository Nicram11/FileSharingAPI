using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Core;
using FileSharingAPI.FileManagment.Model;
using Microsoft.EntityFrameworkCore;

namespace FileSharingAPI.FileManagment.Infrastructure
{
    public class StoreFileHeaders : IStoreFileHeaders
    {
        private readonly FileSharingDbContext _dbContext;

        public StoreFileHeaders(FileSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateFileHeaderAsync(CreateFileRequest request)
        {

            var fileHeader = new FileHeader
            {
                Id = Guid.NewGuid(),
                FileName = request.FileName,
                FilePath = request.FilePath,
                ContentType = request.ContentType,
                FileSize = request.FileSize,
                UploadDate = request.UploadDate,
                UserId = request.UserId
            };

            _dbContext.Add(fileHeader);
            var result = await _dbContext.SaveChangesAsync();

            if(result == 0) return Guid.Empty;

            return fileHeader.Id;
        }

        public async Task<int> DeleteFileHeaderAsync(Guid id)
        {
            var fileHeader = await GetFileHeaderAsync(id);
            _dbContext.Files.Remove(fileHeader);
            return await _dbContext.SaveChangesAsync();
            
        }
        public async Task<FileHeader> GetFileHeaderAsync(Guid id)
        {
            return await _dbContext.Files.FirstAsync(f => f.Id == id);

            //return await Task.FromResult(fileHeader);
        }
    }
}

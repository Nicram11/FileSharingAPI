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

        public async Task<bool> CreateFileHeaderAsync(CreateFileRequest request)
        {
            throw new NotImplementedException();
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

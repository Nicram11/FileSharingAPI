using FileSharingAPI.Application.Interfaces;
using FileSharingAPI.Database;
using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Model;
using Microsoft.EntityFrameworkCore;

namespace FileSharingAPI.Infrastructure.FileManagment
{
    public class StoreFileHeaders : IStoreFileHeaders
    {
        private readonly FileSharingDbContext _dbContext;

        public StoreFileHeaders(FileSharingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateFileHeaderAsync(CreateFileRequest request, string filePath)
        {
            Guid guid = Guid.NewGuid();
            var fileHeader = new FileHeader
            {
                Id = guid,
                FileName = request.FileName,
                FilePath = Path.Combine(filePath, guid.ToString() + Extension.GetExtensionFromContentType(request.ContentType)),
                ContentType = request.ContentType,
                FileSize = request.FileSize,
                UploadDate = request.UploadDate,
                UserId = request.UserId
            };

            _dbContext.Add(fileHeader);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0) return Guid.Empty;

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

        public async Task<List<FileHeader>> GetUserFileHeadersAsync(string userId)
        {
            User user = await _dbContext.Users.Include(u => u.Files).FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null) return null;

            return user.Files.ToList();
        }
    }
}

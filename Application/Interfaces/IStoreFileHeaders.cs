using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Model;

namespace FileSharingAPI.Application.Interfaces
{
    public interface IStoreFileHeaders
    {
        public Task<FileHeader> GetFileHeaderAsync(Guid id);
        public Task<Guid> CreateFileHeaderAsync(CreateFileRequest request, string filePath);
        public Task<int> DeleteFileHeaderAsync(Guid id);
        public Task<List<FileHeader>> GetUserFileHeadersAsync(string userId);
    }
}

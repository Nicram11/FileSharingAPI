using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Model;

namespace FileSharingAPI.FileManagment.Core
{
    public interface IStoreFileHeaders
    {

        public Task<FileHeader> GetFileHeaderAsync(Guid id);
        public Task<Guid> CreateFileHeaderAsync(CreateFileRequest request);
        public Task<int> DeleteFileHeaderAsync(Guid id);
    }
}

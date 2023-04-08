using FileSharingAPI.FileManagment.Model;
using System.Security.Claims;

namespace FileSharingAPI.FileManagment.Core
{
    public interface IFileStorageService
    {
        public Task<SaveFileResult> SaveFileAsync(IFormFile file, CreateFileRequest createFileRequest);
        public Task<DownloadFileResult> DownloadAsync(Guid guid);
        public Task<List<GetFileHeadersResult>> GetUserFileHeadersAsync(ClaimsPrincipal user);
    }
}

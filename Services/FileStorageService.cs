using FileSharingAPI.Entities;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace FileSharingAPI.Services
{

    public interface IFileStorageService
    {
        public Task SaveFileAsync(IFormFile file, String fileId);
        public Task<Stream> ReadFileAsync(string fileName);
        public Task DeleteFileAsync(string fileName);
        public Task<FileHeader> GetFileAsync(string id);
    }
    public class FileStorageService : IFileStorageService
    {

        private readonly string _fileStoragePath = "files";
        public Task DeleteFileAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<FileHeader> GetFileAsync(string id)
        {
            // Pobierz informacje o pliku z bazy danych lub innego systemu przechowywania
            var fileInfo = new FileHeader
            {
                Id = Guid.Parse(id),
                FileName = "example.txt",
                ContentType = "text/plain",
                FileSize = 1024,
                UploadDate = DateTime.Now,
                FilePath = Path.Combine(_fileStoragePath, "example.txt")
            };

            return await Task.FromResult(fileInfo);
        }

        public async Task<Stream> ReadFileAsync(string fileName)
        {
            var filePath = Path.Combine(_fileStoragePath, fileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return await Task.FromResult(stream);
        }

    

        public async Task SaveFileAsync(IFormFile file, string fileId)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _fileStoragePath, fileId);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
